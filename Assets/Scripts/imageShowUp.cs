using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageShowUp : MonoBehaviour
{
    public Image image;
    bool Interact = false;

    void Start()
    {
        image.enabled = false;
    }
    //script to show image in game where the player face to the object and press space to show the image using raycast
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 4))
        {
            Debug.Log(hit.collider.tag);
            Debug.Log(hit.collider.name);
            if (hit.collider.tag == "image")
            {
                Interact = true;
                if (Input.GetKeyDown(KeyCode.B))
                {
                    Debug.Log("space key was pressed");
                    image.enabled = true;
                }
            }
        }
        else
        {
            image.enabled = false;
        }
    }
    void OnGUI()
    {
        if(Interact == true)
            GUI.Box(new Rect(0, 0, 0, 25), "Press B to Interact");
    }
    

}
