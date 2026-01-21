using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI; // EZT ADTAM HOZZÁ (Kell a szöveghez)

public class AlgorithmRunner : MonoBehaviour
{
    private List<ICommand> commandQueue = new List<ICommand>();
    private CharacterMovement playerCharacter;

    // --- ÚJ RÉSZ: UI Változók ---
    public Text stepText; // Ide húzd majd be a StepText-et a Unity-ben!
    private int currentStepCount = 0;
    // ----------------------------

    public bool IsRunning { get; private set; } = false;

    void Start()
    {
        playerCharacter = FindObjectOfType<CharacterMovement>();
        if (playerCharacter == null)
        {
            Debug.LogError("HIBA: Nincs CharacterMovement a Scene-ben!");
        }

        // Alaphelyzetbe állítjuk a szöveget induláskor
        UpdateStepText(0);
    }

    public void AddCommand(ICommand command)
    {
        commandQueue.Add(command);
    }

    public void ClearCommands()
    {
        commandQueue.Clear();
        // Ha törlöd a parancsokat, nullázzuk a számlálót is a képernyõn?
        // Ha igen, vedd ki a kommentet a kövi sor elõl:
        // UpdateStepText(0); 
    }

    public void StartAlgorithm()
    {
        if (IsRunning || commandQueue.Count == 0) return;

        IsRunning = true;
        StartCoroutine(ExecuteAlgorithmRoutine());
    }

    private IEnumerator ExecuteAlgorithmRoutine()
    {
        Debug.Log("Algoritmus indul! Lépések a sorban: " + commandQueue.Count);

        // Nullázzuk a számlálót minden futtatás elején
        //currentStepCount = 0;
        UpdateStepText(currentStepCount);

        foreach (ICommand command in commandQueue)
        {
            command.Execute();

            // --- ITT SZÁMOLUNK ---
            // Minden végrehajtott parancs után növeljük a számot
            currentStepCount++;
            UpdateStepText(currentStepCount);
            // ---------------------

            // Várunk, amíg a karakter befejezi a mozgást
            yield return new WaitUntil(() => !playerCharacter.IsMoving);
        }

        IsRunning = false;
        Debug.Log("Algoritmus kész.");
    }

    // Segédfüggvény a kiíráshoz
    void UpdateStepText(int count)
    {
        if (stepText != null)
        {
            stepText.text = "Lépések: " + count;
        }
    }
}