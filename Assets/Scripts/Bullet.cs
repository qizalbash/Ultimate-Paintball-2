using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
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
        if(collision.gameObject.tag == "terrain"){
            Destroy(gameObject);
        }
       
    }

    IEnumerator DeathRoutine(){
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
    }
    
    }
