using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Message {

    public enum Command { Up, Left, Right, Down, Fire, Respawn }

    public Command command;
    public int playerId;
}
