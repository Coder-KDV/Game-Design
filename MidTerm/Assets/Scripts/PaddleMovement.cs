using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public string inputAxis;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(inputAxis) * moveSpeed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        float clampedX = Mathf.Clamp(transform.position.x, -2.30f, 2.30f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
