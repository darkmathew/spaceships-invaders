using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerBullet : MonoBehaviour
{
    [SerializeField] GameObject prefab_bullet = null;
    [SerializeField] GameObject gun_barrel = null;

    AudioSource audio_source;
    float time_next_shot = 0.2f;

    void Start() {
        audio_source = GetComponent<AudioSource>();    
    }

    void Update(){
        SpawnBullet();      
    }

    void SpawnBullet(){
        time_next_shot -= Time.deltaTime;
        if(Input.GetButtonDown("Fire1") && time_next_shot <= 0){
            audio_source.Play();
            Instantiate(prefab_bullet, new Vector2(gun_barrel.transform.position.x, gun_barrel.transform.position.y), Quaternion.identity);
            time_next_shot = 0.2f;
        }
    }


}
