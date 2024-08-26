using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 3f;//given default value of speed as 3f
    // Start called at start of program(one time)
    //[SerializeField] Transform groundcheck;
    //[SerializeField] LayerMask ground;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update called one time for every frame
    void Update()
    {
        //Use GetAxis function
        float horizortialNo = Input.GetAxis("Horizontal");
        float verticalNo = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizortialNo * speed, rb.velocity.y, verticalNo * speed);
        

    }
    
}
