using UnityEngine;

public class key : MonoBehaviour
{
    public int id;
        private void OnTriggerEnter(Collider other)
        {
                if (other.gameObject.CompareTag("Player"))
                {
                        other.gameObject.GetComponent<Inventory>().AddKey(this.gameObject);
                        Destroy(gameObject);
                }
        }
}