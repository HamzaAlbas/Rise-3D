using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; set; }
    Camera cam;
    [HideInInspector] public bool isAlive;
    [HideInInspector] public bool isGameStarted;
    [SerializeField] private float playerSpeed = 5f;
    private Rigidbody rb;
    private float fScore;
    private int iScore;
    public TMP_Text scoreText, highscoreText;
    public GameObject panel, platformSpawner;
    private int highScore;


    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        isAlive = true;
        iScore = 0;
        isGameStarted = false;
    }

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        highscoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void Update()
    {
        if (isGameStarted && isAlive)
        {
            PlayerControls();
            fScore += Time.deltaTime;
            iScore = Mathf.RoundToInt(fScore);
            scoreText.text = iScore.ToString();
        }
    }

    private void PlayerControls()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if (viewPos.x > 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            //Player is visible.
//            float h = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * playerSpeed;
            if (RightButtonHandler.Instance.rightButtonDown)
            {
                float r = 1 * Time.fixedDeltaTime * playerSpeed;
                rb.MovePosition(rb.position + Vector3.right * r);
            }
            if (LeftButtonHandler.Instance.leftButtonDown)
            {
                float l = -1 * Time.fixedDeltaTime * playerSpeed;
                rb.MovePosition(rb.position + Vector3.right * l);
            }
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

        isAlive = false;
        HighScoreSet();
        yield return new WaitForSeconds(1f / 10f);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime / 10f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        isGameStarted = true;
        panel.SetActive(false);
    }

    private void HighScoreSet()
    {
        if (iScore > PlayerPrefs.GetInt("HighScore"))
        {
            highScore = iScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highscoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    public void GoLeft()
    {

    }

    public void GoRight()
    {

    }
}
