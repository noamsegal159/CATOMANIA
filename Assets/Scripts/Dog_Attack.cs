using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Attack : MonoBehaviour
{
    public Animator animator;
    public Transform Attack_Point;
    public LayerMask Player_Layer;


    public float Attack_Range = 0.4f;
    public int Attack_Damage = 25;

    
    public void Attack() //attack
    {
        this.GetComponent<Dog1_Movement_Script>().enabled = false;
        animator.SetTrigger("Attack");

        Collider2D[] Hit_Player = Physics2D.OverlapCircleAll(Attack_Point.position, Attack_Range, Player_Layer); //array of hit objects within the range
        foreach (Collider2D player in Hit_Player)
        {
            player.GetComponent<Cat_Controller>().TakeDamage(Attack_Damage);
        }

        this.GetComponent<Dog1_Movement_Script>().enabled = true;
    }
}
