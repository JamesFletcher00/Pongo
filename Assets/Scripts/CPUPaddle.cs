using UnityEngine;

public class CPUPaddle : MonoBehaviour
{
    [Header("Movement Variables")]
    public float speed = 3f;
    public float minY = -4.25f;
    public float maxY = 4.25f;
    [Header("Other")]
    public Rigidbody2D ball;
    void Update()
    {
        float targetY = Mathf.Clamp(ball.position.y, minY, maxY);
        Vector3 targetPos = new Vector3(transform.position.x, targetY, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }

}
