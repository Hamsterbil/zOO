using System.Collections;
using System.Collections.Generic;
using Lesson_6.Animals;
using UnityEngine;

namespace Lesson_6
{
    public class Player : MonoBehaviour
    {
        public FriendlyAnimal SelectedAnimal = null;

        //Check if the mouse is over an animal and if so, select it and move it
        protected void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        if (hit.transform.GetComponent<FriendlyAnimal>() != null)
                        {
                            SelectedAnimal = hit.transform.GetComponent<FriendlyAnimal>();
                        }
                    }
                }
            }
            else
            {
                SelectedAnimal = null;
            }

            if (SelectedAnimal != null)
            {
                Vector3 input = Input.mousePosition;
                input.z = Camera.main.transform.position.y;
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(input);
                Vector3 dragLocation = new Vector3(worldPoint.x, SelectedAnimal.transform.position.y, worldPoint.z);
                SelectedAnimal.transform.position = dragLocation;
            }
        }
    }
}