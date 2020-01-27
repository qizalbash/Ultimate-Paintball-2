using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour
{
    public float speed = 10.0f;


    void Start(){
        speed = 20.0f;
        StartCoroutine(DeathRoutine());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision){
        Destroy(gameObject);
    }

    IEnumerator DeathRoutine(){
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
    }
}