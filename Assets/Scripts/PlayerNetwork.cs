using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour
{
    [SyncVar]
    int health;

    int maxHealth = 100;

    private void Start()
    {
        health = maxHealth;
    }

    [ClientRpc]
    public void RpcTakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(gameObject + " has " + health + " health!");
    }
}
