using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class AlgorithmRunner : MonoBehaviour
{
    private List<ICommand> commandQueue = new List<ICommand>();
    private CharacterMovement playerCharacter;

    public bool IsRunning { get; private set; } = false;

    void Start()
    {
        playerCharacter = FindObjectOfType<CharacterMovement>();
        if (playerCharacter == null)
        {
            Debug.LogError("HIBA: Nincs CharacterMovement a Scene-ben!");
        }
    }

    public void AddCommand(ICommand command)
    {
        commandQueue.Add(command);
    }

    public void ClearCommands()
    {
        commandQueue.Clear();
    }

    public void StartAlgorithm()
    {
        if (IsRunning || commandQueue.Count == 0) return;

        IsRunning = true;
        StartCoroutine(ExecuteAlgorithmRoutine());
    }

    private IEnumerator ExecuteAlgorithmRoutine()
    {
        Debug.Log("Algoritmus indul! Lépések: " + commandQueue.Count);

        foreach (ICommand command in commandQueue)
        {
            command.Execute();
            // Várunk, amíg a karakter befejezi a mozgást
            yield return new WaitUntil(() => !playerCharacter.IsMoving);
        }

        IsRunning = false;
        Debug.Log("Algoritmus kész.");
    }
}