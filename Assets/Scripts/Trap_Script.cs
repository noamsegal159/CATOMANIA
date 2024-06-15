using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Trap_Script : MonoBehaviour
{
    private Vector3 target1;
    private Vector3 target2;
    public int Trap_Damage;

    public float distance;
    public float speed;
    private bool tar1 = true, tar2 = false;
    // Start is called before the first frame update
    void Start() //location of targets
    {
        target1.Set(transform.position.x + distance, transform.position.y, transform.position.z);
        target2.Set(transform.position.x - distance, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update() //movement
    {
        if (transform.position == target1)
        {
            tar1 = false;
            tar2 = true;
        }
        else if (transform.position == target2)
        {
            tar1 = true;
            tar2 = false;
        }
        if (tar1)
            transform.position = Vector3.MoveTowards(transform.position, target1, speed * Time.deltaTime);
        if(tar2)
            transform.position = transform.position = Vector3.MoveTowards(transform.position, target2, speed * Time.deltaTime);
    }
}
