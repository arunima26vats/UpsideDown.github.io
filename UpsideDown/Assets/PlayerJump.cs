using UnityEngine;
using UnityEngine.InputSystem; 
using UnityEngine.SceneManagement; // Added this for scene switching

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 20f;
    public string sceneToLoad = "scene2"; // Name of the scene you want to go to
    
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            // Note: rb.linearVelocity is used in newer Unity versions (like your Unity 6)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // When the player hits an object tagged "Obstacle"
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Hit Obstacle! Switching to " + sceneToLoad);
            
            // Optional: Keep the shake effect if your camera script is present
            if (Camera.main.GetComponent<CameraShake>() != null)
            {
                StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.2f, 0.4f));
            }

            // Load the new scene immediately
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}