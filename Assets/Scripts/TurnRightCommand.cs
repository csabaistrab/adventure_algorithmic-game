using UnityEngine;

public class TurnRightCommand : ICommand
{
    private CharacterMovement character;

    public TurnRightCommand(CharacterMovement chara)
    {
        character = chara;
    }

    public void Execute()
    {
        character.TurnRight();
    }
}