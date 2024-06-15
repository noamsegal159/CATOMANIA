using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immunity_Potion_Script : MonoBehaviour
{
    public float timer;
    public bool active;
    public void StartTimer() //Start immunity period
    {
        GameObject.FindWithTag("Player").GetComponent<Cat_Controller>().immune = true;
        timer = timer + Time.time;
        active = true;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
    }
   
    // Update is called once per frame
    void Update() //check if immunity period is over and destroy
    {
        if (active)
        {
            if (Time.time > timer)
            {
                GameObject.FindWithTag("Player").GetComponent<Cat_Controller>().immune = false;
                GameObject.FindWithTag("Player").GetComponent<Cat_Controller>().Health_Bar.color = Color.green;
                Destroy(gameObject);
            }
        }
    }
}
