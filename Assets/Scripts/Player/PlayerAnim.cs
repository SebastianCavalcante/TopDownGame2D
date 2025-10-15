using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;
    private Vector2 scaleDirection;
    private readonly Vector2 SCALE_NORMAL = new Vector2(1, 1);
    private readonly Vector2 SCALE_FLIPPED = new Vector2(-1, 1);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
        OnRotate();
    }


    void OnMove()
    {
        if (player.Direction.sqrMagnitude > 0)
        {
            if (player.IsRolling)
            {
                anim.SetTrigger("isRoll");

            }
            else
            {
                anim.SetInteger("transition", 1);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);
        }
    }

    void OnRun()
    {
        if (player.IsRuning)
        {
            anim.SetInteger("transition", 2);
        }
    }

    void OnRotate()
    {
        if (player.Direction.x > 0)
        {
            RotateScale(1f);
        }
        else if (player.Direction.x < 0)
        {
            RotateScale(-1f);
        }
    }

    //Rotate the player in scale
    private void RotateScale(float value)
    {
        if (value > 0)
        {
             transform.localScale = SCALE_NORMAL;
        }
        else if (value < 0)
        {
            transform.localScale = SCALE_FLIPPED;
        }
    }
}
