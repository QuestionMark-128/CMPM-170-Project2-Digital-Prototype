using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public bool playerOne = true;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = 0;
        float y = 0;

        if (playerOne)
        {
            if (Input.GetKey(KeyCode.W)) y += 1;
            if (Input.GetKey(KeyCode.S)) y -= 1;
            if (Input.GetKey(KeyCode.A)) x -= 1;
            if (Input.GetKey(KeyCode.D)) x += 1;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow)) y += 1;
            if (Input.GetKey(KeyCode.DownArrow)) y -= 1;
            if (Input.GetKey(KeyCode.LeftArrow)) x -= 1;
            if (Input.GetKey(KeyCode.RightArrow)) x += 1;
        }

        movement = new Vector2(x, y).normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}