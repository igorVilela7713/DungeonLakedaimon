﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public float moveSpeed;
    private float currentMoveSpeed;
    public float moveModifier;

    private Animator anim;
    private bool playerMoving;
    public Vector2 lastMove;
    private Rigidbody2D myRigidbody;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    private static bool playerExists;
    public string startPoint;

    public bool canMove;

    // Start is called before the first frame update
    void Start(){
      anim = GetComponent<Animator>();
      myRigidbody = GetComponent<Rigidbody2D>();
      if (!playerExists) {
        playerExists = true;
        DontDestroyOnLoad(transform.gameObject);
      }else{
        Destroy(gameObject);
      }
      canMove = true;
      lastMove = new Vector2(0, -1f);


    }

    // Update is called once per frame
    void Update() {
        playerMoving = false;

        if (!canMove) {
          myRigidbody.velocity = Vector2.zero;
          return;
        }

        if (!attacking) {

          if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
              //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
              myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
              playerMoving = true;
              lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
          }

          if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
              myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
              playerMoving = true;
              lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
          }

          if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f){
              myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
          }

          if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f){
              myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
          }

          if (Input.GetKeyDown(KeyCode.J)) {

            attackTimeCounter = attackTime;
            attacking = true;
            myRigidbody.velocity = Vector2.zero;
            anim.SetBool("Attack", true );

          }

          if (Mathf.Abs(Input.GetAxisRaw("Vertical")) >0.5f && Mathf.Abs(Input.GetAxisRaw("Horizontal")) >0.5f) {
            currentMoveSpeed = moveSpeed * moveModifier;
          }else{
            currentMoveSpeed = moveSpeed;
          }

        }

        if (attackTimeCounter > 0) {

          attackTimeCounter -= Time.deltaTime;
        }
        if (attackTimeCounter <= 0) {

            attacking = false;
            anim.SetBool("Attack", false );
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

}
