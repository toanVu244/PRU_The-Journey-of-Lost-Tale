using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blankInventorySlot;
    [SerializeField]
    private GameObject backGroundpanel;
    [SerializeField]
    private GameObject inventoryPanel;
    public PlayerInventory playerInventory;
    
    public void CreateInventorySlot()
    {
        if(blankInventorySlot)
        {
            for(int i = 0; i < playerInventory.currentInventory.Count; i++)
            {
                if (playerInventory.currentInventory[i].numberHeld > 0)
                {
                    GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                    temp.transform.SetParent(inventoryPanel.transform);
                    InventorySlots newSlot = temp.GetComponent<InventorySlots>();
                    if (newSlot)
                    {
                        newSlot.SetUp(playerInventory.currentInventory[i], this);
                    }
                }
            }
        }
    }

    public void ToggleInvertoryUI()
    {
        if (!backGroundpanel.activeSelf)
        {
            ClearInventorySlot();
            CreateInventorySlot();
            backGroundpanel.SetActive(true);
        }
        else
        {
            ClearInventorySlot();
            CreateInventorySlot();
            backGroundpanel.SetActive(false);
        }
    }

    public void ClearInventorySlot()
    {
        for(int i = 0; i< inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }

    private void Start()
    {
        ClearInventorySlot();
        CreateInventorySlot();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInvertoryUI();
        }
    }
}
