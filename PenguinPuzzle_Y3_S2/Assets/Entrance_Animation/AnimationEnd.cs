using UnityEngine;

public class AnimationEnd: MonoBehaviour
{
    public void EndAnimation()
    {
        gameObject.SetActive(false);
    }
}
