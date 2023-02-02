using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody playerRb;
    public float speed = 2;
    private Vector3 movement;
    private float rotationSpeed = 4;
    private float runningSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }


    public void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        runningSpeed = vertical;

        movement = new Vector3(0, 0f, (runningSpeed * 8));// Multiplier of 8 seems to work well with Rigidbody Mass of 1.
        //float directionLength = movement.magnitude;//----------------->>>
        //movement = movement.normalized * directionLength;//------------>>>>
        if (movement != Vector3.zero)
        {
            movement = transform.TransformDirection(movement);// transform correction A.K.A. "Move the way we are facing"
        }
        
        //playerRb.AddForce(movement * moveSpeed);// Movement Force
        playerRb.MovePosition(transform.position + (movement * speed));

        // captures the movement and rotate according the axis
        if ((Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f))
        {
            if (Input.GetAxis("Vertical") >= 0)
                transform.Rotate(new Vector3(0, horizontal * rotationSpeed, 0));
            else
                transform.Rotate(new Vector3(0, -horizontal * rotationSpeed, 0));
        }
    }
}
