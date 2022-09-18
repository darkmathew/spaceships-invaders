using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Hud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _lifeText;
    [SerializeField] TextMeshProUGUI _timerText;
    [SerializeField] TextMeshProUGUI _missionText;
    [SerializeField] GameObject[] spawnInvaders;

    Scene current_scene;
    string scene_name;

    Animator hud_animator;
    AudioSource audioSource;

    float spaceship_life = 50;
    float score = 0; 
    string animation_var_name;


    // Missões
    Stack<int> mission_stack = new Stack<int>();
    float mission_seconds = 40;
    bool mission_is_active = true;
    bool can_update_text = true;
    int current_mission_counter = 0;

    void Start(){
        
        audioSource = GetComponent<AudioSource>();
        
        hud_animator = GameObject.Find("heart").GetComponentInChildren<Animator>();
        
        _scoreText.text = "Placar: "+ score.ToString();
        
        current_scene = SceneManager.GetActiveScene();
        scene_name = current_scene.name;

        GetMissions();
    }

    void Update() {

        SetMissionTimer();
        CheckIfGameOver();
        CheckIfGameWin();
        HandleMission();

        _lifeText.text = spaceship_life.ToString();  

        if(can_update_text){
            _missionText.text = "Destrua " + mission_stack.Peek().ToString() + " naves -- Destruiu: " + current_mission_counter.ToString();  
        } 
          
    }

    void GetMissions(){

        if(scene_name == "ForestFase"){
            for(int i = 0; i < Random.Range(2, 3); i++){
                mission_stack.Push(Random.Range(1, 4));
            }
        } else if(scene_name == "DesertFase"){
            for(int i = 0; i < Random.Range(3, 8); i++){
                mission_stack.Push(Random.Range(2, 6));
            }
        } else if(scene_name == "SnowFase"){
            for(int i = 0; i < Random.Range(6, 10); i++){
               mission_stack.Push(Random.Range(3, 8));
            }
        } 
    }

    void HandleMission(){
    
        if(mission_stack.Count == 0){ 
            _missionText.text = "Parabéns, você completou as missões!";          
            Invoke("LoadNextLevel", 1f);

        } else if(current_mission_counter >= mission_stack.Peek()){
            if(mission_stack.Count > 0){
                mission_stack.Pop();
            }
            current_mission_counter = 0;
            mission_seconds = 40;
            mission_is_active = true;
            RespawnEnemies();
        } 

        if(GameObject.FindGameObjectsWithTag("enemy_sp").Length < mission_stack.Peek()){
            Invoke("LoadNextLevel", 0.7f);
        }
    }

    void RespawnEnemies(){
        foreach(GameObject invader in spawnInvaders){
            invader.GetComponent<Invaders>().RespawnInvaders();           
        }
    }


    void CheckIfGameWin(){
        if(scene_name == "ForestFase"){
            if(score >= 500 && !mission_is_active){
                LoadNextLevel();
            }
        } else if(scene_name == "DesertFase"){
            if(score >= 700 && !mission_is_active){
                LoadNextLevel();
            }
        } else if(scene_name == "SnowFase"){
            if(score >= 1000 && !mission_is_active){
                LoadNextLevel();
            }
        } 
    }

    void CheckIfGameOver(){
        if(mission_seconds <= 0){
            mission_is_active = false;
            Invoke("LoadNextSceneGameOver", 0.8f);   
        }

        if(spaceship_life <= 0){
            Invoke("LoadNextSceneGameOver", 0.8f);   
        }
    }

    public void InstantGameOver(){
        Invoke("LoadNextSceneGameOver", 0.2f); 
    }

    void LoadNextSceneGameOver(){
        SceneManager.LoadScene("GameOver");
    }

    void LoadNextLevel(){
        if(scene_name == "ForestFase"){
            SceneManager.LoadScene("DesertFase");

        } else if(scene_name == "DesertFase"){
            SceneManager.LoadScene("SnowFase");

        } else{
            SceneManager.LoadScene("EndGame");
        }
    }

    void SetMissionTimer(){
        if(mission_seconds > 0 && mission_is_active){
            mission_seconds -= Time.deltaTime;
        } else{
            mission_seconds = 0;
        }
        _timerText.enabled = mission_is_active;
        if(_timerText.enabled){
            _timerText.text = "Tempo restante: " + Mathf.Round(mission_seconds);           
        }
            
    }

    void EnableAnimation(string animation_bool_variable){
        animation_var_name = animation_bool_variable;
        hud_animator.SetBool(animation_var_name, true);
        Invoke("DisableAnimation", 0.5f);
    }

    void DisableAnimation(){
        hud_animator.SetBool(animation_var_name, false);
    }

    public void AddScore(int points, GameObject current_invader){
        score += points;
        current_mission_counter += 1;     
        _scoreText.text = "Placar: "+ score.ToString();  
    }

    public void RemoveLife(float damage){
        spaceship_life = Mathf.Clamp(spaceship_life -= damage, 0, 100);
        EnableAnimation("enable_pulse");
    }

    public void AddLife(float life){
        audioSource.Play();
        spaceship_life = Mathf.Clamp(spaceship_life += life, 0, 100);
        EnableAnimation("enable_pulse");
    }

}
