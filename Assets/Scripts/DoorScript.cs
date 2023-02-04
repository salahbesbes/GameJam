using UnityEngine;

public class DoorScript : MonoBehaviour
{
        public static bool doorKey;
        public bool open;
        public bool close;
        public bool inTrigger;

        public static bool isLocked = true;
        public GameObject key;

        private void Update()
        {
                if (!isLocked)
                {
                        Door.now = true;
                }
        }

        private void OnTriggerEnter(Collider other)
        {
                if (other.gameObject == key)
                {
                        Debug.Log("key Up");
                        isLocked = false;
                }
        }
}