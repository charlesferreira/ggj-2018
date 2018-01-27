using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Signal { }

public class SignalReceiver : MonoBehaviour {
    
    public Jet topJet;
    public Jet leftJet;
    public Jet rightJet;
    public Jet bottomJet;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            topJet.TurnOn();
            bottomJet.TurnOff();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            bottomJet.TurnOn();
            topJet.TurnOff();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            rightJet.TurnOn();
            leftJet.TurnOff();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            leftJet.TurnOn();
            rightJet.TurnOff();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var signal = other.GetComponent<Signal>();
        if (signal != null) {
            // todo: verificar se o sinal é pra mim e processar
        }
    }
}