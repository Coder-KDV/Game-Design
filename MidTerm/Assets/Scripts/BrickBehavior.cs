using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    private Vector2 teleportPosition, teleportVelocity;

    private const string BallTag = "Ball";

    private Rigidbody2D rBody;
    private SpriteRenderer sRenderer;

    [SerializeField]
    private int Hitpoints = 3;

    [SerializeField]
    public bool isTeleporter = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        sRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(BallTag))
        {
            HandleBallCollision(other);
        }
    }

    private void HandleBallCollision(Collision2D other)
    {
        Hitpoints--;
        if (Hitpoints == 2)
        {
            sRenderer.color = Color.yellow;
        }
        else if (Hitpoints == 1)
        {
            sRenderer.color = Color.white;
        }
        else if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
