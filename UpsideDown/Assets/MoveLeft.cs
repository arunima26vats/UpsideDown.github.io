using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    private float speedMultiplier = 1f;

    void Update()
    {
        // Increase speed slightly every second
        speedMultiplier += Time.deltaTime * 0.05f; 
        
        // Move left using the base speed multiplied by the growth
        transform.Translate(Vector2.left * speed * speedMultiplier * Time.deltaTime);

        // Destroy the obstacle if it goes off-screen to save memory
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}