using UnityEngine;

public class MoveCommand : ACommond
{
    private readonly Vector3 targetPos;

    public MoveCommand(IPawn pawn, float curTime, Vector3 targetPos)
    {
        Pawn = pawn;
        CurTime = curTime;
        this.targetPos = targetPos;
    }

    public override void Execute()
    {
        Debug.Log("Command:Move to" + targetPos.y);
        Pawn.MoveTo(targetPos);
    }

    public override void Undo()
    {
        Pawn.MoveTo(-targetPos);
    }
}