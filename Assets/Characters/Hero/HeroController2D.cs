﻿using UnityEngine;
using System.Collections;

public class HeroController2D : MonoBehaviour {
    
    public static float MaxSpeed = 2.5f;
    public static bool FacingRight = false;

    public Animator anim;

    bool grounded = true;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask  whatIsGround;
    public float jumpForce = 30;
    public HeroHealth2D health;

    // Use this for initialization
    void Start () {
//        anim = GetComponent<Animator>();
//        health = GetComponent<HeroHealth2D>();
    }
    
    // Update is called once per frame
    void FixedUpdate () {
        if (!health.isDead)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            //      anim.SetBool ("Ground", grounded);

            float move = Input.GetAxis("Horizontal");
//            Debug.Log(move);
            anim.SetFloat("Speed", Mathf.Abs(move));
            //        SetRunningSpeed(Mathf.Abs (move));
//            Debug.Log(rigidbody2D.velocity);
            rigidbody2D.velocity = new Vector2(move * MaxSpeed, rigidbody2D.velocity.y); 
            if (move > 0 && !FacingRight)
            {
                Flip();
            } else if (move < 0 && FacingRight)
            {
                Flip();
            }
        
            //Jumping down platform
//        Physics2D.IgnoreLayerCollision( LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Platform"),!grounded || rigidbody2D.velocity.y > 0);
//        float vertical = Input.GetAxis ("Vertical");
//        if (grounded && vertical < -0.05) {
//            Physics2D.IgnoreLayerCollision( LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Platform"), vertical < -0.05);
//        }
        }
    }
    
    void Update(){
        if (!health.isDead)
        {
            if (grounded && Input.GetAxis("Jump") > 0)
            {
                Debug.Log("Jump");
                rigidbody2D.AddForce(new Vector2(0, jumpForce));
            }
        }
    }
    
    void Flip(){
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
//    void SetRunningSpeed(float speed){
//        legAnimator.SetFloat ("Speed", speed);
//        upperBodyAnimator.SetFloat ("Speed", speed);
//    }
    
}
