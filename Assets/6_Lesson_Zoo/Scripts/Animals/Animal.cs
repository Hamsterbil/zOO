using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_6.Animals
{
    public abstract class Animal : MonoBehaviour
    {
        public float speed = 1.0f;
        public float IdleArea = 25.0f;
        public bool Busy = false;
        protected Vector3 IdleCenter;
        protected AnimalState CurrentState = AnimalState.IDLE;
    }
}
