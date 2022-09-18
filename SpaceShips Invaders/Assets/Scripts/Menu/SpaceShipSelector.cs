using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipSelector : MonoBehaviour
{
    public GameObject[] spaceships;
    [SerializeField] float speed = 1.8f;

    void Start()
    {
        SetSpaceShipVelocity();
        EnableSpaceShip();     
    }

    private void Update()
    {
        DestroyShipIfLeftScreen();
    }

    void SetSpaceShipVelocity(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed); 
    }

    void EnableSpaceShip(){
        spaceships[Random.Range(0, 6)].SetActive(true);
    }

    void DestroyShipIfLeftScreen()
    {
        if (transform.position.y < -6f || transform.position.y > 6f)
        {
           Destroy(gameObject);
        }
    }
}
