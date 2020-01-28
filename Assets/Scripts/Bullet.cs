using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Bullet : NetworkBehaviour
{
    [SerializeField] GameObject bulletGraphics = null;

    [SerializeField] LayerMask layersToIgnore = 0;

    private void Update()
    {
        // Don't do anything without authority
        if (!hasAuthority)
            return;

        if (transform.position.y <= -10f)
        {
            CmdDestroyBullet();
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        // Don't do anything without authority
        if (!hasAuthority)
            return;

        // Damage remote players
        // TODO: Make this actually work
        if (other.gameObject.layer == LayerMask.NameToLayer("RemotePlayer"))
        {
            PlayerNetwork playerNetwork = other.GetComponent<PlayerNetwork>();
            if (playerNetwork == null)
            {
                Debug.LogError("Player does not have a PlayerNetwork script!");
            }
            else
            {
                playerNetwork.RpcTakeDamage(5);
            }
        }

        // Calls CmdDestroyBullet() if object hit is not in layersToIgnore
        if (((1 << other.gameObject.layer) & layersToIgnore) == 0 && hasAuthority)
        {
            CmdDestroyBullet();
        }
    }

    // Applies bullet settings to all players
    [ClientRpc]
    public void RpcApplyBulletSettings(float speed, float radius)
    {
        // Set radius
        GetComponent<SphereCollider>().radius = radius;

        // Set radius visually
        float scale = radius * 2;
        bulletGraphics.transform.localScale = new Vector3(scale, scale, scale);

        // Launch projectile
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    // Tells the server to destroy the projectile on all objects
    [Command]
    void CmdDestroyBullet()
    {
        NetworkServer.Destroy(gameObject);
    }
}
