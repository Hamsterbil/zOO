using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_6.Animals
{
    public class Pig : FriendlyAnimal
    {
        public Transform target;
        protected void Update()
        {
            if (CurrentState == AnimalState.IDLE && !Busy)
            {
                transform.position = Vector3.MoveTowards(transform.position, 
                target.position, speed * Time.deltaTime);           
            }


            
    

        }

    }
}