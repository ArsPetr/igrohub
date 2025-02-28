using UnityEngine;
using UnityEngine.InputSystem;
using static NewControls;

public class PlayerController : MonoBehaviour, IPlayerActions
{
    private Rigidbody2D rigidbody2D;
    private Vector2 movement;

    public float speed = 100f;

    private NewControls inputActions;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (inputActions == null )
        {
            inputActions = new NewControls();
            inputActions.Player.SetCallbacks( this );
        }
        
        inputActions.Enable();
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        //movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rigidbody2D.linearVelocity = movement * speed;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector3>();
        movement.Normalize();
        Debug.Log($"Movement: {movement}");
    }
}
