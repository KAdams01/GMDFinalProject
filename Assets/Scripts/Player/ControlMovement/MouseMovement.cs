using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour, IMovement
{
    public float speed;
    public float rotationSpeed;
    public float maxSpeed;
    public Rigidbody playerRB;
    private float horizontalMov;
    private float verticalMov;
    private float mouseY;
    private float mouseX;
    private float jump;
    public float jumpVelocity;
    private bool grounded = true;

    //Events
    public delegate void MovingForward();
    public static event MovingForward movingForward;

    public delegate void MovingNone();
    public static event MovingNone movingNone;


    void Update()
    {
        horizontalMov = Input.GetAxis("Horizontal");
        verticalMov = Input.GetAxis("Vertical");
        mouseY = Input.GetAxis("Mouse Y");
        mouseX = Input.GetAxis("Mouse X");
        jump = Input.GetAxis("Jump");
        MoveZ(verticalMov);
        MoveX(horizontalMov);
        RotateY(mouseX);
        RotateX(mouseY);
        if(jump == 1)
        {
            if (grounded)
            {
                Jump();
                grounded = false;
            }           
        }
        


    }
    private void Jump()
    {
        Debug.Log("Jump");
        playerRB.velocity = Vector3.up * jumpVelocity;
    }

    public void MoveZ(float vertical)
    {
        if(vertical == 0)
        {
            movingNone();
        }
        else
        {
            if(vertical > 0)
            {
                playerRB.velocity += transform.forward * (Mathf.Clamp(speed, 0, maxSpeed) * Time.deltaTime);
            } else if(vertical < 0)
            {
                playerRB.velocity += -transform.forward * (Mathf.Clamp(speed, 0, maxSpeed) * Time.deltaTime);
            }
            
            //transform.position += transform.forward * speed * vertical * Time.deltaTime;
            /*playerRB.AddForce(transform.forward * speed * vertical, ForceMode.Acceleration);
            if(playerRB.velocity.magnitude > 5)
            {
                playerRB.velocity = playerRB.velocity.normalized * 5;
            }*/
            movingForward();
        }
    }
    public void MoveX(float horizontal)
    {
        if(horizontal > 0)
        {
            playerRB.velocity += transform.right * (Mathf.Clamp(speed, 0, maxSpeed) * Time.deltaTime);
        } else if(horizontal < 0)
        {
            playerRB.velocity += -transform.right * (Mathf.Clamp(speed, 0, maxSpeed) * Time.deltaTime);
        }
        //playerRB.AddForce(transform.right * speed * horizontal, ForceMode.VelocityChange);
    }
    public void RotateY(float mouseY)
    {
        transform.Rotate(Vector3.up * mouseY * rotationSpeed * Time.deltaTime);
    }
    public void RotateX(float mouseX)
    {
        Transform camTransform = Camera.main.transform;
        camTransform.Rotate(Vector3.right * -mouseX * rotationSpeed * Time.deltaTime);
        Vector3 currentRotation = camTransform.localRotation.eulerAngles;
        currentRotation.x = AngleClamper.ClampBetweenAngles(currentRotation.x, -80, 80);
        camTransform.localRotation = Quaternion.Euler(currentRotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
}
