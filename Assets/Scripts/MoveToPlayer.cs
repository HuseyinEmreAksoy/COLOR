using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    GameObject player;
    [SerializeField] public float speed = 10.0f;
    private float xDistance, currxDistance;
    private float initScale;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        initScale = transform.localScale.x;
        player = GameObject.Find("Player");
        xDistance = (gameObject.transform.position - player.transform.position).x;
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 distance = player.transform.position - gameObject.transform.position;                                                        
        direction = distance / distance.magnitude;
        
        currxDistance = (gameObject.transform.position - player.transform.position).x;
        float currScale = (currxDistance / xDistance)*initScale;

        transform.localScale = new Vector3(currScale, currScale, currScale);
        transform.Translate(direction * speed * Time.deltaTime);

    }
}
