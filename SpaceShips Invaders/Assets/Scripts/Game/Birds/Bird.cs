using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    int bird_health;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1.9f);    
        bird_health = Random.Range(2, 7);
    }

    void Update(){
        DestroyBirdIfLeftScreen();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Hud player = other.gameObject.GetComponent<Hud>();
        if(player != null){
            Destroy(gameObject);
            player.InstantGameOver();                    
        }    
    }

    void DestroyBirdIfLeftScreen(){
        if (transform.position.y < -6f || transform.position.y > 6f)
        {
           Destroy(gameObject);
        }        
    }

    public void TakeDamage(int damage){
        bird_health -= damage;
        if(bird_health <= 0){
            Destroy(gameObject);
        }        
    }

}
