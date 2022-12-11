using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  

public class SceneSwitcher: MonoBehaviour {  
    public void Game() {  
        SceneManager.LoadScene("Game");  
    }  
    public void Start() {  
        SceneManager.LoadScene("Start");  
    }  
    public void Death() {  
        SceneManager.LoadScene("Death");  
    } 
    public void Victory() {  
        SceneManager.LoadScene("Victory");  
    }
    public void SecretEnding() {  
        SceneManager.LoadScene("SecretEnding");  
    }  
}