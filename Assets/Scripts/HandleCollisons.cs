using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollisons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);    
            Debug.Log(gameObject.GetComponent<SpriteRenderer>().color.ToString());
        }
    }
}
