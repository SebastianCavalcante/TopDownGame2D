using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    private Vector2 direction;
    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);
    }
}
