using UnityEngine;
using UnityEngine.SceneManagement; // Kell a jelenetváltáshoz

public class MainMenuController : MonoBehaviour
{
    // Ezt hívjuk meg a START gombbal
    public void StartGame()
    {
        // Betöltjük az 1-es indexû pályát (ami az elsõ igazi pálya lesz)
        SceneManager.LoadScene(1);
    }

    // Ezt hívjuk meg a KILÉPÉS gombbal
    public void QuitGame()
    {
        Debug.Log("A játék bezárult!"); // Ez csak a szerkesztõben látszik
        Application.Quit(); // Ez zárja be a kész programot (.exe)
    }
}