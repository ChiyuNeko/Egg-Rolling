using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>(3); // 固定三格的道具欄
    public List<Button> itemButtons; // 連結 UI 按鈕

    void Start()
    {
        UpdateUI();
    }

    public bool AddItem(ItemData item)
    {
        if (items.Count >= 3)
        {
            Debug.Log("道具欄已滿！");
            return false; // 無法添加道具
        }

        items.Add(item);
        Debug.Log($"獲得道具: {item.itemName}");
        UpdateUI(); // 更新UI
        return true;
    }

    public void UseItem(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= items.Count)
        {
            Debug.Log("無效的道具欄位！");
            return;
        }

        var item = items[slotIndex];
        if (item != null)
        {
            item.UseItem(); // 執行道具效果
            items.RemoveAt(slotIndex); // 消耗道具
            Debug.Log($"消耗道具: {item.itemName}");
            UpdateUI(); // 更新UI
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
                button.GetComponentInChildren<Text>().text = item.itemName; // 更新文字
                button.GetComponent<Image>().sprite = item.icon; // 更新圖片
                button.interactable = true; // 啟用按鈕
            }
            else
            {
                button.GetComponentInChildren<Text>().text = ""; // 清空文字
                button.GetComponent<Image>().sprite = null; // 清空圖片
                button.interactable = false; // 禁用按鈕
            }
        }
    }
}
