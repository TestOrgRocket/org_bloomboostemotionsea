using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVerticalMovement : MonoBehaviour
{
    public Transform objectToMove;
    public float moveDistance = 1f;
    public float moveSpeed = 3.0f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool movingForward = true;

    private void OnEnable()
    {
        objectToMove = transform;

        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        yield return new WaitForSeconds(1f);
        startPosition = objectToMove.position;
        targetPosition = startPosition + new Vector3(0f, moveDistance, 0f);
        yield return new WaitForSeconds(Random.Range(1f, 5f));
        while (true)
        {
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime * moveSpeed;

                if (movingForward)
                    objectToMove.position = Vector3.Lerp(startPosition, targetPosition, t);
                else
                    objectToMove.position = Vector3.Lerp(targetPosition, startPosition, t);

                yield return null;
            }

            yield return new WaitForSeconds(0.5f);

            movingForward = !movingForward;
        }
    }

}
