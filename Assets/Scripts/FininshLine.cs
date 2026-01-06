using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // FIGYELEM: Itt a "2D" a kulcsszó a végén!
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Megnézzük, hogy a játékos ment-e neki
        if (other.CompareTag("Player"))
        {
            Debug.Log("2D Ütközés észlelve! Pálya váltása...");
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}