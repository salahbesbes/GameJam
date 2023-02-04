using UnityEngine;

public class flashLight : MonoBehaviour
{
        public GameObject flasLight;

        // Start is called before the first frame update

        // Update is called once per frame
        private void Update()
        {
                if (Input.GetKeyDown(KeyCode.E))
                {
                        flasLight.active = !flasLight.active;
                }
        }
}