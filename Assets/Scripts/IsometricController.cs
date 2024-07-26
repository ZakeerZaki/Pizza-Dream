using UnityEngine;

public class IsometricController : MonoBehaviour
{
    public float speed = 10f; // Movement speed
    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }

    void HandleInput()
    {
        // Handle touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.transform.position.y));
            Debug.Log("Touch Position: " + touchPosition);
            Vector3 direction = (touchPosition - transform.position).normalized;
            Debug.Log("Direction: " + direction);

            // Convert to isometric direction
            movement = new Vector3(direction.x, 0, direction.z);
        }
        else
        {
            // Handle keyboard input for testing in the editor
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // Convert to isometric direction
            movement = new Vector3(moveHorizontal, 0, moveVertical * 0.5f);
            Debug.Log("Movement: " + movement);
        }
    }


    void MoveCharacter()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
