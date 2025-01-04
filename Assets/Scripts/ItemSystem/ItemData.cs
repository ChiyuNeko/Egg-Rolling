using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemID;         // 道具ID
    public string itemName;       // 道具名稱
    public Sprite icon;           // 道具圖標
    //public GameObject prefab;     // 道具的Prefab
    public int maxStack = 1;      // 最大堆疊數量

    [Header("使用效果")]
    public UnityEvent onUse;      // 在編輯器中設置使用效果

    public void UseItem()
    {
        Debug.Log($"使用道具: {itemName}");
        onUse.Invoke(); // 執行編輯器中設置的效果
    }
}
