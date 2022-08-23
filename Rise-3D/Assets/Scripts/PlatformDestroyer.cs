using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.y < -15f)
        {
            Destroy(gameObject);
        }
    }
}
