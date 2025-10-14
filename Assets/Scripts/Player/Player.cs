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
    public bool IsRuning { get => isRuning; private set => isRuning = value; }
    
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
    #endregion
}
