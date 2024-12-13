using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemstoPickup;


    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemstoPickup[id]);

        if (result == true)
        {
            Debug.Log("A�adido");
        }
        else
        {
            Debug.Log("No a�adido");
        }
    }
}
