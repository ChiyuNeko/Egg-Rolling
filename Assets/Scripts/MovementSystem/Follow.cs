using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject Follower;
    public GameObject Target;
    public Vector3 Offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Follower.transform.position = Target.transform.position  + Offset;
    }
}