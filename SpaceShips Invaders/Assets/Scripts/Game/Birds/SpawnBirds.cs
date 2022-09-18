using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBirds : MonoBehaviour
{
    [SerializeField] GameObject[] birds = null;
    int currentIndex;
    void Start(){
        currentIndex = Random.Range(0, 3);
        birds[currentIndex].SetActive(true);
        InvokeRepeating("SpawnBullet",  Random.Range(0, 2), Random.Range(2, 8));
    }


    void SpawnBullet(){
        Instantiate(birds[currentIndex], new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
    }
}
