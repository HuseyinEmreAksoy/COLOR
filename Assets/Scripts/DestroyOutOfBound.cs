using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{

    [SerializeField] public float xBoundLeft = -10, xBoundRight = 10;
    [SerializeField] public float yLowerBound = -4.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if(pos.x < xBoundLeft || pos.x > xBoundRight)
        {
            Destroy(this.gameObject);       
        }
        
        if(pos.y < yLowerBound && gameObject.CompareTag("SuperPower"))
        {
            Destroy(this.gameObject);
        }
        
    }
}