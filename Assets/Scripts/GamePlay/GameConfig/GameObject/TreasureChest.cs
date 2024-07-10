using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : InteractableObject
{
    public bool isOpen = false;
    public InventoryItem contents;
    public PlayerInventory playerInvetory; 
    public GameObject receiveItemLog;
    public Image imgItem;
    public TextMeshProUGUI itemName;
    private Animator chestAnimator;

    // Start is called before the first frame update
    void Start()
    {
        chestAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            if(!isOpen)
            {
                OpenChest();
            }
        }
    }

    public void OpenChest()
    {
        receiveItemLog.SetActive(true);
        itemName.text = "You have receive        " + contents.itemName;
        imgItem.sprite = contents.itemImage;
        playerInvetory.currentInventory.Add(contents);
        contents.numberHeld++;
        chestAnimator.SetBool("isOpened", true);
        isOpen = true;
        StartWaiting(result =>
        {
            if (result)
            {
                receiveItemLog.SetActive(false);
            }
        });
    }

    public void StartWaiting(System.Action<bool> callback)
    {
        StartCoroutine(WaitAndReturnTrue(callback));        
    }
    private IEnumerator WaitAndReturnTrue(System.Action<bool> callback)
    {
        yield return new WaitForSeconds(4f);
        callback(true);
    }
}
