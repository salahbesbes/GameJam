using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
        public ScInventory inventoryPrefab;

      
        public void AddCollected(string name, IInteractable obj)
        {
                inventoryPrefab.Add(name, obj);
                CheckForKeys(name);
        }

        public void CheckForKeys(string name)
        {
                Debug.Log($" Collected {inventoryPrefab.GetObjectCount(name)} {name}");
        }
}