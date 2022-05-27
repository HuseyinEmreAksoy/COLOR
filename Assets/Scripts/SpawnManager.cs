using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int level = 1;
    
    public GameObject obstacle, superPower_white;

    private float yLowerBound, yUpperBound;
    private float xPos = 10.0f, zPos = 0.0f;
    [SerializeField] float startingDelay = 2.5f, intervalDelay =  3f;

    private Color[] colors= {Color.red, Color.green, Color.blue, new Color(1,1,0,1), Color.magenta, Color.cyan, Color.black}; // red green blue yellow(r+g) pink(r+b) cyan(g+b) black  Size = 7
    [SerializeField] public float levelDuration = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        yUpperBound = playerController.yUpperBound;
        yLowerBound = playerController.yLowerBound;

        InvokeRepeating("LevelUp", levelDuration + startingDelay, levelDuration);
        InvokeRepeating("SpawnObstacle", startingDelay, intervalDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Spawns random obstacle from obstacles array
    void SpawnObstacle(){
            float yPos = Random.Range(yLowerBound, yUpperBound);
            int randColorIndex = Random.Range(0,7);
            Vector3 pos = new Vector3(xPos, yPos, zPos);
            GameObject toGo = Instantiate(obstacle, pos, obstacle.transform.rotation);
            toGo.gameObject.GetComponent<SpriteRenderer>().color = colors[randColorIndex];
    }

    void LevelUp(){
        Time.timeScale *= 1.20f;
        level++;
        DropSuperPower();
    }

    void DropSuperPower(){
        float randXPos = Random.Range(-4.0f, 8.0f);
        Vector3 pos = new Vector3( randXPos, yUpperBound + 1.0f ,0);
        Instantiate(superPower_white, pos, superPower_white.transform.rotation);
    }
}
