using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraToggle : MonoBehaviour
{
    private InputHandler inputHandler;

    public Transform[] transforms;
    private Camera cam;

    private int numberInTransformArray;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        numberInTransformArray = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ToggleCameraPosition();
        }
    }

    void ToggleCameraPosition()
    {
        if (numberInTransformArray > transforms.Length-1)
        {
            numberInTransformArray = 0;
        }

        cam.transform.position = transforms[numberInTransformArray].position;
        cam.transform.rotation = transforms[numberInTransformArray].rotation;
        numberInTransformArray++;
    }
}
