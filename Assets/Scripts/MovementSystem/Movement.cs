using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            animator.SetBool("LeftHand", true);
        }
        if(Input.GetMouseButtonUp(0))
        {
            animator.SetBool("LeftHand", false);
        }
        if(Input.GetMouseButton(1))
        {
            animator.SetBool("RightHand", true);
        }
        if(Input.GetMouseButtonUp(1))
        {
            animator.SetBool("RightHand", false);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Walk", true);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Walk", false);
        }
    }
}
