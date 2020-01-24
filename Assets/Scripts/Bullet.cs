using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Bullet : NetworkBehaviour
{
    [SerializeField] GameObject bulletGraphics = null;

    [SerializeField] LayerMask layersToIgnore = 0;

    private void Start()
    {
        // Disables this script if not on a client with authority
        if (!hasAuthority)
        {
            enabled = false;
            return;
        }
    }

    // Applies bullet settings to all players
    [ClientRpc]
    public void RpcApplyBulletSettings(float _speed, float _radius)
    {
        // Set radius
        GetComponent<SphereCollider>().radius = _radius;

        // Set radius visually
        float scale = _radius * 2;
        bulletGraphics.transform.localScale = new Vector3(scale, scale, scale);

        // Launch projectile
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * _speed, ForceMode.Impulse);
    }

    // Tells the server to destroy the projectile on all objects
    [Command]
    void CmdDestroyBullet()
    {
        NetworkServer.Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Calls CmdDestroyBullet() if object hit is not in layersToIgnore
        if (((1 << other.gameObject.layer) & layersToIgnore) == 0 && hasAuthority) 
        {
            CmdDestroyBullet();
        }
    }
}
