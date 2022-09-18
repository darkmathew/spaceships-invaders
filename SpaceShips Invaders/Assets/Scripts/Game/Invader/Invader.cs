using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Invader : MonoBehaviour
{

    private Animator animator;
    private int invader_health;

    string animation_var_name;

    public GameObject identifier;
    int multiplier;
    int spaceship_multiplier;

    Scene scene;
    string scene_name;

    void Start(){
        
        animator = GetComponent<Animator>();
        transform.eulerAngles = new Vector3(0, 0, -180);

        scene = SceneManager.GetActiveScene();
        scene_name = scene.name;

        SetHealthMultiplier();
        SetSpaceShipHealth();

    }

    void EnableAnimation(string animation_bool_variable){
        animation_var_name = animation_bool_variable;
        animator.SetBool(animation_var_name, true);
        Invoke("DisableAnimation", 0.5f);
    }

    void DisableAnimation(){
        animator.SetBool(animation_var_name, false);
    }

    void Update(){
    }

    void SetHealthMultiplier(){
        if(scene_name == "ForestFase"){
            multiplier = 1;

        } else if(scene_name == "DesertFase"){
            multiplier = 2;

        //} else if(scene_name == "SnowFase"){
        //    multiplier = 3;

        } else{
            multiplier = 4;
        }
    }

    void SetSpaceShipHealth(){        
        if(name.Contains("gray_sp")){
            spaceship_multiplier = 1;
            this.invader_health = spaceship_multiplier * multiplier;

        } else if(name.Contains("green_sp")){
            spaceship_multiplier = 3;
            this.invader_health = spaceship_multiplier * multiplier;

        } else if(name.Contains("red_sp")){
            spaceship_multiplier = 5;
            this.invader_health = spaceship_multiplier * multiplier;

        } else if(name.Contains("big_purple_sp")){
            spaceship_multiplier = 10;
            this.invader_health = spaceship_multiplier * multiplier;

        } else if(name.Contains("big_yellow_sp")){
            spaceship_multiplier = 20;
            this.invader_health = spaceship_multiplier * multiplier;

        } else{
            print("Nave invasora não identificada");
            spaceship_multiplier = 0;
            this.invader_health = spaceship_multiplier * multiplier;
        }
    }

    public int TakeDamage(int damage){
        invader_health -= damage;
        if(invader_health <= 0){
            Destroy(gameObject);
        }
        return this.invader_health;
    }


    public int GetInvaderHealth(){
        return this.invader_health;
    }

    public int GetPointsOfInvader(){
        return spaceship_multiplier * 10;
    }

    public int GetInvaderMultiplier(){
        return this.multiplier;
    }

}
