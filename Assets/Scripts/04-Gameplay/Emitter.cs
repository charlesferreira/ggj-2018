using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

    public Signal signal;
	
	void Start () {
        
	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            EmitSignal(Message.Command.Up);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            EmitSignal(Message.Command.Left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            EmitSignal(Message.Command.Right);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            EmitSignal(Message.Command.Down);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EmitSignal(Message.Command.Fire);
        }
    }

    private void EmitSignal(Message.Command command)
    {
        var newSignal = Instantiate(signal, transform.position, Quaternion.identity);
        var message = new Message();
        message.command = command;
        message.playerIndex = 0;
        newSignal.Init(message);
    }
}
