using UnityEngine;

public class Emitter : MonoBehaviour {

    public Signal signal;

    public void EmitSignal(Message.Command command, int playerId) {
        var newSignal = Instantiate(signal, transform.position, Quaternion.identity);
        var message = new Message {
            command = command,
            playerId = playerId
        };
        newSignal.Init(message);
    }
}
