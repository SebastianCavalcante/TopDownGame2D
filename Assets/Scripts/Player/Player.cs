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
    private bool isCuting;

    public bool IsRuning { get => isRuning; private set => isRuning = value; }
    public bool IsRolling { get => isRolling; private set => isRolling = value; }
    public bool IsCuting { get => isCuting; private set => isCuting = value; }
    
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
        OnCuting();
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
    
    private void OnCuting()
    {
        if (Input.GetMouseButton(0))
        {
            isCuting = true;
            speed = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isCuting = false;
            speed = initialSpeed;
        }
    }

    #endregion
}
