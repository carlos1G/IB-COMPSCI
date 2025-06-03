using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float FollowSpeed = 5f; // Increased speed for better tracking
    public float yOffset = 1f;
    public Transform target;

    void Update()
    {
        if (target == null) return; // Prevent errors if no target is assigned

        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Lerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}