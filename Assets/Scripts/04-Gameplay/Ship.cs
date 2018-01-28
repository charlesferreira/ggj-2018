using UnityEngine;

public class Ship : MonoBehaviour {

	public Rigidbody2D rb;
	public SignalReceiver receiver;
	public Explosive explosive;
	public AudioSource spawnSound;

	public void Respawn(Vector3 position) {
		transform.position = position;
		explosive.Restart();
		restartReceiver();
		rb.velocity = Vector2.zero;
	}

	public void restartReceiver() {
		// TODO: Fazer Animação e Delay.
		spawnSound.Play();
		receiver.Restart();
	}
}
