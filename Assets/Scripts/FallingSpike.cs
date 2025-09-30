using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    [SerializeField] private float detectRange;
    [SerializeField] private GameObject stalactite;
    [SerializeField] private GameObject stalaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(stalactite);
        Instantiate(stalaPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
}
