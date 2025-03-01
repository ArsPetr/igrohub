using System;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static NewControls;

public class PlayerController : MonoBehaviour, IPlayerActions, IDamagable
{
    private Rigidbody2D rigidbody2D;
    private Vector2 movement;

    public float speed = 100f;

    private NewControls inputActions;

    private float _health = 3;
    private float _maxHealth = 3;

    private int _score = 0;
    public int Score
    {
        get { return _score; } set { _score = value; scoreUI.text = _score.ToString(); }
    }
    public float Health { get { return _health; } }


    public TextMeshProUGUI healthUI;
    public TextMeshProUGUI scoreUI;

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

    public void Heal(float v)
    {
        _health += v;
        _health = _health > _maxHealth ? _maxHealth : _health;
        updateHealthUI();
    }

    public void TakeDamage(float v)
    {
        _health -= v;
        updateHealthUI();
        if ( _health < 1)
        {
            Die();
        }
        
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void updateHealthUI()
    {
        healthUI.text = _health.ToString();
    }
}
