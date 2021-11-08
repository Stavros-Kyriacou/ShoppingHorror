using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfUnit : MonoBehaviour, IInteractable
{
    public ShelfItem item;
    private void Start()
    {

    }
    public void Interact()
    {
        Debug.Log(LevelBuilder.Instance.GetShelfItemString(item));
    }
}
