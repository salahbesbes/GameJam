using UnityEngine;
using UnityEngine.UI;

public class LaserInteraction : MonoBehaviour
{
        private Transform CameraRoot;
        public LayerMask intetactableLayer;
        public ScInventory inventory;
        private bool StartTracing = false;
    
        public GameObject pointer;
        public GameObject pointer01;

        private void Start()
        {
                CameraRoot = Camera.main.transform;
                
        }

        public void SetStartTracing(bool tracing)
        {
                StartTracing = tracing;
        }

        private void Update()
        {
                if (StartTracing == false) return;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                Debug.DrawRay(ray.origin, ray.direction);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 200, intetactableLayer))
                {
                        /*  hit some interactable Actor */
                        IInteractable InteractObj = hit.transform.GetComponent<IInteractable>();

                        if (InteractObj == null) return;

                    // Show or update pointer
                    if (InteractObj != null)
                    {
                        pointer.enable = 
                    }
                    else
                    {
                        pointer.gameObject.SetActive(false);
                        pointer01.gameObject.SetActive(true);
                        pointer01.transform.position = hit.point;
                    }

            if (Input.GetMouseButtonDown(0))
                        {
                                InteractObj.Interact();
                                inventory.Add(hit.transform.name, InteractObj);
                                Debug.Log($"found {inventory.GetObjectCount(hit.transform.name)} {hit.transform.name}");
                        }
                }
        }
}