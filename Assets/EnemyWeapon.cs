using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int attackDamage = 50;

    public Vector3 attackOffset;
    public float attackRange = 6f;
    public LayerMask playerLayer;
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, playerLayer);
        if (colInfo != null)
        {
            Debug.Log("Player hit: " + colInfo.name);
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
        else
        {
            Debug.Log("No player in range");
        }
    }

    // Update is called once per frame
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
    }
}
