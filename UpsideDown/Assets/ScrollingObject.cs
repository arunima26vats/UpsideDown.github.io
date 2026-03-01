using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;
    private float speedMultiplier = 1f;
    private float width;

    void Start()
    {
        // Measure the ground width so we know when to loop it
        width = GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {
        // Increase speed slightly every second to match MoveLeft
        speedMultiplier += Time.deltaTime * 0.05f; 

        // Move the ground left
        transform.Translate(Vector2.left * speed * speedMultiplier * Time.deltaTime);

        // If the ground piece has moved fully off-screen, reset its position
        if (transform.position.x < -width)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}