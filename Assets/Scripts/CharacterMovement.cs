using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float stepSize = 1f;
    public float moveDuration = 0.5f;
    private Vector3 targetPosition;
    public bool IsMoving { get; private set; } = false;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (IsMoving)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                stepSize / moveDuration * Time.deltaTime
            );

            if (transform.position == targetPosition)
            {
                IsMoving = false;
            }
        }
    }

    public void MoveForward()
    {
        if (IsMoving) return;
        Vector3 direction = transform.up;
        targetPosition += direction * stepSize;
        IsMoving = true;
    }

    public void TurnRight()
    {
        if (IsMoving) return;
        transform.Rotate(0, 0, -90);
    }
}