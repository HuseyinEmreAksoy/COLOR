using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstacle;
    [SerializeField] public float yBound = 4.0f; //Update PlayerController script if change is needed
    [SerializeField] public float xPos = 10.0f, zPos = 0.0f;
    [SerializeField] public float startingDelay = 2.5f, intervalDelay =  1.5f;
    private Color[] colors= {Color.red, Color.green, Color.blue, Color.yellow, Color.magenta, Color.cyan, Color.black}; // red green blue yellow(r+g) pink(r+b) cyan(g+b) black  Size = 7

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startingDelay, intervalDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawns random obstacle from obstacles array
    void SpawnObstacle(){
            float yPos = Random.Range((int)-yBound,(int)yBound);
            int randColorIndex = Random.Range(0,7);
            Vector3 pos = new Vector3(xPos, yPos, zPos);
            GameObject toGo = Instantiate(obstacle, pos, obstacle.transform.rotation);
            toGo.gameObject.GetComponent<SpriteRenderer>().color = colors[randColorIndex];
    }
}
