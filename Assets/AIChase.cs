using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    [SerializeField] float health, maxHealh = 3f;
    [SerializeField] float moveSpeed = 5f;
    public Animator animator;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start(){
        health = maxHealh;
        target = GameObject.Find("sam1 1").transform;
    }
    private void Update(){

        if(target){
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
            animator.SetFloat("Horizontal",moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);
            animator.SetFloat("Speed", moveDirection.sqrMagnitude);
        }
    }
    private void FixedUpdate(){
        if(target){
            rb.velocity = new Vector2(moveDirection.x,moveDirection.y) * moveSpeed;
        }
    }
}
