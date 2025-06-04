using UnityEngine;

public class SpawnCreators : MonoBehaviour
{
    public LayerMask playerLayer;
    public Vector3 attackOffset;
    public float attackRange = 2f;
    public string tag;
    private GameObject[] enemies; // Declare the array without initializing it

    void Start()
    {
        // Initialize the array inside Start()
        enemies = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject enemy in enemies)
        {
            Debug.Log("Deactivated");
            enemy.SetActive(false); // Deactivate each enemy
        }
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, playerLayer);
        if (colInfo != null)
        {
            Debug.Log(enemies);
            foreach (GameObject enemy in enemies)
            {
                Debug.Log("Activated");
                enemy.SetActive(true); // Activate each enemy instead of deactivating
            }
        }
    }
}