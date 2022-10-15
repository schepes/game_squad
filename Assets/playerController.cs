using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    Vector2 movementInput;  //direction of vector
    SpriteRenderer spriteRenderer;   //rendering correct direction of sprite

    //collider box on Sam's feet
    Rigidbody2D rb;
    //moving animator for Sam
    Animator animator;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent is looking for a type (eg. RigidBody2D0, so when it finds a component that is that type it will take it and store it into rb)
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //called a certain number of times per second (recommended for anything using physics, like moveing)
    private void FixedUpdate() {
        //no acceleration, either moving or not moving (no input, just idle) no raycasts needed
        //if player is trying to move
        if (movementInput != Vector2.zero) {
           //raycasting for collision
          bool success = TryMove(movementInput);

          animator.SetBool("isMoving", success);
        } else {
           animator.SetBool("isMoving", false);
        }

        //set direction of sprite movement direction
        if (movementInput.x < 0) {
            spriteRenderer.flipX = true;
        } else if (movementInput.x > 0) {
        spriteRenderer.flipX = false;
        }

    }

    private bool TryMove(Vector2 direction) {
        //Raycast: checking for potential collisions to see if move is valid
        //otherwise player wouldn't interract with world at all
       int count =  rb.Cast(
            movementInput,  //X and Y values between -1 and 1 that represent direction from the body to look for collisions
            movementFilter, //the settings that determine where a collision can occur on, such as layers to collide with
            castCollisions, //list of collisions to store the fount collisions into after Cast is finished
            moveSpeed * Time.fixedDeltaTime + collisionOffset);  //amount to Cast, equal to the movement plus an offset. Magnitude of vector
       //player can only move if there are zero collisions detected
       if(count == 0) {
            rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime); //moving player by appropriate distance
            return true;
       } else {
            return false;
       }

    }
    
    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }
}
