using UnityEngine;

public class RespawnReceiver : MonoBehaviour {

	public Player player;
	public PlayerInput input;
	public Ship ship;
	public float respawnDelay;

	private void OnTriggerEnter2D(Collider2D other) {
		var receivedSignal = other.GetComponent<Signal>();
		if (receivedSignal == null) {
			return;
		}
		if (receivedSignal.Message.playerId != player.id) {
			return;
		}

		if (receivedSignal.Message.command == Message.Command.Respawn) {
			Invoke("Respawn", respawnDelay);
			receivedSignal.Dissipate();
		}
	}

	void Respawn() {
		ship.Respawn(transform.position);
		input.Restart();
	}
}
