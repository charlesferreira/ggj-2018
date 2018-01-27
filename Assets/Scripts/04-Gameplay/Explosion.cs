using UnityEngine;

public class Explosion : MonoBehaviour {

	public new CircleCollider2D collider;
	
	public float size;
	public float speed;

	private float radius;

	private void Start() {
		transform.localScale = Vector3.zero;
	}

	private void Update() {
		radius += speed * Time.deltaTime;
		transform.localScale = Vector3.one * radius;
		if (radius > size) {
			Destroy(gameObject);
		}
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere(transform.position, size);
	}
}
