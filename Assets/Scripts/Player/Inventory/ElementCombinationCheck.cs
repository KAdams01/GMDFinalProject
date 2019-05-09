using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ElementCombinationCheck
{
    //Inventory slots:
    //0 - empty
    //1 - stone
    //2 - dirt
    //3 - wood
    //4 - water
    //5 - sand
    //6 - fire
    //7 - clay
    //8 - metal
    //9 - brick
    public static byte CombinationCheck(byte inventoryBlock, byte blockHit)
    {
        //Fire: wood + wood OR wood + stone OR stone + wood
        if (inventoryBlock == 3 && blockHit == 3 || inventoryBlock == 3 && blockHit == 1 || inventoryBlock == 1 && blockHit == 3)
        {
            return 6;
        }
        //Sand: stone + stone
        else if (inventoryBlock == 1 && blockHit == 1)
        {
            return 5;
        }
        //Clay: water + sand OR sand + water
        else if (inventoryBlock == 4 && blockHit == 5 || inventoryBlock == 5 && blockHit == 4)
        {
            return 7;
        }
        //Brick: clay + fire OR fire + clay
        else if(inventoryBlock == 7 && blockHit == 6 || inventoryBlock == 6 && blockHit == 7)
        {
            return 9;
        }
        //Metal: stone + fire || fire + stone
        else if (inventoryBlock == 1 && blockHit == 6 || inventoryBlock == 6 && blockHit == 1)
        {
            return 8;
        }
        else return inventoryBlock;
    }
}
