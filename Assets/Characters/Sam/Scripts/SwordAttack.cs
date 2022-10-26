using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    Vector2 rightAttackOffset;

    public Collider2D swordCollider;

    public float damage = 10;

    private bool attackedLeft = false;

    public void Start()
    {
        rightAttackOffset = transform.localPosition;
    }

    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x *= -1, rightAttackOffset.y);
        attackedLeft = true;
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
        if(attackedLeft)
        {
            transform.localPosition = new Vector3(rightAttackOffset.x *= -1, rightAttackOffset.y);
            attackedLeft = false;
        }

    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            //deal damage to enemy

            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null)
            {
                //enemy.Health -= damage;
            }
        }
    }

    */
}
