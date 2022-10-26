
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerDiego : MonoBehaviour

{
    public float moveSpeed;
    private bool isMoving;
    public Vector2 input;

    private Animator animator;

    public SwordAttackDiego swordAttackDiego;

    private void Awake()

    {
        animator = GetComponent<Animator>();
    }



    private void Update()

    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPosition = transform.position;
                targetPosition.x += input.x;
                targetPosition.y += input.y;



                StartCoroutine(Move(targetPosition));

            }

        }

        animator.SetBool("isMoving", isMoving);

    }



    IEnumerator Move(Vector3 targetPosition)

    {

        isMoving = true;

        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            yield return null;

        }

        transform.position = targetPosition;

        isMoving = false;

    }

    public void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }


    public void SwordAttackRight()
    {
        swordAttackDiego.AttackRight();
    }

    public void SwordAttackLeft()
    {
        swordAttackDiego.AttackLeft();
    }

    public void SwordAttackUp()
    {
        swordAttackDiego.AttackUp();
    }

    public void SwordAttackDown()
    {
        swordAttackDiego.AttackDown();
    }

    public void EndSwordAttack()
    {
        swordAttackDiego.StopAttack();
    }

}