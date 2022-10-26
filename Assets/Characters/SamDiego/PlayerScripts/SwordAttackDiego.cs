using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackDiego : MonoBehaviour
{

    Vector2 attackOffset;

    public Collider2D swordCollider;

    public float damage = 10;

    private bool attackedLeft = false;
    private bool attackedDown = false;

    public void Start()
    {
        attackOffset = transform.localPosition;
    }

    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = attackOffset;
    }

    public void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(attackOffset.x *= -1, attackOffset.y);
        attackedLeft = true;
    }

    public void AttackUp()
    {
        swordCollider.enabled = true;
        transform.localPosition = attackOffset;

    }
    public void AttackDown()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(attackOffset.x, attackOffset.y *= -1);
        attackedDown = true;
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
        if(attackedLeft)
        {
            transform.localPosition = new Vector3(attackOffset.x *= -1, attackOffset.y);
            attackedLeft = false;
        }
        if(attackedDown)
        {
            transform.localPosition = new Vector3(attackOffset.x, attackOffset.y *= -1);
            attackedDown = false;
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
