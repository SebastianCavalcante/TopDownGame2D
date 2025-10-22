using UnityEngine;

public class Tree : MonoBehaviour
{
    private Animator treeAnim;
    [SerializeField] private float treeHealth;

    private void Start()
    {
        treeAnim = GetComponent<Animator>();
    }

    private void TreeOnHit()
    {
        if (treeHealth > 0)
        {
            treeHealth--;
            treeAnim.SetTrigger("isCutting");
        }
       

        if (treeHealth <= 0)
        {
            treeAnim.SetInteger("transition", 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe"))
        {
            TreeOnHit();
        }
    }
}
