using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueEvent : MonoBehaviour
{
    public GameObject Player;
    public GameObject Egg;
    public  UnityEvent unityEvent;
    public void TriggerEvent()
    {
        unityEvent?.Invoke();
    }

    public void TranslateTo(Transform target)
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        Egg = GameObject.FindGameObjectsWithTag("Egg")[0];
        Player.transform.position = target.position;
        Egg.transform.position = target.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Egg")
        {
            TriggerEvent();
        }
    }
}
 

