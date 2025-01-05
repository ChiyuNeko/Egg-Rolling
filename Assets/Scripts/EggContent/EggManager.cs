using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EggContent;
using UnityEngine.Events;

public class EggManager : MonoBehaviour
{
    public PlayerSensor playerSensor;
    public Follow follow;
    public EggContent.Egg egg = new Egg();
    public GameObject RespawnPoint;
    public UnityEvent BrokenEvent;
    public bool CanBroken;
    public bool broken;
    void Start()
    {
        //RespawnPoint = egg.EggObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(egg.EggRigidbody.velocity.magnitude > 3)
        {
            if(egg.EggObject.transform.tag == "Egg");
                CanBroken = true;
        }
        else
        {
            CanBroken = false;
        }
        
    }
    
    public void Respawn(GameObject _RespawnPoint)
    {
        //egg.EggObject.transform.position = _RespawnPoint.transform.position;
        egg.EggObject = Instantiate(egg.EggObject, _RespawnPoint.transform.position, Quaternion.identity);
        playerSensor.Egg = egg.EggObject.GetComponent<Rigidbody>();
        follow.Target = egg.EggObject;
        egg.EggRigidbody.velocity = Vector3.zero;
        BrokenEvent?.Invoke();

    }

    void OnCollisionEnter(Collision other)
    {
        if(CanBroken && other.transform.tag == "Wall")
        {
            if(!broken)
            {
                Debug.Log("Broken");
                Respawn(RespawnPoint);
                broken =true;
            }

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
