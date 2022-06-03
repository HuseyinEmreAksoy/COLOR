using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Story()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2); 
    }
}
