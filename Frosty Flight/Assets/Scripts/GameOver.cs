using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private AudioClip gameOverSound;

    [SerializeField]
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.GameOver();
        }
    }

    private void PlaySound(AudioClip clip)
    {

    }
}
