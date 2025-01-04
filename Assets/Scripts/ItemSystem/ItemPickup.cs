using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData itemData; // 這是該道具的數據

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                if (inventory.AddItem(itemData))
                {
                    Destroy(gameObject); // 成功加入後刪除物件
                }
            }
        }
    }
}
