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
            inventory.UseItem(0); // �ϥβ�1��D��
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventory.UseItem(1); // �ϥβ�2��D��
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            inventory.UseItem(2); // �ϥβ�3��D��
        }
    }
}
