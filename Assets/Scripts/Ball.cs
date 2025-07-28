using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    [Header("Velocity")]
    public float launchTimer = 2f;
    public float ballSpeed = 10f;
    public float speedIncrease = 0.4f;
    public float maxSpeed = 15f;
    [Header("Distances")]
    public float maxY = 3f;
    public float minY = -3;
    [Header("Other")]
    private bool isLaunched = false;
    public AudioSource ballSound;

    void Start()
    {
        rb.linearVelocity = Vector2.zero;
        Invoke("LaunchBall", launchTimer);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        ballSound.Play();

        if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Wall"))
        {
            ballSpeed = Mathf.Min(ballSpeed + speedIncrease, maxSpeed);
        }

        if (collider.gameObject.CompareTag("Player"))
        {
            float paddleY = collider.transform.position.y;
            float contactY = transform.position.y;

            float offset = contactY - paddleY;
            float bounceAngle = offset * 5;

            Vector2 currentVelocity = rb.linearVelocity;
            rb.linearVelocity = new Vector2(currentVelocity.x, bounceAngle).normalized * ballSpeed;
        }
        else
        {
            // For non-paddle collisions (e.g., wall), keep current direction but apply new speed
            rb.linearVelocity = rb.linearVelocity.normalized * ballSpeed;
        }
    }

    void LaunchBall()
    {
        if (isLaunched) return;

        int direction = Random.Range(0, 2) == 0 ? 1 : -1;
        float randomY = Random.Range(minY, maxY);

        Vector2 launchVelocity = new Vector2(direction * ballSpeed, randomY);
        rb.linearVelocity = launchVelocity;

        isLaunched = true;
    }
    
    public void ResetBall(Vector3 position)
    {
        isLaunched = false;
        rb.linearVelocity = Vector2.zero;
        transform.position = position;

        Invoke("LaunchBall", launchTimer * 2);
    }

}
