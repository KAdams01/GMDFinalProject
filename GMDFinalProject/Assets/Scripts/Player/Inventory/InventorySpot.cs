using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySpot
{
    public byte blockType;
    public int quantityOfBlock;
    // Start is called before the first frame update
    void Start()
    {
        blockType = 0;
        quantityOfBlock = 0;
    }
    public void setBlockType(byte block)
    {
        blockType = block;
    }
}
