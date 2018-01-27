using System;
using UnityEngine;

public class SignalReceiver : MonoBehaviour {

    public int playerId;
    
    public Jet topJet;
    public Jet leftJet;
    public Jet rightJet;
    public Jet bottomJet;

    private void OnTriggerEnter2D(Collider2D other) {
        var signal = other.GetComponent<Signal>();
        if (signal == null) {
            return;
        }
        
        if (signal.Message.playerId != playerId) {
            return;
        }
            
        Process(signal);
    }

    void Process(Signal signal) {
        switch (signal.Message.command) {
            case Message.Command.Up:
                bottomJet.TurnOn();
                topJet.TurnOff();
                break;
            case Message.Command.Left:
                rightJet.TurnOn();
                leftJet.TurnOff();
                break;
            case Message.Command.Right:
                leftJet.TurnOn();
                rightJet.TurnOff();
                break;
            case Message.Command.Down:
                topJet.TurnOn();
                bottomJet.TurnOff();
                break;
            case Message.Command.Fire:
                // todo: destruir a nave
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        signal.Dissipate();
    }
}