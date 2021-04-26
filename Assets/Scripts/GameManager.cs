using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject inventoryScreen;
    public GameObject equipmentScreen;
    public GameObject attributeScreen;
    public GameObject btnInventory;
    public GameObject btnEquipment;
    public GameObject btnAttribute;
    public Text playerAttributesText;
    bool inventoryOpened = false;
    bool equipmentOpened = false;
    bool attributesOpened = false;
    List<GameObject> itemList;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenCloseInventory();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenCloseEquipment();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            OpenCloseAttributes();
        }
    }

    public void UpdatePlayerAttributesText(string text)
    {
        playerAttributesText.text = text;
    }

    #region Show/Hide panels
    void OpenCloseInventory()
    {
        if (inventoryOpened)
            HideInventoryScreen();
        else
            ShowInventoryScreen();
    }

    void OpenCloseEquipment()
    {
        if (equipmentOpened)
            HideEquipmentScreen();
        else
            ShowEquipmentScreen();
    }

    void OpenCloseAttributes()
    {
        if (attributesOpened)
            HideAttributeScreen();
        else
            ShowAttributeScreen();
    }
    public void ShowInventoryScreen()
    {
        inventoryOpened = true;
        inventoryScreen.SetActive(true);
        btnInventory.SetActive(false);
    }

    public void HideInventoryScreen()
    {
        inventoryOpened = false;
        inventoryScreen.SetActive(false);
        btnInventory.SetActive(true);
    }

    public void ShowEquipmentScreen()
    {
        equipmentOpened = true;
        equipmentScreen.SetActive(true);
        btnEquipment.SetActive(false);
    }

    public void HideEquipmentScreen()
    {
        equipmentOpened = false;
        equipmentScreen.SetActive(false);
        btnEquipment.SetActive(true);
    }

    public void ShowAttributeScreen()
    {
        attributesOpened = true;
        attributeScreen.SetActive(true);
        btnAttribute.SetActive(false);
    }

    public void HideAttributeScreen()
    {
        attributesOpened = false;
        attributeScreen.SetActive(false);
        btnAttribute.SetActive(true);
    }
    #endregion

    public void FillInventory(List<GameObject> list)
    {
        itemList = list;
        for (int i = 0; i < itemList.Count; i++)
        {
            GameObject go = itemList[i];
            CheckItemType(go);
        }
    }

    void CheckItemType(GameObject go)
    {
        switch (go.GetComponent<Item>().GetType().Name)
        {
            case "EquipableItem":
                GameObject em = GameObject.Find("EquipmentManager");
                if (em.GetComponent<EquipmentManager>().CheckIfEquipmentSlotTaken(go))
                {
                    //Add item to new inventory slot
                }
                else
                {
                    em.GetComponent<EquipmentManager>().SetEquipment(go);
                }
                break;
            case "NonStackableItem":
                //Add to new inventory slot
                break;
            case "LimitedStackableItem":
                //Check if the same object exists in inventory
                //TRUE: Check if it is full
                ////TRUE: Add to new inventory slot
                ////FALSE: Add to stack
                //FALSE: Add to new inventory slot
                break;
            case "UnlimitedStackableItem":
                //Check if the same object exists in inventory
                //TRUE: Add to stack
                //FALSE: new inventory slot
                break;
        }
    }

}
