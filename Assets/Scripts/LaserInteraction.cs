using UnityEngine;

public class LaserInteraction : MonoBehaviour
{
        private Transform CameraRoot;
        public LayerMask intetactableLayer;
        public ScInventory inventory;
        private bool StartTracing = false;

        public static LaserInteraction instance;

        private void Awake()
        {
                if (instance == null)
                {
                        instance = this;
                }
        }

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

                if (Physics.Raycast(ray, out hit, 100, intetactableLayer))
                {
                        /*  hit some interactable Actor */
                        IInteractable InteractObj = hit.transform.GetComponent<IInteractable>();

                        if (InteractObj == null) return;

                        // Show or update pointer

                        if (Input.GetMouseButtonDown(0))
                        {
                                InteractObj.Interact();
                        }
                }
        }
}