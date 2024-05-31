using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Inventory 
{
    [System.Serializable]
    public class Slot
    {
        public Collectable.CollectableType type;
        public int count;
        public int MaxAllowed;
        public Sprite icon;
        public Slot()
        {
            type = Collectable.CollectableType.None;
            count = 0;
            MaxAllowed = 99;
        }
        public bool CanAddItem()
        {
            if(count < MaxAllowed) 
            {
                return true;
            }
            return false;
        }

        public void AddItem(Collectable item)
        {
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }

        public void DropItem()
        {
            if(count > 0)
            {
                count--;
                if(count == 0)
                {
                    icon = null;
                    type = Collectable.CollectableType.None;
                }
            }
        }
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlot) 
    {
        for(int i = 0; i < numSlot; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(Collectable item) 
    {
        foreach (Slot slot in slots)
        {
            if(slot.type == item.type && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
            else if(slot.type == Collectable.CollectableType.None)
            {
                slot.AddItem(item);
                return;
            }
        }
    }

    public void Drop(int index)
    {
        slots[index].DropItem();
    }
}
