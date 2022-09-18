using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenuSpaceships : MonoBehaviour
{
    public GameObject prefab_spaceship;
    float time_min_spawn = 1.6f;
    float time_max_spawn = 6f;

    void Start(){
        // Invoca o método SpawnSpaceship em X segundos de tempo e, em seguida, repetidamente a cada Y segundos.
        InvokeRepeating("SpawnSpaceship", Random.Range(time_min_spawn, time_max_spawn), Random.Range(time_min_spawn, time_max_spawn));
    }

    void SpawnSpaceship(){
        Instantiate(prefab_spaceship, transform.position, Quaternion.identity);
    }

}
