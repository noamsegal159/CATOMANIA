using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Script : MonoBehaviour
{
    public int Max_Health = 100;
    public int Curr_Health;
    public Animator animator;
    private bool Tag;

    public int DropHealPercent;
    public int DropSpeedPercent;
    public int DropImmunityPercent;

    private bool timer_start = false;
    public float timer;

    public GameObject Heal_Potion;
    public GameObject Speed_Potion;
    public GameObject Immunity_Potion;
    public int Collision_Damage;

    // Start is called before the first frame update
    void Start() //reset health and diffrenciate enemy type
    {
        Curr_Health = Max_Health;
        if (this.tag == "Dog1")
            Tag = true;
    }

    // Update is called once per frame
    void Update() //check if the enemy took damage, died or drop loot
    {
        if (timer_start) //enemy is dead
        {
            if (timer < 0)
                DropLoot();
            timer = timer - 1f * Time.deltaTime;
        }
    }

    public void TakeDamage(int damage) //take damage
    {
        Curr_Health -= damage;
        if (this.Curr_Health <= 0)
        {
            Death();
        }
        else
        {
            animator.SetTrigger("Damage");
        }
    }

    void Death() //death start timer
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Cat_Controller>().AddScore();

        //animation
        animator.SetBool("IsDead", true);

        //Disable
        this.GetComponent<Collider2D>().enabled = false;
        if (Tag)
            this.GetComponent<Dog1_Movement_Script>().enabled = false;
        else
            this.GetComponent<Archer_Movement_Script>().enabled = false;
        timer_start = true;
    }
    void DropLoot() //loot + destroy
    {
        int chance = Random.Range(0, 100);
        if(0<= chance && chance < DropHealPercent)
        {
            Instantiate(Heal_Potion, transform.position, transform.rotation);
        }
        else if(DropHealPercent<=chance&& chance < DropHealPercent+DropSpeedPercent)
        {
            Instantiate(Speed_Potion, transform.position, transform.rotation);
        }
        else if(DropHealPercent + DropSpeedPercent <= chance && chance < DropHealPercent + DropSpeedPercent + DropHealPercent + DropImmunityPercent)
        {
            Instantiate(Immunity_Potion, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
