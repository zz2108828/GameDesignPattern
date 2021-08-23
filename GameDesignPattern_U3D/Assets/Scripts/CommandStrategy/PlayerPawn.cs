using System;
using UnityEngine;

public class PlayerPawn : MonoBehaviour, IPawn
{
    private void Start()
    {
    }

    public void MoveTo(Vector3 pos)
    {
        transform.Translate(pos);
    }
}