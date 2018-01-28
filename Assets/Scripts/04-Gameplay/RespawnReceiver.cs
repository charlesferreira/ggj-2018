using UnityEngine;

public class RespawnReceiver : MonoBehaviour {

	public Player player;
	public Ship ship;
	public float respawnDelay;
	public AudioSource sosSound;

	private void OnTriggerEnter2D(Collider2D other) {
		var receivedSignal = other.GetComponent<Signal>();
		if (receivedSignal == null) {
			return;
		}
		if (receivedSignal.Message.playerId != player.id) {
			return;
		}

		if (receivedSignal.Message.command == Message.Command.Respawn) {
			sosSound.Stop();
			Invoke("Respawn", respawnDelay);
			receivedSignal.Dissipate();
		}
	}

	void Respawn() {
		ship.Respawn(transform.position);
	}
}
