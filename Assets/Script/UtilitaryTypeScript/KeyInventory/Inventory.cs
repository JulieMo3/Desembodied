using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallBack;
    public int space = 4;
    public List<Item> items = new List<Item>();

    public bool Add( Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space) 
            {
                Debug.Log("Not enough place");
                return false;
            }
            items.Add(item);
            if(onItemChangeCallBack != null)
            {
                onItemChangeCallBack.Invoke();
            }
            

        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangeCallBack != null)
        {
            onItemChangeCallBack.Invoke();
        }
    }
}
