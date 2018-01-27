using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayersSet playersSet;
    
    void InformPlayers(PlayersSet playersSet)
    {
        this.playersSet = playersSet;
    }
}
