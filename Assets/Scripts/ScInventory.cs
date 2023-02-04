using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory", order = 1)]
public class ScInventory : ScriptableObject
{
        public Dictionary<string, List<IInteractable>> Collected = new Dictionary<string, List<IInteractable>>();

        public void Add(string name, IInteractable obj)
        {
                if (Collected.TryGetValue(name, out List<IInteractable> values))
                {
                        values.Add(obj);
                }
                else
                {
                        Collected.Add(name, new List<IInteractable>() { obj });
                }
        }

        public int GetObjectCount(string name)
        {
                if (Collected.TryGetValue(name, out List<IInteractable> values))
                {
                        return values.Count;
                }
                else
                {
                        return 0;
                }
        }

        private void OnEnable()
        {
                Collected.Clear();
        }
}