using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    [SerializeField] GameObject[] invaders = null;
    int currentIndex;
    
    Queue<GameObject> invaders_queue = new Queue<GameObject>();
    GameObject invader;

    public static int invaders_queue_count = 0;

    void Start(){
        SpawnSpaceship();
        invaders_queue_count = invaders_queue.Count;
    }

    void SpawnSpaceship(){
        
        for(int i = 0; i < 3; i++){
            invader = invaders[Random.Range(0, 4)];
            invader.SetActive(true);            
            
            GameObject inv = Instantiate(invader, transform.position, Quaternion.identity);
            invaders_queue.Enqueue(inv);
            
            inv.GetComponent<Invader>().identifier = gameObject;
        }
        OrganizeInvaders();
        invaders_queue_count = invaders_queue.Count;
    }    

    void OrganizeInvaders(){
        int index = 0;
        foreach(GameObject invaderQueue in invaders_queue){
            invaderQueue.transform.position = new Vector3(invaderQueue.transform.position.x, transform.position.y - (invaders_queue.Count - index) + 0.5f, 0);
            index++;
        }
    }


    public void RespawnInvaders(){
        SpawnSpaceship();
    }


}
