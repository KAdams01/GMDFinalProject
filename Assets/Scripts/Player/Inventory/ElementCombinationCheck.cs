using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ElementCombinationCheck
{
    public static byte CombinationCheck(byte inventoryBlock, byte blockHit)
    {
        if (inventoryBlock == 3 && blockHit == 3)
        {
            return 6;
        }
        //this was a test, currently turns stone to metal if using earth on it and earth to metal if using stone on it.
        if(inventoryBlock == 1 && blockHit == 2 || inventoryBlock == 2 && blockHit == 1)
        {
            return 9;
        }
        else return inventoryBlock;
    }
}
