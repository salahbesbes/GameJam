using UnityEngine;

public class Selectable : MonoBehaviour, IInteractable

{
        public virtual void Interact()
        { Debug.Log($" Interacted with {transform.name}"); }
}

public interface IInteractable
{
        public void Interact();
}