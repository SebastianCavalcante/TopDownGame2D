using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    public float runSpeed;
    public float initialSpeed;
    
    private Vector2 direction;
    public Vector2 Direction { get => direction; private set => direction = value; }

    private bool isRuning;
    private bool isRolling;

    public bool IsRuning { get => isRuning; private set => isRuning = value; }
    public bool IsRolling { get => isRolling; private set => isRolling = value; }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    // Update is called once per frame
    private void Update()
    {
        OnInput();
        OnRun();
        OnRolling();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Moviment
    private void OnInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    private void OnMove()
    {
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isRuning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            isRuning = false;
        }
        
    }

    private void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isRolling = false;
        }
    }
    #endregion
}
