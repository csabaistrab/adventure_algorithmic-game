using UnityEngine;

public class TestInput : MonoBehaviour
{
    private AlgorithmRunner runner;
    private CharacterMovement character;

    void Start()
    {
        // Megkeressük a többi scriptet a játékban
        runner = FindObjectOfType<AlgorithmRunner>();
        character = FindObjectOfType<CharacterMovement>();
    }

    void Update()
    {
        // 1-es gomb: Sima manuális módszer
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!runner.IsRunning)
            {
                Debug.Log("Teszt 1: Manuális");
                runner.ClearCommands();
                runner.AddCommand(new MoveForwardCommand(character));
                runner.AddCommand(new TurnRightCommand(character));
                runner.StartAlgorithm();
            }
        }

        // 2-es gomb: CIKLUS (Loop) - Ez a lényeg!
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!runner.IsRunning)
            {
                Debug.Log("Teszt 2: Ciklus");
                runner.ClearCommands();

                // Ez a "Loop" blokk logikája: 4-szer ismétlünk
                for (int i = 0; i < 4; i++)
                {
                    runner.AddCommand(new MoveForwardCommand(character));
                    runner.AddCommand(new TurnRightCommand(character));
                }

                runner.StartAlgorithm();
            }
        }
    }
}