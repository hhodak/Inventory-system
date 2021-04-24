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

}
