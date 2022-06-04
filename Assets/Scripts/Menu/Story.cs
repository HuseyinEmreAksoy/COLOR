using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Story : MonoBehaviour
{
    float timeLeft = 34.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            SceneManager.LoadScene(0);
        }

    }
}
