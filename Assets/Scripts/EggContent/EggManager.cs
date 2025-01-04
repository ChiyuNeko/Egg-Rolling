using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EggContent;

public class EggManager : MonoBehaviour
{
    public EggContent.Egg egg = new Egg();
    public GameObject RespawnPoint;
    bool broken;
    void Start()
    {
        //RespawnPoint = egg.EggObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(egg.EggRigidbody.velocity.magnitude > 3)
        {
            broken = true;
        }
        else
        {
            broken = false;
        }
        
    }
    
    public void Respawn(GameObject _RespawnPoint)
    {
        egg.EggObject.transform.position = _RespawnPoint.transform.position;
        egg.EggRigidbody.velocity = Vector3.zero;

    }

    void OnCollisionEnter(Collision other)
    {
        if(broken && other.transform.tag == "Wall")
        {
            Debug.Log("Broken");
            Respawn(RespawnPoint);

        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Save Point")
        {
            RespawnPoint = other.gameObject;
        }
        
    }
}
