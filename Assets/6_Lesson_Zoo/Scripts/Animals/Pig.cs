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
               transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }


            //IF input wasd
    

        }

    }
}