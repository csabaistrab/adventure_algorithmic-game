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
        // A folyamatos mozgás kezelése (interpoláció)
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

        // --- ÜTKÖZÉSVIZSGÁLAT (FAL DETEKTÁLÁS) ---
        // Kilövünk egy sugarat, hogy lássuk, van-e elõttünk fal
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepSize);

        if (hit.collider != null)
        {
            // Ha a sugár eltalált valamit, ami NEM "Trigger" (pl. falat)
            if (!hit.collider.isTrigger)
            {
                Debug.Log("Falnak ütköztünk! Nem lépek.");
                return; // Megállítjuk a funkciót, nem lépünk tovább
            }
        }
        

        
        

        // A célpozíció kiszámolása
        Vector3 direction = transform.up;
        targetPosition += direction * stepSize;
        IsMoving = true;
    }

    public void TurnRight()
    {
        if (IsMoving) return;

        // Ha a forgást is lépésnek akarod számolni, vedd ki a kommentjeleket (//) a kövi 2 sor elõl:
        // stepCount++;
        // if (stepText != null) stepText.text = "Lépések: " + stepCount;

        transform.Rotate(0, 0, -90);
    }

    // Ezt használja az okos algoritmus, hogy lássa, szabad-e az út
    public bool IsPathClear()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepSize);
        // Ha nincs találat, VAGY ha van, de az csak egy Trigger (pl. Cél), akkor szabad az út
        return hit.collider == null || hit.collider.isTrigger;
    }
}