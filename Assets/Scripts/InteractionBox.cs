using UnityEngine;

public class InteractionBox : MonoBehaviour
{
        //public IInteractable target;

        private void OnTriggerExit(Collider other)
        {
                if (other.CompareTag("Player"))
                {
                        other.transform.GetComponent<LaserInteraction>().SetStartTracing(false);
                }
        }

        private void OnTriggerEnter(Collider other)
        {
                if (other.CompareTag("Player"))
                {
                        other.transform.GetComponent<LaserInteraction>().SetStartTracing(true);
                }
        }
}