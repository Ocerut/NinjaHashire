using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using System;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public GameObject shuriken;
    public int index = 0;
    public AudioSource audioSource;
    public AudioClip[] clips;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    private bool ground = false;
    [SerializeField] private float lowRange;
    [SerializeField] private int sceneNo;
    private string nextScene;
    [SerializeField] private float score;
    [SerializeField] private int goal;
    [SerializeField] private TextMeshProUGUI scoreText;
    private Rigidbody2D rb2d;
    [SerializeField] private GameObject porta;
    private int pulos;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (sceneNo == 1)
        {
            goal = 60;
            score = 0;
            scoreText.text = score.ToString();
        }
    }

    void Update()
    {
        if (transform.position.y < lowRange)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (score >= goal && porta.activeSelf == false)
        {
           porta.SetActive(true);
        }

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

                    
                }

                Instantiate(shuriken, transform.position, Quaternion.identity);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {  
        if (collision.gameObject.tag == "Inimigo")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
