using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public enum Attributes { Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma }
    public Dictionary<Attributes, int> attributes = new Dictionary<Attributes, int>();
    public float speed;
    float horizontalMovement = 0;
    float verticalMovement = 0;
    public Animator animator;
    public List<GameObject> inventoryList;

    void Start()
    {
        SetPlayerAttributes();
    }

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        animator.SetFloat("HorizontalMovement", horizontalMovement);
        animator.SetFloat("VerticalMovement", verticalMovement);
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + new Vector2(horizontalMovement, verticalMovement), speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            GameObject go = Instantiate(collision.gameObject, transform);
            go.SetActive(false);
            inventoryList.Add(go);
            collision.GetComponent<Item>().Collected();
        }
    }

    #region Attributes
    void SetPlayerAttributes()
    {
        foreach (Attributes attr in Enum.GetValues(typeof(Attributes)))
        {
            attributes.Add(attr, SetInitialAttributeValue());
            UpdateAttributeText();
        }
    }

    int SetInitialAttributeValue()
    {
        return UnityEngine.Random.Range(3, 18);
    }

    public void UpdateAttribute(string key, int value)
    {
        foreach (Attributes attr in attributes.Keys)
        {
            if (attr.ToString() == key)
            {
                attributes[attr] = value;
                UpdateAttributeText();
                break;
            }
        }
    }

    void UpdateAttributeText()
    {
        string text = "";
        foreach (Attributes attr in attributes.Keys)
        {
            text += attr.ToString() + ": " + attributes[attr] + "\n";
        }
        GameObject.Find("GameManager").GetComponent<GameManager>().UpdatePlayerAttributesText(text);
    }
    #endregion
}
