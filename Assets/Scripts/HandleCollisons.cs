using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollisons : MonoBehaviour
{
    [SerializeField] float time = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {

        //Bullet hits obstacle
        if(other.gameObject.CompareTag("Bullet"))
        {
            Color bulletColor = other.gameObject.GetComponent<SpriteRenderer>().color;
            Color obstacleColor = gameObject.GetComponent<SpriteRenderer>().color;
            Color newColor = sumTwoColors(bulletColor, obstacleColor);
            gameObject.GetComponent<SpriteRenderer>().color = newColor;
            
            Destroy(other.gameObject); //bullet destroyed

            if(newColor == Color.white) //destroys obstacle if its color is white
            {
                Debug.Log("hiiit");
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                StartCoroutine(waiter());
               
            }
        }

        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    private Color sumTwoColors(Color c1, Color c2) 
    {
        float r = c1.r + c2.r < 1 ? (c1.r + c2.r) : 1;
        float g = c1.g + c2.g < 1 ? (c1.g + c2.g) : 1;
        float b = c1.b + c2.b < 1 ? (c1.b + c2.b) : 1;
        return new Color(r,g,b,1);
    }
    IEnumerator waiter()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
