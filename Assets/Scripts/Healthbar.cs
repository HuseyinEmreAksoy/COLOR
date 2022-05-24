using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private PlayerContoller playerHealth;
    [SerializeField] private Image totalHealth;
    [SerializeField] private Image currHealth;

    // Start is called before the first frame update
    void Start()
    {
        totalHealth.fillAmount = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        currHealth.fillAmount = (float)playerHealth.curLife / 10;
    }
}
