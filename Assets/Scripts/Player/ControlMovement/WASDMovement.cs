using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour, IMovement
{
    public float speed;
    public float rotationSpeed;
    public Rigidbody playerRB;
    private float horizontalMov;
    private float verticalMov;
    private float mouseY;
    private float mouseX;

    void Update()
    {
        horizontalMov = Input.GetAxis("Horizontal");
        verticalMov = Input.GetAxis("Vertical");
        mouseY = Input.GetAxis("Mouse Y");
        mouseX = Input.GetAxis("Mouse X");
        MoveZ(verticalMov);
        MoveX(horizontalMov);
        RotateY(mouseX);
        RotateX(mouseY);

    }

    public void MoveZ(float vertical)
    {
        //playerRB.AddForce(transform.forward * speed * vertical, ForceMode.VelocityChange);
        playerRB.velocity = transform.forward * speed * vertical;
    }
    public void MoveX(float horizontal)
    {
        transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime);
    }
    public void RotateY(float mouseY)
    {

    }
    public void RotateX(float mouseX)
    {

    }
    /*internal override void MoveForward()
    {
        
    }

    internal override void MoveBackwards()
    {
        playerRB.AddForce(-transform.forward * speed, ForceMode.VelocityChange);
    }

    internal override void MoveRight()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    internal override void MoveLeft()
    {
        transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
    }
    internal override void LookUp()
    {
        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0f, 0f));
    }

    internal override void LookDown()
    {
        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0f, 0f));
    }*/
}
