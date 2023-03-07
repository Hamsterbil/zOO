using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_6.Animals
{
    public class Pig : FriendlyAnimal
    {
    protected void Update()
    {
        if (CurrentState == AnimalState.IDLE && !Busy)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            transform.position += transform.forward * speed * Time.deltaTime;
            Vector3 movement = new Vector3(x, 0, z);
            transform.Translate(movement * speed * Time.deltaTime);
        }
      
        }

    }
}