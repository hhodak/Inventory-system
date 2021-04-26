using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    public Image helmetImage;
    public GameObject helmetButton;
    bool helmetUsed = false;
    public Image plateImage;
    public GameObject plateButton;
    bool plateUsed = false;
    public Image leggingsImage;
    public GameObject leggingsButton;
    bool leggingsUsed = false;
    public Image bootsImage;
    public GameObject bootsButton;
    bool bootsUsed = false;

    #region Checking equipment
    public bool CheckIfEquipmentSlotTaken(GameObject equipment)
    {
        if (equipment.GetComponent<EquipableItem>() != null)
        {
            switch (equipment.GetComponent<EquipableItem>().equipmentType.ToString())
            {
                case "Helmet":
                    return helmetUsed;
                case "Plate":
                    return plateUsed;
                case "Leggings":
                    return leggingsUsed;
                case "Boots":
                    return bootsUsed;
            }
        }
        return true;
    }
    #endregion

    #region Setting equipment
    public void SetEquipment(GameObject equipment)
    {
        switch (equipment.GetComponent<EquipableItem>().equipmentType.ToString())
        {
            case "Helmet":
                SetHelmet(equipment);
                break;
            case "Plate":
                SetPlate(equipment);
                break;
            case "Leggings":
                SetLeggings(equipment);
                break;
            case "Boots":
                SetBoots(equipment);
                break;
        }
    }

    void SetHelmet(GameObject helmet)
    {
        helmetImage.sprite = helmet.GetComponent<SpriteRenderer>().sprite;
        helmetImage.color = new Color(255, 255, 255, 255);
        helmetButton.SetActive(true);
        helmetUsed = true;
    }

    void SetPlate(GameObject plate)
    {
        plateImage.sprite = plate.GetComponent<SpriteRenderer>().sprite;
        plateImage.color = new Color(255, 255, 255, 255);
        plateButton.SetActive(true);
        plateUsed = true;
    }

    void SetLeggings(GameObject leggings)
    {
        leggingsImage.sprite = leggings.GetComponent<SpriteRenderer>().sprite;
        leggingsImage.color = new Color(255, 255, 255, 255);
        leggingsButton.SetActive(true);
        leggingsUsed = true;
    }

    void SetBoots(GameObject boots)
    {
        bootsImage.sprite = boots.GetComponent<SpriteRenderer>().sprite;
        bootsImage.color = new Color(255, 255, 255, 255);
        bootsButton.SetActive(true);
        bootsUsed = true;
    }
    #endregion

    #region Removing equipment
    public void RemoveHelmet()
    {
        helmetImage.sprite = null;
        helmetImage.color = new Color(0, 0, 0, 0);
        helmetButton.SetActive(false);
        helmetUsed = false;
    }

    public void RemovePlate()
    {
        plateImage.sprite = null;
        plateImage.color = new Color(0, 0, 0, 0);
        plateButton.SetActive(false);
        plateUsed = false;
    }

    public void RemoveLeggings()
    {
        leggingsImage.sprite = null;
        leggingsImage.color = new Color(0, 0, 0, 0);
        leggingsButton.SetActive(false);
        leggingsUsed = false;
    }

    public void RemoveBoots()
    {
        bootsImage.sprite = null;
        bootsImage.color = new Color(0, 0, 0, 0);
        bootsButton.SetActive(false);
        bootsUsed = false;
    }
    #endregion
}
