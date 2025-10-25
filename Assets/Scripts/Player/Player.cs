using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    public float runSpeed;
    public float initialSpeed;

    private Vector2 direction;
    public Vector2 Direction { get => direction; private set => direction = value; }

    private bool isRuning = false;
    private bool isRolling = false;
    private bool isCuting = false;
    private bool isDigging = false;
    private int interactionTool;

    public bool IsRuning { get => isRuning; private set => isRuning = value; }
    public bool IsRolling { get => isRolling; private set => isRolling = value; }
    public bool IsCuting { get => isCuting; private set => isCuting = value; }
    public bool IsDigging { get => isDigging; private set => isDigging = value; }
    public int InteractionTool { get => interactionTool; private set => interactionTool = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    // Update is called once per frame
    private void Update()
    {
        OnInteractionTool();
        OnInput();
        OnRun();
        OnRolling();
        OnCuting();
        OnDigging();
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

    private void OnDigging()
    {
        if (Input.GetMouseButton(0))
        {
            isDigging = true;
            speed = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDigging = false;
            speed = initialSpeed;
        }
    }

    private void OnInteractionTool()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            interactionTool = 0;
            Debug.Log("Mão vazias!");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            interactionTool = 1;
            Debug.Log("Machado Equipado!");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            interactionTool = 2;
            Debug.Log("Pá Equipada!");
        }
    }
    #endregion
}