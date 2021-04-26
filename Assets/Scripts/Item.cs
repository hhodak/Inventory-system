using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    public string description;
    public void Collected()
    {
        Destroy(gameObject);
    }
}