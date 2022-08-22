using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float platformSpeed = 2f;

    private void Update()
    {
        transform.Translate(Vector3.up * platformSpeed * Time.deltaTime, Space.World);
    }
}
