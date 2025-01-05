using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    public float force;
    public Rigidbody Egg;
    public bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flag)
        {

            if(Input.GetMouseButton(0))
                {
                    Egg.AddForce(new Vector3(-force, 0, -force));
                }
            else if(Input.GetMouseButton(1))
            {
                Egg.AddForce(new Vector3(force, 0, -force));
            }
            else if(Input.GetMouseButton(0) && Input.GetMouseButton(1))
            {
                Egg.velocity = new Vector3(0, Egg.velocity.y, 0);
            }
            if(Input.GetKey(KeyCode.Space))
            {
                Egg.AddForce(new Vector3(0, 0, force));
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Egg Collider")
        {
            flag = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        flag = false;
    }
}
