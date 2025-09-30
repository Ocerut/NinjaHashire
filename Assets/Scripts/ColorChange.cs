using Unity.VisualScripting;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color[] color;
    public SpriteRenderer sprite;
    public int index = 0;
    public Collider2D collidr;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        collidr = GetComponent<Collider2D>();

        color = new Color[1000];

        //color[0] = Color.white;
        //color[1] = Color.red;
        //color[2] = Color.yellow;
        //color[3] = Color.green;
        //color[4] = Color.cyan;
        //color[5] = Color.blue;
        //color[6] = Color.magenta;
        //color[7] = Color.gray;
        //color[8] = Color.black;
        //color[9] = Color.gray;

        for (int i = 0; i < color.Length; i++)
        {
            color[i] = Random.ColorHSV();
        }

        sprite.color = color[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ChangeColor();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began) 
        {
            ChangeColor();
        }
    }

    void ChangeColor()
    {
        index++;

        if (index >= color.Length)
        {
            index = 0;
        }

        sprite.color = color[index];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeColor();
    }

}
