using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemID;         // �D��ID
    public string itemName;       // �D��W��
    public Sprite icon;           // �D��ϼ�
    //public GameObject prefab;     // �D�㪺Prefab
    public int maxStack = 1;      // �̤j���|�ƶq

    [Header("�ϥήĪG")]
    public UnityEvent onUse;      // �b�s�边���]�m�ϥήĪG

    public void UseItem()
    {
        Debug.Log($"�ϥιD��: {itemName}");
        onUse.Invoke(); // ����s�边���]�m���ĪG
    }
}
