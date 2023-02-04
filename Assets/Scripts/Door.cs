using System.Collections;
using UnityEngine;

public class Door : Selectable
{
        public int id;
        private bool rotating = false;
        private int direction = 1;

        public float rotationAngle = 90;
        public float rotationSpeed = 2;

        public override void Interact()
        {
                base.Interact();
              
                if (rotating == false)
                {
                    StartCoroutine(Rotate90(transform.parent));
                    direction *= -1;
                        
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
    
}