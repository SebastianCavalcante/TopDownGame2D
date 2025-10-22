using UnityEngine;

public class Tree : MonoBehaviour
{
    private Animator treeAnim;
    [Header("Tree Settings")]
    [SerializeField] private float treeHealth;
    [SerializeField] private ParticleSystem treeLeaves;

    [Header("Drop Settings")]
    [SerializeField] private GameObject woodItemPrefab;
    [SerializeField] private int dropTotalItem;
    [SerializeField] private float dropDistance;

    private bool isCut = false;

    private void Start()
    {
        treeAnim = GetComponent<Animator>();
    }

    // Drop Item in game
    private void DropItem()
    {
        for (int i = 0; i < dropTotalItem; i++)
        {
            Instantiate(woodItemPrefab, transform.position + RandomDrop(), transform.rotation);
        }
    }

    //Return the random position to drop to wood.
    private Vector3 RandomDrop()
    {
        return new Vector3(Random.Range(-dropDistance, dropDistance), Random.Range(-dropDistance, dropDistance), 0);
    }

    private void TreeOnHit()
    {
        if (treeHealth > 0)
        {
            isCut = false;
            treeHealth--;
            treeAnim.SetTrigger("isCutting");
            treeLeaves.Play();
        }
        else if (treeHealth <= 0)
        {
            isCut = true;
            treeAnim.SetInteger("transition", 1);
            DropItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe") && !isCut)
        {
            TreeOnHit();
        }
    }
}
