using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollisons : MonoBehaviour
{
    [SerializeField] float dropChance = 0.1f; //IMPORTANT: Do not set this var higher than 0.5, if you do, life draps after every kill
    [SerializeField] float time = 0.1f;
    public GameObject heart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Superpower collisons
        if(gameObject.CompareTag("SuperPower"))
        {
            if(other.gameObject.CompareTag("Obstacle"))
            {
                Destroy(other.gameObject);
            }
            else if(other.gameObject.CompareTag("Bullet"))
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                GameObject.Find("Player").GetComponent<PlayerController>().superPowerWhite = true;
            }
        }



        //Heart reaches player
        if(gameObject.CompareTag("Heart") && other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }

        //Bullet hits obstacle
        if(gameObject.CompareTag("Obstacle") && other.gameObject.CompareTag("Bullet"))
        {
            Color bulletColor = other.gameObject.GetComponent<SpriteRenderer>().color;
            Color obstacleColor = gameObject.GetComponent<SpriteRenderer>().color;
            Color newColor;
            
            if(bulletColor == Color.white)
            {
                newColor = Color.white;
            }
            else
            {
                newColor = sumTwoColors(bulletColor, obstacleColor);
                if(IsFalseColor(bulletColor, obstacleColor))
                {
                    GameObject.Find("Player").GetComponent<PlayerController>().FalseColor();
                }
            }
            
            Destroy(other.gameObject); //bullet destroyed
            gameObject.GetComponent<SpriteRenderer>().color = newColor;

            if(newColor == Color.white) //destroys obstacle if its color is white
            {
                if(!DropHealth())
                {
                    GameObject.Find("CloudDies").GetComponent<AudioSource>().Play();
                }
                else
                {
                    Instantiate(heart, this.gameObject.transform.position, this.gameObject.transform.rotation);
                    GameObject.Find("HealthAdded").GetComponent<AudioSource>().Play();
                    GameObject.Find("Player").GetComponent<PlayerController>().IncreaseLife();
                }
                StartCoroutine(waiter());
                GameObject.Find("Player").GetComponent<PlayerController>().EnemyDestroyed();
            }
        }

        //Obstacle reaches the player
        if(gameObject.CompareTag("Obstacle") && other.gameObject.CompareTag("Border"))
        {
            GameObject.Find("Player").GetComponent<PlayerController>().DecreaseLife();
        }
    }

    private Color sumTwoColors(Color c1, Color c2) 
    {
        float r = c1.r + c2.r < 0.9f ? 0 : 1;
        float g = c1.g + c2.g < 0.9f ? 0 : 1;
        float b = c1.b + c2.b < 0.9f ? 0 : 1;
        return new Color(r,g,b,1);
    }

    private bool IsFalseColor(Color bulletColor, Color obstacleColor)
    {
        return ( (bulletColor.r + obstacleColor.r > 1.5f) || (bulletColor.b + obstacleColor.b > 1.5f) || (bulletColor.g + obstacleColor.g > 1.5f) );
    }

    IEnumerator waiter()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        this.gameObject.GetComponent<Animator>().SetBool("dieEnemy", true);
        yield return new WaitForSeconds(time);
        this.gameObject.GetComponent<Animator>().SetBool("dieEnemy", false);
        Destroy(this.gameObject);
        
    }

    private bool DropHealth()
    {
        float chanceOfHealth = (3 - GameObject.Find("Player").GetComponent<PlayerController>().curLife) * dropChance;
        float rand = Random.Range(0.0f,1.0f);
        return (chanceOfHealth > rand);
    }
}
