using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Script : MonoBehaviour
{
    public Animator animator;
    public Transform Attack_Point;
    public LayerMask Enemy_Layers;


    public float Attack_Range = 7.5f;
    public int Attack_Damage = 25;
    public float Attack_Rate = 2f;
    private float Attack_Time = 0;

    void Update()
    {
        if (Time.time >= Attack_Time) //timer
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                Attack_Time = Time.time + 1f / Attack_Rate;
            }
        }
    }

    void Attack()
    {
        //animation
        animator.SetTrigger("Attack1");

        //detection
        Collider2D[] Hit_Enemies = Physics2D.OverlapCircleAll(Attack_Point.position, Attack_Range, Enemy_Layers);
        //damage
        foreach(Collider2D enemy in Hit_Enemies)
        {
            enemy.GetComponent<Enemy_Script>().TakeDamage(Attack_Damage);
        }
    }
}
