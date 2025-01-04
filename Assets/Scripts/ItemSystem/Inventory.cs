using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>(3); // �T�w�T�檺�D����
    public List<Button> itemButtons; // �s�� UI ���s

    void Start()
    {
        UpdateUI();
    }

    public bool AddItem(ItemData item)
    {
        if (items.Count >= 3)
        {
            Debug.Log("�D����w���I");
            return false; // �L�k�K�[�D��
        }

        items.Add(item);
        Debug.Log($"��o�D��: {item.itemName}");
        UpdateUI(); // ��sUI
        return true;
    }

    public void UseItem(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= items.Count)
        {
            Debug.Log("�L�Ī��D�����I");
            return;
        }

        var item = items[slotIndex];
        if (item != null)
        {
            item.UseItem(); // ����D��ĪG
            items.RemoveAt(slotIndex); // ���ӹD��
            Debug.Log($"���ӹD��: {item.itemName}");
            UpdateUI(); // ��sUI
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < itemButtons.Count; i++)
        {
            var button = itemButtons[i];
            if (i < items.Count)
            {
                var item = items[i];
                button.GetComponentInChildren<Text>().text = item.itemName; // ��s��r
                button.GetComponent<Image>().sprite = item.icon; // ��s�Ϥ�
                button.interactable = true; // �ҥΫ��s
            }
            else
            {
                button.GetComponentInChildren<Text>().text = ""; // �M�Ť�r
                button.GetComponent<Image>().sprite = null; // �M�ŹϤ�
                button.interactable = false; // �T�Ϋ��s
            }
        }
    }
}
