using System;
using UnityEngine;

public class SignalReceiver : MonoBehaviour {

    public Player player;
    public Explosive explosive;
    public Emitter emitter;
    public AudioSource sosSound;
    
    [Header("Thrusters")]
    public Jet topJet;
    public Jet leftJet;
    public Jet rightJet;
    public Jet bottomJet;

    private void Start() {
        enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Explosion") && enabled) {
            DestroyShip();
            return;
        }
        
        var signal = other.GetComponent<Signal>();
        if (signal == null) {
            return;
        }
        if (signal.Message.playerId != player.id) {
            return;
        }
        
        Process(signal);
    }

    void Process(Signal signal) {
        if (!enabled) {
            return;
        }
        
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
                DestroyShip();
                break;
            case Message.Command.Respawn:
                return;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        signal.Dissipate();
    }

    private void DestroyShip() {
        enabled = false;
        
        topJet.TurnOff();
        leftJet.TurnOff();
        rightJet.TurnOff();
        bottomJet.TurnOff();
        
        explosive.Detonate();
        emitter.EmitSignal(Message.Command.Respawn);
        sosSound.Play();
    }

    public void Restart() {
        enabled = true;
    }
}