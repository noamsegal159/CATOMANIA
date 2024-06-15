using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private GameObject player;
    public float Arrow_Speed;
    private float distance;
    public float fluc;
    public float timer;

    private Vector2 direction;
    private Vector3 Target;
    public int Arrow_Damage = 25;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Target.Set(player.transform.position.x + Random.Range(-1 * fluc, fluc), player.transform.position.y + Random.Range(-1 * fluc, fluc), player.transform.position.z);
        distance = Vector2.Distance(transform.position, Target);
        direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        transform.position  = Vector3.MoveTowards(transform.position, player.transform.position, Arrow_Speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Target);
        if(distance == 0)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            if (timer < 0)
                DestroyArrow();
            else
                timer = timer - 1f * Time.deltaTime;
        }
        transform.position = Vector3.MoveTowards(transform.position, Target, Arrow_Speed * Time.deltaTime);
    }

    public void DestroyArrow()
    {
        this.GetComponent<Arrow>().enabled = false;
        Destroy(gameObject);
    }
}
