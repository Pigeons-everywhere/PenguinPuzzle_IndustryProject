using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [SerializeField] float distance = 8.5f;
    [SerializeField] float height = 8.5f;
    [SerializeField] Vector3 offset = new Vector3(0, 0, 0);
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotSpeed = 10f;

    void FixedUpdate()
    {
        if (!target) return;

        Vector3 lookPos = target.position + offset;
        Vector3 relativePos = lookPos - transform.position;
        Quaternion rot = Quaternion.LookRotation(relativePos);

        // Slowly rorate the camera to the correct position
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotSpeed);

        Vector3 targetPos = target.position + target.up * height - target.forward * distance;

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);
    }
} 
