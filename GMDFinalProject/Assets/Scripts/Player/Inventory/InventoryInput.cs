using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    private InventoryManager invManager;
    // Start is called before the first frame update
    void Start()
    {
        invManager = GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            invManager.IncrementSelectedInventorySpot();
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            invManager.DecrementSelectedInventorySpot();
        }
        if (Input.GetKey(KeyCode.L)){
            invManager.setLegendVisible(true);
        }
        else
        {
            invManager.setLegendVisible(false);
        }
    }
}
