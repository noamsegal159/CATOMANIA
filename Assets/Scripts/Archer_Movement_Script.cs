using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Archer_Movement_Script : MonoBehaviour
{
    private GameObject player;
    public float Dog2_Speed;
    public float Sight_Range;
    public float Attack_Range;

    private float distance;
    public Animator animator;

    public float Attack_Rate = 0.6f;
    private float Attack_Time = 0;
    public float Attack_Cooldown;
    private bool flag = false;
    public GameObject Arrow;
    public GameObject Arrow_Generator;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CharacterScale = transform.localScale;
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        Vector3 target = new Vector3();
        target.Set(-1f * direction.x, -1f * direction.y, player.transform.position.z);
        direction.Normalize();

        if (Time.time >= Attack_Cooldown && distance < Sight_Range)
        {
            flag = true;
            Attack_Cooldown = Time.time + 3 * 1f / Attack_Rate;
            Attack_Time = Time.time + 1f / Attack_Rate;
            animator.SetTrigger("Attack");
        }
        if (Time.time > Attack_Time && flag)
        {
            Archer_Attack();
            flag = false;
        }

        if (Time.time > Attack_Time && distance > Sight_Range)
        {
            animator.SetFloat("Speed", 0f);
        }

        if (distance < Sight_Range && Time.time > Attack_Time)
        {
            if (direction.x > 0)
            {
                CharacterScale.x = 0.138f;
            }
            if (direction.x < 0)
            {
                CharacterScale.x = -0.138f;
            }
            transform.localScale = CharacterScale;

            animator.SetFloat("Speed", 5f);
            if (distance > Attack_Range)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Dog2_Speed * Time.deltaTime);
            }
            else if (distance < Sight_Range)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, Dog2_Speed * Time.deltaTime);
            }
        }

        void Archer_Attack()
        {
            if (CharacterScale.x > 0)
            {
                Instantiate(Arrow, Arrow_Generator.transform.position, Arrow_Generator.transform.rotation);
            }
            else
            {
                Instantiate(Arrow, Arrow_Generator.transform.position, Quaternion.Euler(Vector3.forward * (Mathf.Atan2(-1, 0) * Mathf.Rad2Deg)));
            }
        }
    }
}
