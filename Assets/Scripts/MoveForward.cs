using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    [SerializeField] public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0.0f, -180.0f, 0.0f, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(-1.0f,0,0);
        transform.Translate(direction * Time.deltaTime * speed);
        
    }
}
