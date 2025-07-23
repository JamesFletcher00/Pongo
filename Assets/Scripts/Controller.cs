using UnityEngine;

public class Controller : MonoBehaviour
{
    public Camera mainCamera; // Drag your Main Camera here
    public float paddleSpeed = 10f;
    public float minY = -4.25f;
    public float maxY = 4.25f;


    // Update is called once per frame
   void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = -mainCamera.transform.position.z; // Distance from camera to the 2D world

        Vector3 worldMousePos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

        float targetY = Mathf.Clamp(worldMousePos.y, minY, maxY);
        Vector3 targetPos = new Vector3(transform.position.x, targetY, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, paddleSpeed * Time.deltaTime);
    }
}
