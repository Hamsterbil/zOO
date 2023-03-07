using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_6.Animals
{
    public class Pig : FriendlyAnimal
    {
        protected void Update()
        {
            float h = Input.GetAxisRaw(18);
            float v = Input.GetAxisRaw(12);
   
            gameObject.transform.position = new Vector2 (transform.position.x + (h * speed), 
            transform.position.y + (v * speed));
        }

    }
}