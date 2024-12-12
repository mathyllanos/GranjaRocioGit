using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemstoPickup;


    public void PickupItem(int id)
    {
        inventoryManager.AddItem(itemstoPickup[id]);
    }
}
