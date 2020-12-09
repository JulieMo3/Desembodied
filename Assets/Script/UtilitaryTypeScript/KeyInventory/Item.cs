using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Inventory/Item" )]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}
