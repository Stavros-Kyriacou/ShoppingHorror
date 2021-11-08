using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera playerCam;
    public GameObject flashLight;
    public List<ShoppingItem> shoppingList = new List<ShoppingItem>();
    public int shoppingListSize;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
        if (Input.GetMouseButtonDown(0))
        {
            ToggleFlashlight();
        }
    }
    private void Start()
    {
        GenerateShoppingList();
    }
    public void GenerateShoppingList()
    {
        var randomShelfItems = Ext.Shuffle<string>(ItemData.shelfItems);

        for (int i = 0; i < shoppingListSize; i++)
        {
            shoppingList.Add(new ShoppingItem()
            {
                name = randomShelfItems[i],
                collected = false,
                location = StoreLocation.Shelf
            });
        }
        Debug.Log("Shopping List");
        foreach (var item in shoppingList)
        {
            Debug.Log(item.name);
        }
    }
    public void ToggleFlashlight()
    {
        if (flashLight.activeInHierarchy)
        {
            flashLight.SetActive(false);
        }
        else 
        {
            flashLight.SetActive(true);
        }
    }
    public void Interact()
    {
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var interactable = hit.collider.GetComponent<IInteractable>();

            interactable?.Interact();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 dir = playerCam.transform.forward * 100f;
        Gizmos.DrawRay(playerCam.transform.position, dir);
    }
}
