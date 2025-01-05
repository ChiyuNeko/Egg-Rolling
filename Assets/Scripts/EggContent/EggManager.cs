using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EggContent;
using UnityEngine.Events;
using UnityEngine.UI;

public class EggManager : MonoBehaviour
{
    public PlayerSensor playerSensor;
    public Follow follow;
    public EffectsManager effectsManager;
    public EggContent.Egg egg = new Egg();
    public GameObject RespawnPoint;
    public List<Collider> ClearPoint = new List<Collider>();
    public Text ClearText;
    public UnityEvent BrokenEvent;
    public UnityEvent ClearEvent;
    public bool CanBroken;
    public bool broken;
    public bool clear;
    public bool Iron{get; set;}
    void Start()
    {
        //RespawnPoint = egg.EggObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(egg.EggObject.tag == "Iron Egg")
        {
            StartCoroutine(IronEggTimer());
        }
        
        if((egg.EggRigidbody.velocity.magnitude > 3) && egg.EggObject.transform.tag == "Egg")
        {
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
                Debug.Log(other.transform.name);
                Respawn(RespawnPoint);
                broken = true;
            }
        }
        if(other.transform.tag == "Rocket")
        {
            if(gameObject.transform.tag == "Egg")
            {
                Respawn(RespawnPoint);
                broken = true;
            }
        }
        if(other.transform.tag == "Clear" && !broken && !clear)
        {
            if(other.collider == ClearPoint[0])
            {
                ClearEvent?.Invoke();
                ClearText.text = "你把蛋推進火爐裡煮熟了";
            }
            if(other.collider == ClearPoint[1])
            {
                ClearEvent?.Invoke();
                ClearText.text = "你成功把蛋送回家吃上大餐了";
            }
            if(other.collider == ClearPoint[2])
            {
                ClearEvent?.Invoke();
                ClearText.text = "蛋掉進馬桶裡被沖走了";
            }
            clear = true;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Save Point")
        {
            RespawnPoint = other.gameObject;
        }
        
    }

    public IEnumerator IronEggTimer()
    {
        yield return new WaitForSeconds(3);
        egg.EggObject.tag = "Egg";
    }
}
