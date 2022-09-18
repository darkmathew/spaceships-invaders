using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceShip : MonoBehaviour
{
    Animator animator; 
    Vector2 direction;
    Rigidbody2D spaceship_rb;

    [SerializeField] float speed = 5f;

    [Header("Limites da tela")]
    [SerializeField] float leftbound = -26.97f;
    [SerializeField] float rightbound = -12.43f;

    bool left_bound_collided;
    bool right_bound_collided;


    void Start(){
        spaceship_rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update(){
        MoveSpaceship();
    }

    void MoveSpaceship(){

        left_bound_collided = transform.position.x < leftbound;
        right_bound_collided = transform.position.x > rightbound;

        if(!left_bound_collided && !right_bound_collided){

            direction = new Vector2(Input.GetAxis("Horizontal"), spaceship_rb.velocity.y);
            transform.Translate(direction * speed * Time.deltaTime);

        } else{
            
            if(left_bound_collided){
                transform.position = new Vector2(leftbound, transform.position.y);

            } else{
                transform.position = new Vector2(rightbound, transform.position.y);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        InvaderBullet invader_bullet = collision.gameObject.GetComponent<InvaderBullet>();
        if(invader_bullet != null){    
            GetComponent<Hud>().RemoveLife(1);     
        }
    }

}
