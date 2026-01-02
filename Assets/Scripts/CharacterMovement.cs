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

        // --- ÚJ RÉSZ: ÜTKÖZÉSVIZSGÁLAT ---
        // Kilövünk egy sugarat a karakter közepétõl (transform.position)
        // a karakter nézési irányába (transform.up).
        // A sugár hossza: stepSize (1 egység).
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepSize);

        // Ha a sugár eltalált valamit (és az nem saját maga)
        if (hit.collider != null)
        {
            Debug.Log("Falnak ütköztünk! Nem lépek.");
            return; // Megállítjuk a funkciót, nem lépünk tovább
        }
        // ----------------------------------

        Vector3 direction = transform.up;
        targetPosition += direction * stepSize;
        IsMoving = true;
    }

    public void TurnRight()
    {
        if (IsMoving) return;
        transform.Rotate(0, 0, -90);
    }

    // Ezt a függvényt hívhatja majd az "IF" parancs, hogy eldöntse, szabad-e az út
    public bool IsPathClear()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepSize);
        // Ha NINCS találat (null), akkor szabad az út (true)
        return hit.collider == null;
    }
}