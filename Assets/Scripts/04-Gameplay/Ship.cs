using UnityEngine;

public class Ship : MonoBehaviour {

	public Rigidbody2D rb;
	public SignalReceiver receiver;
	public Explosive explosive;

	public void Respawn(Vector3 position) {
		transform.position = position;
		receiver.Restart();
		explosive.Restart();
		rb.velocity = Vector2.zero;
	}
}
