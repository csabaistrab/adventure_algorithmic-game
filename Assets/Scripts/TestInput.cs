using UnityEngine;

public class TestInput : MonoBehaviour
{
    private AlgorithmRunner runner;
    private CharacterMovement character;

    void Start()
    {
        runner = FindObjectOfType<AlgorithmRunner>();
        character = FindObjectOfType<CharacterMovement>();
    }

    void Update()
    {
        // 1-es: Manuális
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!runner.IsRunning)
            {
                runner.ClearCommands();
                runner.AddCommand(new MoveForwardCommand(character));
                runner.AddCommand(new TurnRightCommand(character));
                runner.StartAlgorithm();
            }
        }

        // 2-es: Ciklus (Loop)
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!runner.IsRunning)
            {
                runner.ClearCommands();
                for (int i = 0; i < 4; i++)
                {
                    runner.AddCommand(new MoveForwardCommand(character));
                    runner.AddCommand(new TurnRightCommand(character));
                }
                runner.StartAlgorithm();
            }
        }

        // 3-as: IF / ELSE (Okos döntés) - EZ AZ ÚJ!
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!runner.IsRunning)
            {
                Debug.Log("Teszt 3: Okos IF döntés");
                runner.ClearCommands();

                // Itt rakjuk össze a logikát:
                // HA (Szabad az út) -> Akkor: Lépj Elõre (MoveForward)
                // KÜLÖNBEN (Fal van) -> Akkor: Fordulj Jobbra (TurnRight)

                ICommand haIgaz = new MoveForwardCommand(character);
                ICommand haHamis = new TurnRightCommand(character);

                runner.AddCommand(new IfClearCommand(character, haIgaz, haHamis));

                runner.StartAlgorithm();
            }
        }
    }
}