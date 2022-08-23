using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    [HideInInspector] public bool isAlive = true;
    [SerializeField] private float playerSpeed = 5f;
    private Rigidbody rb;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if (viewPos.x > 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            //Player is visible.
            float h = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * playerSpeed;
            rb.MovePosition(rb.position + Vector3.right * h);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        Time.timeScale = 1f / 10f;
        Time.fixedDeltaTime = Time.fixedDeltaTime / 10f;

        yield return new WaitForSeconds(1f / 10f);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime / 10f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
