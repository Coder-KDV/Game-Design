using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpForce = 5f;
    public AudioClip jumpSound;

    private Rigidbody2D rb;
    public AudioSource audioSource;
    private bool isAlive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isAlive && (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
        {
            rb.linearVelocity = Vector2.up * jumpForce;

            if (jumpSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isAlive = false;
        GameManager.Instance.GameOver();
    }
}
