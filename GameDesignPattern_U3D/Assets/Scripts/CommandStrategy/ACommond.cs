using UnityEngine;

public abstract class ACommond
{
    protected IPawn Pawn;
    public float CurTime;
    public abstract void Execute();
    public abstract void Undo();
}
