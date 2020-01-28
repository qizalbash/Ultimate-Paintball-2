using UnityEngine;
<<<<<<< HEAD:Assets/Scripts/BulletScript.cs
using System.Collections;
using UnityEngine.Networking;
=======
>>>>>>> parent of 06f5935... Projectile behavior:Assets/Scripts/Bullet.cs

public class BulletScript : NetworkBehaviour
{
    public float speed;

    private void Update()
    {
<<<<<<< HEAD:Assets/Scripts/BulletScript.cs
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
=======
        
    }
}
>>>>>>> parent of 06f5935... Projectile behavior:Assets/Scripts/Bullet.cs
