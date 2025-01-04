using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;
    public float speed = 0;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
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

        if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Walk", true);
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, speed);
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Walk", false);
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Walk", true);
            rigidbody.velocity = new Vector3(-speed, rigidbody.velocity.y, 0);
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Walk", false);
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Walk", true);
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, -speed);
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Walk", false);
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Walk", true);
            rigidbody.velocity = new Vector3(speed, rigidbody.velocity.y, 0);
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Walk", false);
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
        }
    }
}
