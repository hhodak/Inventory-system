using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableItem : PickupableItem
{
    public enum EquipmentType { Helmet, Plate, Leggings, Boots }
    public EquipmentType equipmentType;
}