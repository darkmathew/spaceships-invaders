using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{    
    [SerializeField] float bullet_speed = 1.8f;    
    int bullet_power = 2;
    int invader_health;
    Hud hud;
    
    void Start(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, bullet_speed); 
        hud = FindObjectOfType<Hud>();
    }
    
    void Update(){
        DestroyBulletIfOutOfScreen();  
    }

    void DestroyBulletIfOutOfScreen(){        
        if(transform.position.y > 4.45f || transform.position.y < -4.45f){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        
        Invader invader = collision.gameObject.GetComponent<Invader>();
        if(invader != null){            
            
            Invaders.invaders_queue_count = Invaders.invaders_queue_count - 1;

            invader_health = invader.TakeDamage(bullet_power);
            if(invader_health <= 0){
                hud.AddScore(invader.GetPointsOfInvader(), collision.gameObject);
            }
            Destroy(gameObject);
        }

        InvaderBullet invader_bullet = collision.gameObject.GetComponent<InvaderBullet>();
        if(invader_bullet != null){
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }


        Bird bird = collision.gameObject.GetComponent<Bird>();
        if(bird != null){
            Destroy(gameObject);
            bird.TakeDamage(bullet_power);            
        }

    }

}
