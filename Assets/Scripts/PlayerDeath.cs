using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    {SerializeField} private Transform player;
    {SerializeField} private Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
          player.ransform.position = respawnPoint.transform.position;  
    }
}
