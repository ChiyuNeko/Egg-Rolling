using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Inventory inventory;

    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventory.UseItem(0); // 使用第1格道具
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventory.UseItem(1); // 使用第2格道具
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            inventory.UseItem(2); // 使用第3格道具
        }
    }
}
