using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Potion_Script : MonoBehaviour
{
    public float health_max;
    public float health_min;
    
    private void Start() //determine max health value and min health value
    {
        health_min = health_min * GameObject.FindWithTag("Player").GetComponent<Cat_Controller>().Max_Health;
        health_max = health_max * GameObject.FindWithTag("Player").GetComponent<Cat_Controller>().Max_Health;
    }

    public void DestroyPotion() // destroy potion
    {
        Destroy(gameObject);
    }
}
