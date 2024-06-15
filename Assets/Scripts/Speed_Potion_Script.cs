using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Potion_Script : MonoBehaviour
{
    public float Speed_mult;
    private float speed;
    private float sprint;
    public float timer;
    public bool active = false;
    public void StartTimer() //mult speed and start the timer
    {
        speed = GameObject.FindWithTag("Player").GetComponent<MovementScript>().PlayerSpeed;
        sprint = GameObject.FindWithTag("Player").GetComponent<MovementScript>().SprintSpeed;

        GameObject.FindWithTag("Player").GetComponent<MovementScript>().PlayerSpeed = speed * Speed_mult;
        GameObject.FindWithTag("Player").GetComponent<MovementScript>().SprintSpeed = sprint * Speed_mult;
        timer = timer + Time.time;
        active = true;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update() //check if timer is over and destory
    {
        if (active)
        {
            if(Time.time > timer)
            {
                GameObject.FindWithTag("Player").GetComponent<MovementScript>().PlayerSpeed = GameObject.FindWithTag("Player").GetComponent<MovementScript>().PlayerSpeed / Speed_mult;
                GameObject.FindWithTag("Player").GetComponent<MovementScript>().SprintSpeed = GameObject.FindWithTag("Player").GetComponent<MovementScript>().SprintSpeed / Speed_mult;
                Destroy(gameObject);
            }
        }
    }
}
