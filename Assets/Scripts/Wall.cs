using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float speedY;
    [SerializeField] private float amplitude;
    [SerializeField] private float y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentoZigzag();
    }

    void MovimentoZigzag()
    {
        transform.Translate(Vector2.up * speedY * Time.deltaTime);
        if (transform.position.y > amplitude + y)
        {
            speedY *= -1;
        }
        else if (transform.position.y < -amplitude + y)
        {
            speedY *= -1;
        }
    }

}
