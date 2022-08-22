using UnityEngine;

public class PlayerIsVisible : MonoBehaviour
{
    Camera cam;
    public Transform player;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(player.position + new Vector3(1,1,1));
        if (viewPos.x > 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            Debug.Log("Player is visible.");
        }
        else Debug.Log("Player is out of view");
    }
}
