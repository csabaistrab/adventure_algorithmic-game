using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("--- ÜTKÖZÉS ÉSZLELVE! ---");
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        // Lekérjük az adatokat
        int jelenlegi = SceneManager.GetActiveScene().buildIndex;
        int kovetkezo = jelenlegi + 1;
        int osszes = SceneManager.sceneCountInBuildSettings;

        // KIÍRJUK A KONZOLRA (Ezt figyeld!)
        Debug.Log("Jelenlegi pálya indexe: " + jelenlegi);
        Debug.Log("Következõ pálya indexe lenne: " + kovetkezo);
        Debug.Log("Összes pálya a Build Settingsben: " + osszes);

        // A döntés
        if (kovetkezo < osszes)
        {
            Debug.Log("DÖNTÉS: Van következõ pálya, betöltés...");
            SceneManager.LoadScene(kovetkezo);
        }
        else
        {
            Debug.Log("DÖNTÉS: Nincs több pálya, irány a Menü (0)!");
            SceneManager.LoadScene(0);
        }
    }
}