using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int totalWood;

    public int TotalWood { get => totalWood; set => totalWood = value; }

   public void AddNewItem(int itemValue)
    {
        totalWood += itemValue;
    }
}
