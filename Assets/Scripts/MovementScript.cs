using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float PlayerSpeed;
    private float XInput;
    private float YInput;
    public float SprintSpeed;
    private bool isSprint;

    public GameObject TopRightBorder;
    public GameObject BottomLeftBorder;

    public Animator animator;

    // Update is called once per frame
    void Update() //Movement logic
    {
        Vector3 CharacterScale = transform.localScale; //direction player is facing
        XInput = Input.GetAxis("Horizontal");
        YInput = Input.GetAxis("Vertical");
        isSprint = Input.GetKey(KeyCode.LeftShift);

        //direction
        if (XInput > 0)
        {
            CharacterScale.x = 1;
        }
        if (XInput < 0)
        {
            CharacterScale.x = -1;
        }
        transform.localScale = CharacterScale;

        //border
        if(transform.position.x <= BottomLeftBorder.transform.position.x && XInput < 0)
        {
            XInput = 0;
        }
        if (transform.position.x >= TopRightBorder.transform.position.x && XInput > 0)
        {
            XInput = 0;
        }
        if (transform.position.y <= BottomLeftBorder.transform.position.y && YInput < 0)
        {
            YInput = 0;
        }
        if (transform.position.y >= TopRightBorder.transform.position.y && YInput > 0)
        {
            YInput = 0;
        }



        //move
        if (isSprint)
        {
            animator.SetFloat("Speed", Mathf.Abs(XInput));
            if (XInput != 0 && YInput != 0)
            {
               Move(SprintSpeed / 1.4f, YInput, XInput);
            }
            else
                Move(SprintSpeed, YInput, XInput);
        }
        else
        {
            animator.SetFloat("Speed", 0);
            if (XInput != 0 && YInput != 0)
            {
                Move(PlayerSpeed / 1.3f, YInput, XInput);
            }
            else
                Move(PlayerSpeed, YInput, XInput);
        }

    }
    void Move(float Speed, float YInput, float XInput) //Movement
    {
        transform.Translate(Vector3.up * Time.deltaTime * Speed * YInput);
        transform.Translate(Vector3.right * Time.deltaTime * Speed * XInput);
    }

}
