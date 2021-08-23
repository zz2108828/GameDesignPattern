using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSender : MonoBehaviour
{
    private float currTime;
    public bool isRun = true;
    public PlayerPawn pawn;
    private Stack<ACommond> cmdStack = new Stack<ACommond>();

    // Start is called before the first frame update
    void Start()
    {
        currTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRun)
        {
            Control();
        }
        else
        {
            RollBack();
        }
    }

    ACommond HandleInput()
    {
        var moveOffset = Vector3.zero;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveOffset.y += Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveOffset.y -= Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                moveOffset.x -= Time.deltaTime;
            }        
            else if (Input.GetKey(KeyCode.D))
            {
                moveOffset.x += Time.deltaTime;
            }
            return new MoveCommand(pawn, currTime, moveOffset);
        }

        return null;
    }

    private void Control()
    {
        currTime += Time.deltaTime;
        var cmd = HandleInput();
        if (cmd != null)
        {
            cmdStack.Push(cmd);
            cmd.Execute();
        }
    }

    private void RollBack()
    {
        if (cmdStack.Count > 0)
        {
            currTime -= Time.deltaTime;
            if (cmdStack.Peek().CurTime >= currTime)
            {
                cmdStack.Pop().Undo();
            }
        }
        else
        {
            currTime = 0;
        }
    }
}
