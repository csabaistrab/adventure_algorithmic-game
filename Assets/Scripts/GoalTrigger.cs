using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalTrigger : MonoBehaviour
{
    // Ez a függvény automatikusan lefut, ha "valami" (aminek van Rigidbody-ja) belép a Triggerbe
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Megnézzük, hogy a játékos lépett-e bele
        if (other.CompareTag("Player"))
        {
            Debug.Log(" GRATULÁLOK! PÁLYA TELJESÍTVE! ");

            // --- PÁLYAVÁLTÓ KÓD ELEJE ---
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;

            // Megnézzük, van-e következõ pálya a listában
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                // Ha van, betöltjük (pl. Level 2)
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                // Ha nincs több, visszamegyünk a Fõmenübe (0)
                SceneManager.LoadScene(0);
            }
            // --- PÁLYAVÁLTÓ KÓD VÉGE ---
            // Itt késõbb leállítjuk a játékot, vagy betöltjük a kövi pályát
            // Pl: FindObjectOfType<GameManager>().LevelComplete();
        }
    }
}