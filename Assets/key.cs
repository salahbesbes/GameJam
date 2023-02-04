using UnityEngine;

public class key : Selectable
{
    public int id;
        private void OnTriggerEnter(Collider other)
        {
                if (other.gameObject.CompareTag("Player"))
                {
                        other.gameObject.GetComponent<LaserInteraction>().inventory.Add("Key", this);
                        gameObject.SetActive(false);
                }
        }
}