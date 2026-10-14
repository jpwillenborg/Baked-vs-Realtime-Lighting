using UnityEngine;


public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distanceToTarget = 10.0f;
    [SerializeField]
    private float smoothTime = 0.1f;
    private float targetHeight;
    private Vector3 playerTarget;
    private Vector3 followVelocity;


    void Start()
    {
        transform.position = target.position - transform.forward * distanceToTarget;
        targetHeight = transform.position.y;
    }


    void LateUpdate()
    {
        Vector3 targetPosition = target.position - transform.forward * distanceToTarget;

        playerTarget = targetPosition;
        playerTarget.y = targetHeight;
        targetPosition = playerTarget;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref followVelocity, smoothTime);
    }
}
