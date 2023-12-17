using UnityEngine;

public class MenuParallax : MonoBehaviour
{
    public float speed = 3f;
    public Vector2 direction = Vector2.right;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}