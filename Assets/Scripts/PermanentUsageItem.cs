using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentUsageItem : Item
{
    private void OnDestroy()
    {
        Debug.Log("You have collected permanent-usage item: " + itemName + "!");
    }
}