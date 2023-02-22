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
                Busy = true;
                Vector3 nextGraze = Pen.transform.position;
                Vector2 rand = Random.insideUnitCircle * 25f;
                nextGraze.x += rand.x;
                nextGraze.y = 2f;
                nextGraze.z += rand.y;
                StartCoroutine(LerpMovement(nextGraze));
            }
        }

        private IEnumerator LerpMovement(Vector3 to)
        {
            float lerpTimer = 0;
            float lerpDuration = 2.5f;

            while (lerpTimer < lerpDuration)
            {
                transform.position = Vector3.Lerp(transform.position, to, lerpTimer / lerpDuration);
                lerpTimer += Time.deltaTime;

                Vector3 targetDir = to - transform.position;
                if (targetDir != Vector3.zero) transform.rotation = Quaternion.LookRotation(targetDir);

                yield return null;
            }
            Busy = false;
        }

    }
}