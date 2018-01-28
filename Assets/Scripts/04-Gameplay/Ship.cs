using System.Collections;
using UnityEngine;

public class Ship : MonoBehaviour {

	public Rigidbody2D rb;
	public SimpleScaler scaler;
	public SignalReceiver receiver;
	public PlayerInput input;
	public Explosive explosive;
	public AudioSource spawnSound;

	private void Start() {
		Invoke("RestartReceiver", scaler.duration);
	}

	public void Respawn(Vector3 position) {
		gameObject.SetActive(true);
		transform.position = position;
		rb.velocity = Vector2.zero;
		scaler.Restart();
		spawnSound.Play();
		Invoke("RestartReceiver", scaler.duration);
	}

	void RestartReceiver() {
		explosive.Restart();
		receiver.Restart();
		input.Restart();
	}
}
