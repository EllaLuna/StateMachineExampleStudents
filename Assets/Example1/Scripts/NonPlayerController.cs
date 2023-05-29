using UnityEngine;

public class NonPlayerController : MonoBehaviour
{
    public float speed = 20.0f;

    private bool moveRight = false;

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }

        if (moveRight && transform.position.x > 8)
        {
            moveRight = false;
        }
        else if (!moveRight && transform.position.x < -8)
        {
            moveRight = true;
        }
    }
}
