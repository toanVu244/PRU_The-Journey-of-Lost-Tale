using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Collectable[] collectablesItem;
    private Dictionary<Collectable.CollectableType, Collectable> collectableItemDict = new Dictionary<Collectable.CollectableType, Collectable>();

    public void Awake()
    {
        if (collectablesItem == null)
        {
            Debug.LogError("CollectablesItem list is not assigned.");
            return;
        }

        foreach (Collectable item in collectablesItem)
        {
            if (item == null)
            {
                Debug.LogError("A collectable item in the list is null.");
                continue;
            }

            AddItemToDict(item);
        }
    }

    public void AddItemToDict(Collectable item)
    {
        if (collectableItemDict == null)
        {
            Debug.LogError("CollectableItemDict dictionary is not initialized.");
            return;
        }

        if (!collectableItemDict.ContainsKey(item.type))
        {
            collectableItemDict.Add(item.type, item);
        }
    }

    public Collectable GetItemByType(Collectable.CollectableType type)
    {
        if(collectableItemDict.ContainsKey(type))
        {
            return collectableItemDict[type];
        }
        return null;
    }
}
