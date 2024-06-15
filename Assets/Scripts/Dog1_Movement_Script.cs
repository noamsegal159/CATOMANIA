using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Dog1_Movement_Script : MonoBehaviour
{
    private GameObject player;
    public float Dog1_Speed;
    public float Sight_Range;
    public float Attack_Sight;

    private float distance;
    public Animator animator;

    public float Attack_Rate = 0.5f;
    private float Attack_Time = 0;
    // Start is called before the first frame update
    void Start() //find player
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update() //Movement
    {
        Vector3 CharacterScale = transform.localScale; //to change the direction the enemy is facing
        distance = Vector2.Distance(transform.position, player.transform.position); 
        Vector2 direction = player.transform.position - transform.position; // direction to the player
        direction.Normalize();

        if (distance < Sight_Range && distance > Attack_Sight && Time.time > Attack_Time) //follow player
        {
            if (direction.x > 0)
            {
                CharacterScale.x = 0.138f;
            }
            if (direction.x < 0)
            {
                CharacterScale.x = -0.138f;
            }
            transform.localScale = CharacterScale; //change enemy facing

            animator.SetFloat("Speed", 5f);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Dog1_Speed * Time.deltaTime);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
        if (distance < Attack_Sight && !animator.GetCurrentAnimatorStateInfo(0).IsName("Damage")) //attack and timer
        { 
            if (Time.time >= Attack_Time)
            {
                Attack_Time = Time.time + 1f / Attack_Rate;
                this.GetComponent<Dog_Attack>().Attack();
            }
        }
    }
}
