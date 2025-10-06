using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using System;
using UnityEngine.Audio;
using UnityEngine.InputSystem.Interactions;

public class Player : MonoBehaviour
{
    public GameObject shuriken;
    public GameObject slash;
    public int index = 0;
    public AudioSource audioSource;
    public AudioSource audioSteps;
    [SerializeField] private int sceneNo;
    [SerializeField] private float time;
    [SerializeField] private int goal;
    [SerializeField] private TextMeshProUGUI timerText;
    public AudioClip clipShuriken;
    public AudioClip clipSword;
    public float lastTapTime = 0;
    public float DoubleTapThreshold = 0.3f;
    private Vector3 hand;
    public float handAdjust;
    private Vector3 startPos; 
    private Vector3 lastPos;   
    private float dragDistance;

    void Start()
    {
        audioSteps.Play();
        dragDistance = Screen.height * 10 / 100;
        hand = new Vector3(transform.position.x +handAdjust, transform.position.y -handAdjust, transform.position.z);
        if (sceneNo == 1)
        {
            goal = 90;
        }
    }

    void Update()
    {
        time = time + Time.deltaTime;
        timerText.text = time.ToString("0") + "s";

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                startPos = touch.position;
                lastPos = touch.position;
            }
            else if (touch.phase == UnityEngine.TouchPhase.Moved)
            {
                lastPos = touch.position;
            }
            else if (touch.phase == UnityEngine.TouchPhase.Ended)
            {
                lastPos = touch.position;
                if (lastPos.x - startPos.x > dragDistance || lastPos.y - startPos.y > dragDistance)
                {
                    Instantiate(slash, hand, Quaternion.identity);
                    audioSource.PlayOneShot(clipSword);
                }
                else
                {
                    Instantiate(shuriken, hand, Quaternion.identity);
                    audioSource.PlayOneShot(clipShuriken);
                }
            }
        }

        if (time >= goal) { SceneManager.LoadScene(3); }
    }
}
