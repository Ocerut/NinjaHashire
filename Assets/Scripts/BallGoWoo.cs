using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public int x;
    public int y;

    public float speed = 200.0f;
    public float maxVelocity = 10;


    void FixedUpdate()
    {
        rb2d.linearVelocity = Vector2.ClampMagnitude(rb2d.linearVelocity, maxVelocity);
    }


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        AddStartingForce();
    }

    private void AddStartingForce()
    {
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        float x = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        rb2d.AddForce(direction * speed);
    }

    public void AddForce(Vector2 force)
    {
        rb2d.AddForce(force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AddStartingForce();
    }
}
