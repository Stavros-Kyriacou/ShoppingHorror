using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public static LevelBuilder Instance;
    public Player player;
    public List<ItemDisplay> shelves = new List<ItemDisplay>();
    public List<ShelfItem> activeItems = new List<ShelfItem>();
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        AssignShelfItems();
    }
    public void AssignShelfItems()
    {
        var shuffledShelfItems = Ext.Shuffle<string>(ItemData.shelfItems);

        for (int i = 0; i < shelves.Count; i++)
        {
            shelves[i].item.name = shuffledShelfItems[i];
            shelves[i].item.collected = false;
            shelves[i].item.location = StoreLocation.Shelf;
        }

        // var items = Enum.GetValues(typeof(ShelfItem)).Cast<ShelfItem>().ToList();
        // List<ShelfItem> randomItems = new List<ShelfItem>();

        // randomItems = Ext.Shuffle<ShelfItem>(items);

        // for (int i = 0; i < shelfUnits.Count; i++)
        // {
        //     shelfUnits[i].item = randomItems[i];
        //     activeItems.Add(randomItems[i]);
        // }
    }
    public string GetShelfItemString(ShelfItem shelfItem)
    {
        string item = "";
        switch (shelfItem)
        {
            case ShelfItem.Chips:
                item = "Chips";
                break;
            case ShelfItem.Beans:
                item = "Beans";
                break;
            case ShelfItem.TomatoSauce:
                item = "Tomato Sauce";
                break;
            case ShelfItem.Mustard:
                item = "Mustard";
                break;
            case ShelfItem.Salt:
                item = "Salt";
                break;
            case ShelfItem.Pepper:
                item = "Pepper";
                break;
            case ShelfItem.Pickles:
                item = "Pickles";
                break;
            case ShelfItem.Noodles:
                item = "Noodles";
                break;
            case ShelfItem.Pasta:
                item = "Pasta";
                break;
            case ShelfItem.Flour:
                item = "Flour";
                break;
            default:
                item = "Not implemented";
                break;
        }
        return item;
    }
}