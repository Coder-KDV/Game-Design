using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 2f;

    private bool addedScore = false;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -20f)
        {
            Destroy(gameObject);
        }

        if (addedScore == false)
        {
            if (transform.position.x < -7f)
            {
                GameManager.Instance.AddScore();
                addedScore = true;
            }
        }
    }
}
