using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour, IInteractable
{
    public ShoppingItem item = new ShoppingItem();
    public void Interact()
    {
        Debug.Log(this.item.name);
    }

}
