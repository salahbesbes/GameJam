using UnityEngine;

public class FlowMouse : MonoBehaviour
{
        private void Update()
        {
                transform.position = Input.mousePosition;
        }
}