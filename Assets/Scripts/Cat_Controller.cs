using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cat_Controller : MonoBehaviour
{
    public float Max_Health = 100f;
    public float Curr_Health;
    public Animator animator;
    public bool immune = false;

    public Image Health_Bar;
    public TextMeshProUGUI Score;
    public int score = 0;

    public float death_timer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //reset health
        Curr_Health = Max_Health;
    }

    // Update is called once per frame
    void Update()
    {
        if (death_timer > 0 && death_timer < 3) //check death
        {
            death_timer = death_timer -1f * Time.deltaTime;
        }
        else if (death_timer < 0)
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }
    public void AddScore() //Add Score 
    {
        score = score + 10;
        Score.text = "SCORE: " + score;
    }

    public void TakeDamage(int damage) //Take Damage
    {
        if (!immune)
        {
            Curr_Health -= damage;
            Health_Bar.fillAmount = Curr_Health / 100f;
            //animation
            if (Curr_Health <= 0)
            {
                Death();
            }
            else
            {
                animator.SetTrigger("Damage");
            }
        }
    }
    public void TakeDamageTrap(int damage) //Take Damage from a Trap (sped up animation)
    {
        if (!immune)
        {
            Curr_Health -= damage;
            Health_Bar.fillAmount = Curr_Health / 100f;
            //animation
            if (Curr_Health <= 0)
            {
                Death();
            }
            else
            {
                animator.SetTrigger("Damage");
            }
        }
    }
    void Death() //Death
    {
        //animation
        animator.SetBool("IsDead", true);

        //score
        StaticData.score = score;

        //Destroy
        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<MovementScript>().enabled = false;
        this.GetComponent<Attack_Script>().enabled = false;
        death_timer = 2.99f;
    }
    
    private void OnTriggerEnter2D(Collider2D collision) //Checking collisions with boosters, arrows
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            TakeDamage(collision.gameObject.GetComponent<Arrow>().Arrow_Damage);
            collision.gameObject.GetComponent<Arrow>().DestroyArrow();
        }

        else if (collision.gameObject.CompareTag("Health Potion"))
        {
            Curr_Health = Curr_Health + Random.Range(collision.gameObject.GetComponent<Health_Potion_Script>().health_min, collision.gameObject.GetComponent<Health_Potion_Script>().health_max);
            if (Curr_Health > Max_Health)
                Curr_Health = Max_Health;
            Health_Bar.fillAmount = Curr_Health / 100f;
            collision.gameObject.GetComponent<Health_Potion_Script>().DestroyPotion();
        }

        else if (collision.gameObject.CompareTag("Speed Potion"))
        {
            collision.gameObject.GetComponent<Speed_Potion_Script>().StartTimer();
        }

        else if (collision.gameObject.CompareTag("Immunity Potion"))
        {
            Health_Bar.color = Color.yellow;
            collision.gameObject.GetComponent<Immunity_Potion_Script>().StartTimer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //checking collision with enemies or traps
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            TakeDamageTrap(collision.gameObject.GetComponent<Trap_Script>().Trap_Damage);
        }

        if (collision.gameObject.CompareTag("Dog1") || collision.gameObject.CompareTag("Dog2"))
        {
            TakeDamageTrap(collision.gameObject.GetComponent<Enemy_Script>().Collision_Damage);
        }
    }
    private void OnCollisionStay2D(Collision2D collision) //checking collision with enemies or traps
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            TakeDamageTrap(collision.gameObject.GetComponent<Trap_Script>().Trap_Damage);
        }
    }
}
