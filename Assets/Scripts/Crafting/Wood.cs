using UnityEngine;

public class Wood : MonoBehaviour
{
    [Header("Wood Settings")]
    [SerializeField] private int woodValue = 1;
    [SerializeField] private float slideSpeed;
    [SerializeField] private float totalDistance;
    private float slideDistance;


    private void Update()
    {
        SlideWood();
    }

    private void SlideWood()
    {
        slideDistance += Time.deltaTime;

        if (slideDistance < totalDistance)
        {
            transform.Translate(Vector2.left * slideSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerInventory>().AddNewItem(woodValue);
            Destroy(gameObject);
        }
    }
}
