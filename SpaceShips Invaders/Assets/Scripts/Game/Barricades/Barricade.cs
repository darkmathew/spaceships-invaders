using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{

    int barricade_health;
    int initial_barricade_health;
    Animator animator;

    Vector3 initial_position;

    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    void Start(){
        animator = GetComponent<Animator>();        
        initial_position = transform.position;
        barricade_health = Random.Range(10, 21);
        initial_barricade_health = barricade_health;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        InvaderBullet invader_bullet = collision.gameObject.GetComponent<InvaderBullet>();
        if(invader_bullet != null){
            barricade_health -= 1;
            if(barricade_health <= 0){
                Destroy(gameObject);
            } else if(barricade_health <= (initial_barricade_health / 2)){
                animator.SetBool("take_damage", true);
            }
            Destroy(collision.gameObject);
        }

        Bird bird = collision.gameObject.GetComponent<Bird>();
        if(bird != null){
            barricade_health -= 1;
            if(barricade_health <= 0){
                Destroy(gameObject);
            } else if(barricade_health <= (initial_barricade_health / 2)){
                animator.SetBool("take_damage", true);
            }
            bird.TakeDamage(1);
        }
    }

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }    

}
