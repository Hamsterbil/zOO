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
            float x = Input.GetAxis("Foward");
            float z = Input.GetAxis("Up");
            float y = Input.GetAxis("Back");
            transform.position += transform.forward * speed * Time.deltaTime;
            Vector3 movement = new Vector3(x, y, z);
            transform.Translate(movement * speed * Time.deltaTime);
        }
      
        }

    }
}