using UnityEngine;

public class IfClearCommand : ICommand
{
    private CharacterMovement character;
    private ICommand trueCommand;  // Ezt csinálja, ha SZABAD az út
    private ICommand falseCommand; // Ezt csinálja, ha FAL van

    // A konstruktorban megadjuk neki: "Ki vagyok?", "Mit tegyek ha IGEN?", "Mit tegyek ha NEM?"
    public IfClearCommand(CharacterMovement chara, ICommand ifTrue, ICommand ifFalse)
    {
        character = chara;
        trueCommand = ifTrue;
        falseCommand = ifFalse;
    }

    public void Execute()
    {
        // Megkérdezzük a karaktert: Szabad az út elõtted?
        if (character.IsPathClear())
        {
            Debug.Log("Döntés: Szabad az út -> IGAZ ág fut.");
            trueCommand.Execute();
        }
        else
        {
            Debug.Log("Döntés: Fal van -> HAMIS ág fut.");
            falseCommand.Execute();
        }
    }
}