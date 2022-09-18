using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderBullet : MonoBehaviour
{
    [SerializeField] float bullet_speed = 1.8f;
    int bullet_power;

    void Start(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bullet_speed); 
        bullet_power = Random.Range(1, 10);
    }

    void Update(){
        DestroyBulletIfOutOfScreen();  
    }

    void DestroyBulletIfOutOfScreen(){        
        if(transform.position.y > 4.45f || transform.position.y < -4.45f){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Hud player = other.gameObject.GetComponent<Hud>();
        if(player != null){
            player.RemoveLife(bullet_power);        
            Destroy(gameObject);
        }    
    }

}
