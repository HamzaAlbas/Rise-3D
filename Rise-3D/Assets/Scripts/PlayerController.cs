using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    [HideInInspector] public bool isAlive = true;
    [SerializeField] private float playerSpeed = 5f;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if (viewPos.x > 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            //Player is visible.
            float h = Input.GetAxisRaw("Horizontal");
            GetComponent<Rigidbody>().velocity = new Vector3(h, 0, 0) * playerSpeed;
        }
        else
        {
            //Player is out of view.
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (transform.position.x > 2)
            {
                transform.position -= new Vector3(0.1f, 0, 0);
            }
            else if (transform.position.x < -2)
            {
                transform.position += new Vector3(0.1f, 0, 0);
            }
        }
    }
}
