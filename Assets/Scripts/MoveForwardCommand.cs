using UnityEngine;

public class MoveForwardCommand : ICommand
{
    private CharacterMovement character;

    public MoveForwardCommand(CharacterMovement chara)
    {
        character = chara;
    }

    public void Execute()
    {
        character.MoveForward();
    }
}