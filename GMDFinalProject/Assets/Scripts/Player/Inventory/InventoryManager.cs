using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private InventorySpot[] inventSpots;
    public Sprite[] inventImages;
    public Image[] currentlyInInvent;
    [HideInInspector]
    public static InventorySpot currentlySelectedInventorySpot;
    //should be private, set to public for testing
    [HideInInspector]
    public int inventArrayLocation;
    public GameObject inventorySpot;
    public GameObject Legend;
    private bool currentLegendVisibility;

    public bool creative;

    private Color zeroAlpha = new Color(0,0,0,0);

    private Color fullAlpha = new Color(1,1,1,1);
    // Start is called before the first frame update
    void Start()
    {
        currentLegendVisibility = false;
        inventArrayLocation = 0;
        zeroAlpha.a = 0;
        fullAlpha.a = 1;
        inventSpots = new InventorySpot[8];
        FillInventory(creative);
        UpdateInventory();
        currentlySelectedInventorySpot = inventSpots[inventArrayLocation];
    }

    private void FillInventory(bool creative)
    {
        if (creative)
        {
            for (int i = 0; i < inventSpots.Length; i++)
            {
                inventSpots[i] = new InventorySpot();
                if (creative)
                {
                    inventSpots[i].blockType = (byte)(i);
                }
            }
        }
        else
        {
            for (int i = 0; i < inventSpots.Length; i++)
            {
                inventSpots[i] = new InventorySpot();
                if (creative)
                {
                    inventSpots[i].blockType = (byte)(0);
                }
            }
        }

    }

    public void UpdateInventory()
    {
        for (int i = 0; i < inventSpots.Length;i++)
        {
            switch (inventSpots[i].blockType)
            {
                case 0:
                    currentlyInInvent[i].color = zeroAlpha;
                    break;
                case 1:
                    currentlyInInvent[i].sprite = inventImages[1];
                    currentlyInInvent[i].color = fullAlpha;
                    break;
                case 2:
                    currentlyInInvent[i].sprite = inventImages[2];
                    currentlyInInvent[i].color = fullAlpha;
                    break;
                case 3:
                    currentlyInInvent[i].sprite = inventImages[3];
                    currentlyInInvent[i].color = fullAlpha;
                    break;
                case 4:
                    currentlyInInvent[i].sprite = inventImages[4];
                    currentlyInInvent[i].color = fullAlpha;
                    break;
                case 5:
                    currentlyInInvent[i].sprite = inventImages[5];
                    currentlyInInvent[i].color = fullAlpha;
                    break;
                case 6:
                    currentlyInInvent[i].sprite = inventImages[6];
                    currentlyInInvent[i].color = fullAlpha;
                    break;
                case 7:
                    currentlyInInvent[i].sprite = inventImages[7];
                    currentlyInInvent[i].color = fullAlpha;
                    break;
                case 8:
                    currentlyInInvent[i].sprite = inventImages[8];
                    currentlyInInvent[i].color = fullAlpha;
                    break;
                case 9:
                    currentlyInInvent[i].sprite = inventImages[9];
                    currentlyInInvent[i].color = fullAlpha;
                    break;
                default:
                    currentlyInInvent[i].color = zeroAlpha;
                    break;
            }
        }
    }
    public void IncrementSelectedInventorySpot()
    {
        if(inventArrayLocation == inventSpots.Length - 1)
        {
            inventorySpot.transform.Translate(-700, 0, 0);
            inventArrayLocation = 0;
            currentlySelectedInventorySpot = inventSpots[inventArrayLocation];
        }else
        {
            inventorySpot.transform.Translate(100, 0, 0);
            inventArrayLocation++;
            currentlySelectedInventorySpot = inventSpots[inventArrayLocation];
        }
        
    }
    public void DecrementSelectedInventorySpot()
    {
        if(inventArrayLocation == 0)
        {
            inventorySpot.transform.Translate(700, 0, 0);
            inventArrayLocation = inventSpots.Length-1;
            currentlySelectedInventorySpot = inventSpots[inventArrayLocation];
        }else
        {
            inventorySpot.transform.Translate(-100, 0, 0);
            inventArrayLocation--;
            currentlySelectedInventorySpot = inventSpots[inventArrayLocation];
        }
    }
    public void setLegendVisible(bool legendVisible)
    {
        if(legendVisible != currentLegendVisibility)
        {
            Legend.SetActive(legendVisible);
            currentLegendVisibility = legendVisible;
        }

    }
}
