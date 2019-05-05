using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance;

    //Unity Inputs
    private float xAxis;
    private float yAxis;

    //InputType
    public enum MovementStates { WASD, Camera}

    public MovementStates current;

    //KeyActions
    //Horizontal
    public delegate void RotateRight();
    public event RotateRight rotateRight;
    public delegate void RotateLeft();
    public event RotateLeft rotateLeft;

    //Vertical
    public delegate void VerticalMoveUp();
    public event VerticalMoveUp vMoveUp;
    public delegate void VerticalMoveDown();
    public event VerticalMoveDown vMoveDown;
    public delegate void VerticalMovementNone();
    public event VerticalMovementNone vMoveNone;
    public delegate void LookUp();
    public event LookUp lookUp;
    public delegate void LookDown();
    public event LookDown lookDown;

    //O key
    public delegate void OKeyPressed();
    public event OKeyPressed oKeyPressed;

    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)

            //if not, set instance to this
            Instance = this;

        //If instance already exists and it's not this:
        else if (Instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != yAxis && current == MovementStates.WASD)
        {
            yAxis = Input.GetAxis("Horizontal");
        }
        if (Input.GetAxis("Mouse X") != 0 && current == MovementStates.Camera)
        {
            yAxis = Input.GetAxis("Mouse X");
        }
        if (yAxis > 0.1)
        {
            rotateRight();
        }
        else if (yAxis < -0.1)
        {
            rotateLeft();
        }
        if (Input.GetAxis("Vertical") != xAxis)
        {
            xAxis = Input.GetAxis("Vertical");
        }
        switch (xAxis)
        {
            case 1:
                vMoveUp();
                break;
            case -1:
                vMoveDown();
                break;
            default:
                vMoveNone();
                break;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            oKeyPressed();
        }
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Mouse Y") > 0.1)
        {
            lookUp();
        }
        else if (Input.GetAxis("Mouse Y") < -0.1)
        {
            lookDown();
        }
    }
}
