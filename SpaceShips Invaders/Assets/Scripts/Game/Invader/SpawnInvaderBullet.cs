using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvaderBullet : MonoBehaviour
{
    [SerializeField] GameObject prefab_bullet = null;

    float time_next_shot;

    void Start(){
        time_next_shot = Random.Range(1, 4);        
    }

    void Update(){
        SpawnBullet();      
    }

    void SpawnBullet(){
        time_next_shot -= Time.deltaTime;
        if(time_next_shot <= 0){
            Instantiate(prefab_bullet, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            time_next_shot = Random.Range(1, 4);
        }
    }

}
