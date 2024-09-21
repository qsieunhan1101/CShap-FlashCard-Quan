using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField] List<Item> level_0;
    [SerializeField] List<Item> level_1;
    [SerializeField] List<Item> level_2;
    [SerializeField] List<Item> level_3;


    public List<Item> GetListItems(int level)
    {
        switch (level)
        {
            case 0:
                return level_0;
            case 1:
                return level_1;
            case 2:
                return level_2;
            case 3:
                return level_3;
        }
        return level_0;
    }
}

[Serializable]
public class Item
{
    public Sprite image;
    public string text;
}
