using UnityEngine;

public class Telescope : MonoBehaviour
{
    public Transform viewPoint;
    public Transform lookAtPoint;

    public float telescopeFOV = 20f;//Zoom in value

    private Camera telescopeCamera;

    private void Awake()
    {
        telescopeCamera = GetComponent<Camera>();
    }
    private void OnEnable()
    {
        telescopeCamera.fieldOfView = telescopeFOV;
    }

    private void LateUpdate()
    {
        transform.position = viewPoint.position;
        transform.rotation = viewPoint.rotation;
        transform.LookAt(lookAtPoint.position);
    }
}
