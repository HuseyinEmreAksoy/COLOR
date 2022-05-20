using System;
using System.Collections;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    public float speed = 5.0f;
    public GameObject[] bullets = new GameObject[3];  //Red Green Blue Bullets
    public float yBound = 4.0f;
    public float xPos = -7.0f;
    [SerializeField] float impactTime = 0.3f;


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
  

        if (Input.GetKeyDown(KeyCode.Z))
        {                                                //Spawns RED bullet with Z
            Instantiate(bullets[0], gameObject.transform.position, gameObject.transform.rotation);
            ShowImpact(bullets[0]);


        }
        if (Input.GetKeyDown(KeyCode.X))
        {                                               //Spawns GREEN bullet with X
            Instantiate(bullets[1], gameObject.transform.position, gameObject.transform.rotation);;
            ShowImpact(bullets[1]);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {                                                //Spawns BLUE bullet with C
            Instantiate(bullets[2], gameObject.transform.position, gameObject.transform.rotation);
            ShowImpact(bullets[2]);
        }

        //Prevent player to cross y bounds
        if (transform.position.y < -yBound || transform.position.y > yBound)
        {
            Vector3 limit = new Vector3(xPos, (float)Math.Round(transform.position.y), 0.0f);
            transform.position = limit;
        }

    }
    public void ShowImpact(GameObject a)
    {
        
        StartCoroutine(ShowSplatter(a));
        

    }
    IEnumerator ShowSplatter(GameObject a)
    {
        a.SetActive(false);
        yield return new WaitForSeconds(impactTime);
        a.SetActive(true);

    }
}
