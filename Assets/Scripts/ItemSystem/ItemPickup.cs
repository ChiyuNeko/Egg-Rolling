using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData itemData; // �o�O�ӹD�㪺�ƾ�

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                if (inventory.AddItem(itemData))
                {
                    Destroy(gameObject); // ���\�[�J��R������
                }
            }
        }
    }
}
