using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Selectable
{
        private bool rotating = false;
        private int direction = 1;

        public float rotationAngle = 90;
        public float rotationSpeed = 2;

        public bool isLocked = true;
        public int id;

        public void unlock()
        {
                isLocked = false;
        }

        public override void Interact()
        {
                base.Interact();
                if (rotating == false)
                {
                        if (isLocked == false)
                        {
                                StartCoroutine(Rotate90(transform.parent));
                                direction *= -1;
                        }
                        else
                        {
                                Debug.Log($"Door IS locked we try to find the key frm the inventory");
                                LaserInteraction.instance.inventory.Collected.TryGetValue("Key", out List<IInteractable> values);
                                if (values == null) return;

                                foreach (IInteractable item in values)
                                {
                                        keyInteractable key = item as keyInteractable;
                                        if (key.id == id)
                                        {
                                                unlock();
                                                break;
                                        }
                                }
                        }
                }
        }

        private IEnumerator Rotate90(Transform parent)
        {
                rotating = true;
                float timeElapsed = 0;
                Quaternion startRotation = parent.transform.rotation;
                Quaternion targetRotation = parent.transform.rotation * Quaternion.Euler(0, 0, rotationAngle * direction);
                while (timeElapsed < rotationSpeed)
                {
                        parent.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / rotationSpeed);
                        timeElapsed += Time.deltaTime;
                        yield return null;
                }
                parent.transform.rotation = targetRotation;
                rotating = false;
        }

        private void OnGUI()
        {
                if (now)
                {
                        GUI.Box(new Rect(0, 0, 200, 25), "Press mouse 0 to open");
                }
                else
                {
                        GUI.Box(new Rect(0, 0, 200, 25), "Need a key!");
                }
        }
}