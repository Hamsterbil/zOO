using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_6.Animals
{
    public class Wolf : HostileAnimal
    {
        private Vector3 _startPosition; // The starting position of the object
        private float _angle = 0f; // The current angle of _startPosition

        protected void Update()
        {
            if (CurrentState == AnimalState.IDLE && !busy)
            {
                Busy = true;
                Vector3 nextGraze = Pen.transform.position;
                Vector2 rand = Random.insideUnitCircle * 25f;
                nextGraze.x += rand.x;
                nextGraze.y = 2f;
                nextGraze.z += rand.y;
                StartCoroutine(LerpMovement(nextGraze)); // This is the same as the Pig.cs script
            }
            Vector3 orbitPosition = new Vector3(
                _startPosition.x + (IdleArea * Mathf.Cos(_angle)),
                _startPosition.y,
                _startPosition.z + (IdleArea * Mathf.Sin(_angle))
            );

            transform.position = orbitPosition;

            _angle += speed * Time.deltaTime;
        }

    }
}