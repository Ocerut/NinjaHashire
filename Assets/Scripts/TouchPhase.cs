using TMPro;
using UnityEngine;

public class TouchPhase : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;
    public TextMeshProUGUI textMeshPro;
    public string message;


    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = "Touch: " + message + " in direction " + direction;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case UnityEngine.TouchPhase.Began:
                    startPos = touch.position;
                    message = "began";
                    break;
                case UnityEngine.TouchPhase.Moved:
                    direction = touch.position - startPos;
                    message = "moved";
                    break;
                case UnityEngine.TouchPhase.Ended:
                    message = "ended";
                    break;
                case UnityEngine.TouchPhase.Canceled:
                    message = "canceled";
                    break;
                case UnityEngine.TouchPhase.Stationary:
                    Debug.Log("Touch: stationary in direction " + direction);
                    //message = "stationary";
                    break;
            }
        }

    }
}
