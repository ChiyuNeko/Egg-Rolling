using System.Collections;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public void Cube()
    {
        Debug.Log("我是方塊！");
    }

    public void Sphere()
    {
        Debug.Log("我是球！");
    }
    public void IronEgg()
    {
        Debug.Log("鋼蛋");
        GameObject Egg = GameObject.FindGameObjectsWithTag("Egg")[0];      
        Egg.transform.tag = "Iron Egg";
    }
    public void Boom()
    {
        Debug.Log("炸彈");
        GameObject Egg = GameObject.FindGameObjectsWithTag("Egg")[0];      
        Egg.GetComponent<Rigidbody>().AddForce(Vector3.back * 100);
    }
}
