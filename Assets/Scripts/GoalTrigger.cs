using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    // Ez a függvény automatikusan lefut, ha "valami" (aminek van Rigidbody-ja) belép a Triggerbe
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Megnézzük, hogy a játékos lépett-e bele
        if (other.CompareTag("Player"))
        {
            Debug.Log(" GRATULÁLOK! PÁLYA TELJESÍTVE! ");

            // Itt késõbb leállítjuk a játékot, vagy betöltjük a kövi pályát
            // Pl: FindObjectOfType<GameManager>().LevelComplete();
        }
    }
}