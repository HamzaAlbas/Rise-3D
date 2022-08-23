using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float platformSpeed = 1f;


    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 tempPos = transform.position;
        tempPos.y += platformSpeed * Time.deltaTime;
        transform.position = tempPos;
    }
}
