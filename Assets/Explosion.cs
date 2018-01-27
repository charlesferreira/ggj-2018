using UnityEngine;

public class Explosion : MonoBehaviour {

	public new CircleCollider2D collider;
	public float size;
	public float speed;

	private void Start() {
		collider.radius = 0;
	}

	private void Update() {
		collider.radius += speed * Time.deltaTime;
		if (collider.radius > size) {
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		// começar reação em cadeia...
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere(transform.position, size);
	}
}
