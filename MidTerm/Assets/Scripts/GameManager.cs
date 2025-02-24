using UnityEngine;

public enum Player
{
    Player
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private const string BrickTag = "Brick";

    private int playerLostBalls = 0;

    private Vector2 currentVelocity;
    public Rigidbody2D ballRigidbody;
    public Rigidbody2D paddleRigidbody;

    public float ballSpeed;

    public int loseScore = 3;

    private bool gamePause = false;

    private bool gameWon = false;

    private float ballOriginalPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        saveBallPosition(ballRigidbody.transform.position.y);
        gamePause = true;
        GameStop();
    }

    private void Update()
    {
        ContinueGame();
        CheckForQuitGame();

        if (!gameWon)
        {
            CheckForWin();
        }
    }

    public void TrackScore(Player player)
    {
        playerLostBalls++;
        if (playerLostBalls >= loseScore)
        {
            Debug.Log("GameOver");
            gamePause = true;
        }
        ResetBall();
    }

    private void ContinueGame()
    {
        if (Input.GetKeyUp(KeyCode.Space) && gamePause)
        {
            gamePause = false;
            gameWon = false;
            playerLostBalls = 0;
            ResetBall();
        }
    }

    private void CheckForQuitGame()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void CheckForWin()
    {
        int bricksRemaining = GameObject.FindGameObjectsWithTag(BrickTag).Length;
        if (bricksRemaining <= 0)
        {
            gameWon = true;
            Debug.Log("You Win");
            gamePause = true;
            ResetBall();
        }
    }

    private void ResetBall()
    {
        if (gamePause)
        {
            GameStop();
        }
        else
        {
            ballRigidbody.transform.position = new Vector2(0, ballOriginalPosition);
            float randX = Random.Range(0, 2) == 0 ? -1 : 1;
            float randY = Random.Range(-0.5f, 0.5f) == 0 ? -0.5f : 0.5f;

            Vector2 direction = new Vector2(randX, randY).normalized;
            ballSpeed = 5f;
            ballRigidbody.linearVelocity = direction * ballSpeed;
            SetCurrentVelocity(ballRigidbody.linearVelocity);
        }
    }

    private void GameStop()
    {
        ballRigidbody.transform.position = new Vector2(0, ballOriginalPosition);
        ballRigidbody.linearVelocity = Vector2.zero;
        paddleRigidbody.transform.position = new Vector2(0, paddleRigidbody.transform.position.y);
    }

    public Vector2 GetCurrentVelocity()
    {
        return currentVelocity;
    }

    public void SetCurrentVelocity(Vector2 velocity)
    {
        currentVelocity = velocity;
        ballRigidbody.linearVelocity = currentVelocity;
    }

    public void saveBallPosition(float position)
    {
        ballOriginalPosition = position;
    }
}
