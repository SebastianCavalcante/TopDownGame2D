using UnityEngine;

public class Slot : MonoBehaviour
{
    [Header("Slod Settings")]
    [SerializeField] private SpriteRenderer slotSprite;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    [SerializeField] private int digAmount;
    [SerializeField] private int initialDigAmount;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialDigAmount = digAmount;
    }

    private void OnHit()
    {
        digAmount--;

        if (digAmount <= initialDigAmount / 2)
        {
            slotSprite.sprite = hole;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dig"))
        {
            OnHit();
        }
    }
}
