using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float turnSpeed = 360;
    private Vector3 input;
    public Animator animator;

    void Start()
    {
        GameObject.Find("SummaryWindowCanvas").GetComponent<Canvas>().enabled = false;
    }
    void Update()
    {
        
        GatherInput();
        Look();
    }

    void FixedUpdate() {
        if(input.x != 0 || input.z != 0)
        {
            animator.SetBool("Moving", true);
            Move();

        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void GatherInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
    }

    void Look()
    {
        if(input != Vector3.zero)
        {
            var relative = (transform.position + input) - transform.position;
            var rot = Quaternion.LookRotation(relative,Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }
    }

    void Move()
    {
        rb.MovePosition(transform.position + (transform.forward * input.magnitude) * speed * Time.deltaTime);
    }
}
