using UnityEngine;
using UnityEngine.InputSystem; 
using UnityEngine.SceneManagement; // Added for scene management support

public class Player2_mech : MonoBehaviour
{
    public float jumpForce = 20f;
    public GameObject gameOverPanel; // Drag the GameOverPanel here!
    
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Ensure the game starts unfrozen
        Time.timeScale = 1; 
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
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
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            
            // Trigger Camera Shake if available
            if (Camera.main.GetComponent<CameraShake>() != null)
            {
                StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.2f, 0.4f));
            }

            Time.timeScale = 0; // Freezes the game
            if(gameOverPanel != null)
            {
                gameOverPanel.SetActive(true); 
            }
        }
    }
}