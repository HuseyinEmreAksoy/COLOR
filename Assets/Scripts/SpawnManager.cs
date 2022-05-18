using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstacle;
    public float yBound = 4.0f; //Update PlayerController script if change is needed
    public float xPos = 10.0f, zPos = 0.0f;
    public float startingDelay = 2.5f, intervalDelay =  1.5f;
    private Color[] colors= {Color.black, Color.red, Color.green, Color.blue, Color.white}; //Size = 5

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startingDelay, intervalDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle(){
            float yPos = Random.Range((int)-yBound,(int)yBound);
            Vector3 pos = new Vector3(xPos, yPos, zPos);
            Instantiate(obstacle, pos, obstacle.transform.rotation);
    }
}
