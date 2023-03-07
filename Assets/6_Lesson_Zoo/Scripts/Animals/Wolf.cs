using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_6.Animals
{
    public class Wolf : HostileAnimal
    {
        private Vector3 _startPosition; // The starting position of the object
        private float _angle = 0f; // The current angle of _startPosition

         void Start()
        {
            _startPosition = transform.position;
            _angle = Random.Range(0f, 360f);
        }
        public override void OnMouseDown()
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        protected void Update()
        {
            if (CurrentState == AnimalState.IDLE && !Busy)
            {
             
            }
            Vector3 orbitPosition = new Vector3(
                _startPosition.x + (IdleArea * Mathf.Cos(_angle)),
                _startPosition.y,
                _startPosition.z + (IdleArea * Mathf.Sin(_angle))
            );


        }

    }
}