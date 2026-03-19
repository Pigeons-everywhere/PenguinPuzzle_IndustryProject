using UnityEngine;

public class ButtonToPressBehaviour : MonoBehaviour
{
    DropBridgeBehaviour thisBridgeScr;
    public GameObject bridgeObj;
    void Start()
    {
        thisBridgeScr = bridgeObj.GetComponent<DropBridgeBehaviour>();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Box")
        {
            this.transform.Translate(new Vector3(0f,-0.3f,0f));
            thisBridgeScr.buttonsPressed += 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            this.transform.Translate(new Vector3(0f,0.3f,0f));
            thisBridgeScr.buttonsPressed -= 1;
        }
    }
}
