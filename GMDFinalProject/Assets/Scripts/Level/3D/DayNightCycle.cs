using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public GameObject sun;
    public GameObject moon;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sun.transform.RotateAround(Vector3.zero, Vector3.right, speed * Time.deltaTime);
        moon.transform.RotateAround(Vector3.zero, Vector3.right, speed * Time.deltaTime);
    }
}
