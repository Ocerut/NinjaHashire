using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 200.0f;
    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        AddStartingForce();
    }

    private void AddStartingForce()
    {
        float y = 1.0f;
        float x = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        rb2d.AddForce(direction * speed);
    }

    public void AddForce(Vector2 force)
    {
        rb2d.AddForce(force);
    }

    public void ResetPosition()
    {
        float y2 = -3.5f;
        transform.position = new Vector2(0, y2);
        rb2d.linearVelocity = Vector2.zero;
        AddStartingForce();
    }
}
