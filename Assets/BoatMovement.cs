using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float moveSpeeds = 5f;
    public Rigidbody2D rba;
    Vector2 movement;
    public Animator a;
    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        a.SetFloat("Horizontal", movement.x);
        a.SetFloat("Vertical", movement.y);
        a.SetFloat("Speed", movement.sqrMagnitude);

        if(a.GetFloat("Horizontal") == 1)
        {
            a.SetBool("Right", true);
            a.SetBool("Left", false);
            a.SetBool("Down", false);
            a.SetBool("Up", false);
        }
        if(a.GetFloat("Horizontal") == -1)
        {
            a.SetBool("Right", false);
            a.SetBool("Left", true);
            a.SetBool("Down", false);
            a.SetBool("Up", false);
        }
        if(a.GetFloat("Vertical") == 1)
        {
            a.SetBool("Right", false);
            a.SetBool("Left", false);
            a.SetBool("Down", false);
            a.SetBool("Up", true);
        }
        if(a.GetFloat("Vertical") == -1)
        {
            a.SetBool("Right", false);
            a.SetBool("Left", false);
            a.SetBool("Down", true);
            a.SetBool("Up", false);
        }
    }
    void FixedUpdate()
    {
        //Movement
        rba.MovePosition(rba.position + movement * moveSpeeds * Time.fixedDeltaTime);
    }
}
