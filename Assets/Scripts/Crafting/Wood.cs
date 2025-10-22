using UnityEngine;

public class Wood : MonoBehaviour
{
    private int woodValue = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerInventory>().AddNewItem(woodValue);
            Destroy(gameObject);
        }
    }
}
