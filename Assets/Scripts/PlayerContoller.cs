using System;
using System.Collections;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    public float speed = 5.0f;
    public GameObject[] bullets = new GameObject[3];  //Red Green Blue Bullets
    public float yBound = 4.0f;
    public float xPos = -7.0f;
    [SerializeField] public float impactTime = 0.5F;
    [SerializeField] private float nextFire = 0.0F;
 


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(xPos, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        float input = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(0.0f, 1.0f, 0.0f);
        transform.Translate(direction * speed * Time.deltaTime * input);
  

        if (Input.GetKeyDown(KeyCode.Z) && Time.time > nextFire)
        {                                               //Spawns RED bullet with Z
            nextFire = Time.time + impactTime;
            Instantiate(bullets[0], gameObject.transform.position, gameObject.transform.rotation);
            GetComponent<Animator>().SetBool("attack", true);

        }
        else if (Input.GetKeyDown(KeyCode.X) && Time.time > nextFire)
        {                                               //Spawns GREEN bullet with X
            nextFire = Time.time + impactTime;
            Instantiate(bullets[1], gameObject.transform.position, gameObject.transform.rotation);;
            GetComponent<Animator>().SetBool("attack", true);
        }
       else if (Input.GetKeyDown(KeyCode.C) && Time.time > nextFire)
        {                                                //Spawns BLUE bullet with C
            nextFire = Time.time + impactTime;
            Instantiate(bullets[2], gameObject.transform.position, gameObject.transform.rotation);
            GetComponent<Animator>().SetBool("attack", true);
        }
        else
            GetComponent<Animator>().SetBool("attack", false);
        //Prevent player to cross y bounds
        if (transform.position.y < -yBound || transform.position.y > yBound)
        {
            Vector3 limit = new Vector3(xPos, (float)Math.Round(transform.position.y), 0.0f);
            transform.position = limit;
        }

    }

}
