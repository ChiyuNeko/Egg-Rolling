using System.Collections;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public void Cube()
    {
        Debug.Log("�ڬO����I");
    }

    public void Sphere()
    {
        Debug.Log("�ڬO�y�I");
    }
    public void IronEgg()
    {
        Debug.Log("���J");
        GameObject Egg = GameObject.FindGameObjectsWithTag("Egg")[0];      
        Egg.transform.tag = "Iron Egg";
    }
    public void Boom()
    {
        Debug.Log("���u");
        GameObject Egg = GameObject.FindGameObjectsWithTag("Egg")[0];      
        Egg.GetComponent<Rigidbody>().AddForce(Vector3.back * 100);
    }
}
