using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
        public ScInventory inventoryPrefab;

        public List<GameObject> keys;

        public void AddKey(GameObject key)
        {
                keys.Add(key);
        }

        public bool HasKey(GameObject doorKey)
        {
                return keys.Contains(doorKey);
        }

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