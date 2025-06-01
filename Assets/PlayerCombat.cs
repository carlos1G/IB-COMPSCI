using System;
using UnityEngine;
using Unity.Collections;
using UnityEngine.InputSystem.LowLevel;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 20; // Replace with your desired damage value

    public float attackRate = 2f;
    float nextAttackTime = 0.1f;
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Press Space to fight
            {
                
                Attack(); // Ensures animation plays fully
                nextAttackTime = Time.time + 2.5f / attackRate;
            }
        }
        
    }

    void Attack()
    {
        animator.SetTrigger("Attack"); // Replace with your attack animation hash
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);

        }
    }

    IEnumerator DelayAnimation()
    {
        yield return new WaitForSeconds(4f); // Adjust delay duration as needed
    }

    IEnumerator DelayedDamage(Collider2D enemy)
    {
        yield return new WaitForSeconds(0.8f); // Adjust delay duration as needed
        enemy.GetComponent<Enemy>().TakeDamage(attackDamage); // Apply damage after delay
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
