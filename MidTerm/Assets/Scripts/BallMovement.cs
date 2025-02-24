using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private const string PlayerTag = "Player";
    private const string PlayerGoalTag = "Goal";
    private const string BoundaryTag = "Boundary";
    private const string CeilingTag = "Ceiling";
    private const string BrickTag = "Brick";

    private Rigidbody2D rBody;

    public SpriteRenderer paddleSpriteRenderer;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(PlayerTag))
        {
            HandlePlayerCollision(other);
        }
        else if (other.gameObject.CompareTag(PlayerGoalTag))
        {
            HandlePlayerGoalCollision();
        }
        else if (other.gameObject.CompareTag(BoundaryTag))
        {
            HandleBoundaryCollision();
        }
        else if (other.gameObject.CompareTag(CeilingTag))
        {
            HandleCeilingCollision();
        }
        else if (other.gameObject.CompareTag(BrickTag))
        {
            HandleBrickCollision(other);
        }
    }

    private void HandlePlayerCollision(Collision2D other)
    {

        Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();

        float x = CalculateBounceAngle(transform.position, other.transform.position, other.collider.bounds.size.x / 2);
        currentVelocity = new Vector2(x, currentVelocity.y * -1).normalized;
        currentVelocity *= GameManager.Instance.ballSpeed;
        GameManager.Instance.SetCurrentVelocity(currentVelocity);
    }

    private void HandlePlayerGoalCollision()
    {
        GameManager.Instance.TrackScore(Player.Player);
    }

    private void HandleBoundaryCollision()
    {
        Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
        currentVelocity = new Vector2(currentVelocity.x * -1, currentVelocity.y);
        GameManager.Instance.SetCurrentVelocity(currentVelocity);
    }

    private void HandleCeilingCollision()
    {
        Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
        currentVelocity = new Vector2(currentVelocity.x, currentVelocity.y * -1);
        GameManager.Instance.SetCurrentVelocity(currentVelocity);
    }

    private void HandleBrickCollision(Collision2D other)
    {
        GameObject otherObject = other.gameObject;
        BrickBehavior otherScript = otherObject.GetComponent<BrickBehavior>();

        if (otherScript != null)
        {
            if (otherScript.isTeleporter)
            {
                transform.position = new Vector2(2.7f, 4.5f);
            }
        }

        Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
        currentVelocity = new Vector2(currentVelocity.x, currentVelocity.y * -1);
        GameManager.Instance.SetCurrentVelocity(currentVelocity);
    }

    private float CalculateBounceAngle(Vector2 ballPos, Vector2 objectPos, float objectHeight)
    {
        return (ballPos.y - objectPos.y) / objectHeight * 5f;
    }
}
