using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public enum SwipeDecision { None, Accept, Reject }

public class SmashOrPass : MonoBehaviour
{
    [Header("Options")]
    [Tooltip("o pssões fracionadas ao cubo")]
    public bool keepOffSet = true;
    public Camera cam;
    public int activeFingerID = -1;
    public float screenZ;
    public Vector3 dragOffset;
    [SerializeField] bool has2D;
    [SerializeField] bool has3D;

    public System.Action<SwipeDecision> OnSwipeReleased;


    private void Awake()
    {
        cam = Camera.main;
        has2D = GetComponent<Collider2D>() != null;
        has3D = GetComponent<Collider>() != null;
    }

    private void OnEnable()
    {
        screenZ = cam.WorldToScreenPoint(transform.position).z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0) return;

        for (int i = 0; i < Input.touchCount; i++)
        {
            UnityEngine.Touch touch = Input.GetTouch(i);

            if (touch.phase == UnityEngine.TouchPhase.Began && activeFingerID == -1 && TouchHitsThis(touch.position))
            {
                activeFingerID = touch.fingerId;
                Vector3 worldAtFinger = ScreenToWorld(touch.position);
                dragOffset = keepOffSet ? (transform.position - worldAtFinger) : Vector3.zero;

            }

            if (touch.phase == UnityEngine.TouchPhase.Moved || touch.phase == UnityEngine.TouchPhase.Stationary && touch.fingerId == activeFingerID)
            {
                Vector3 worldAtFinger = ScreenToWorld(touch.position);
                transform.position = worldAtFinger + dragOffset;
            }
            if (touch.fingerId == activeFingerID && (touch.phase == UnityEngine.TouchPhase.Ended || touch.phase == UnityEngine.TouchPhase.Canceled))
            {

                /*Emite o evento da onde foi solto*/

                SwipeDecision decision =
                transform.position.x > 0f ? SwipeDecision.Accept
                    : transform.position.x < 0f ? SwipeDecision.Reject
                    : SwipeDecision.None;

                OnSwipeReleased?.Invoke(decision); // avisa o Manager

                activeFingerID = -1;
            }
        }

        
    }

    bool TouchHitsThis(Vector2 position)
    {
        if (has2D)
        {
            Vector2 world = ScreenToWorld(position);
            return Physics2D.OverlapPoint(world) == GetComponent<Collider2D>();
        }

        if (has3D)
        {
            Ray ray = cam.ScreenPointToRay(position);
            return Physics.Raycast(ray, out RaycastHit hit) && hit.collider == GetComponent<Collider>();
        }

        return true;
    }

    Vector3 ScreenToWorld(Vector2 position)
    {
        var screenPosition = new Vector3(position.x, position.y, screenZ);
        return cam.ScreenToWorldPoint(screenPosition);
    }
}
