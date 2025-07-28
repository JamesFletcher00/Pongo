using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float launchTimer = 2f;
    public float maxY = 3f;
    public float minY = -3;
    public float ballSpeed = 5f;
    public bool isLaunched = false;
    public AudioSource ballSound;

    void Start()
    {
        rb.linearVelocity = Vector2.zero;
        Invoke("LaunchBall", launchTimer);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        ballSound.Play();
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
