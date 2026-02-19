using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShadowFollow : MonoBehaviour
{
    public Transform penguin;
    public float groundOffset = 0.02f;
    public LayerMask groundlayer;

    void LateUpdate()
    {
        Vector3 rayStart = penguin.position + Vector3.up * 1f;

        if (Physics.Raycast(rayStart, Vector3.down, out RaycastHit hitInfo,2f,groundlayer))
        {
            transform.position = hitInfo.point + Vector3.up * groundOffset;
        }
    }
}
