using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public Transform orientation;
    float horizontalInpunt;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
    }

    void Update()
    {
        MyInput();
    }

    void FixedUpdate() 
    {
        MovePlayer();    
    }

    private void MyInput()
    {
        horizontalInpunt = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInpunt;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10F, ForceMode.Force);
    }

}
