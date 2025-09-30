using UnityEngine;

public class TouchSpawner : MonoBehaviour
{
    public GameObject[] objects;
    public int index = 0;
    public AudioSource audioSource;
    public AudioClip[] clips;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                Vector2 position = Camera.main.ScreenToWorldPoint(touch.position);

                Collider2D hit = Physics2D.OverlapPoint(position);

                if (hit != null)
                {
                    if (clips != null)
                    {
                        audioSource.PlayOneShot(clips[index]);
                    }

                    Destroy(hit.gameObject);
                }

                Instantiate(objects[index], position, Quaternion.identity);

                index = (index + 1) % objects.Length;
            }

            
        }
    }
}
