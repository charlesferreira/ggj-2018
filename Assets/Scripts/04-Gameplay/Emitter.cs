using UnityEngine;

public class Emitter : MonoBehaviour {

    public Player player;
    public Signal signal;

    public void EmitSignal(Message.Command command) {
        var newSignal = Instantiate(signal, transform.position, Quaternion.identity);
        var message = new Message {
            command = command,
            playerId = player.id
        };
        newSignal.Init(message);
    }
}
