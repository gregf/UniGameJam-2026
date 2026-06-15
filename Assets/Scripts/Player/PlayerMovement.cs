using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 velocity = Vector2.zero;
    private bool movementDisabled = false;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() 
    {
        EventsManager.Instance.inputEvents.onMovePressed += MovePressed;
        EventsManager.Instance.playerEvents.onDisablePlayerMovement += DisablePlayerMovement;
        EventsManager.Instance.playerEvents.onEnablePlayerMovement += EnablePlayerMovement;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.inputEvents.onMovePressed -= MovePressed;
        EventsManager.Instance.playerEvents.onDisablePlayerMovement -= DisablePlayerMovement;
        EventsManager.Instance.playerEvents.onEnablePlayerMovement -= EnablePlayerMovement;
    }

    private void DisablePlayerMovement() 
    {
        movementDisabled = true;
        // also ensure we stop any current movement
        velocity = Vector2.zero;
    }

    private void EnablePlayerMovement() 
    {
        movementDisabled = false;
    }

    private void MovePressed(Vector2 moveDir) 
    {
        velocity = moveDir.normalized * moveSpeed;

        if (movementDisabled) 
        {
            velocity = Vector2.zero;
        }
    }

    private void FixedUpdate() 
    {
        rb.linearVelocity = velocity;
    }
}
