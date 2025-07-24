using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float launchTimer = 2f;
    public float maxY = 3f;
    public float minY = -3;
    public float ballSpeed = 5f;
    public bool isLaunched = false;

    void Start()
    {
        rb.linearVelocity = Vector2.zero;
        Invoke("LaunchBall", launchTimer);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
