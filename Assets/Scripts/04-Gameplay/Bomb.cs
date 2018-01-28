using UnityEditor.VersionControl;
using UnityEngine;

public class Bomb : MonoBehaviour {

	private Transform target;

	private void OnTriggerEnter2D(Collider2D other) {
		if (!enabled) {
			return;
		}
		
		if (other.CompareTag("Explosion")) {
			Detach();
			return;
		}
		
		if (other.CompareTag("Ship")) {
			AttachTo(other.transform);
		}
	}

	private void Update() {
		if (target != null) {
			transform.position = target.position;
		}
	}

	private void AttachTo(Transform target) {
		this.target = target;
	}

	private void Detach() {
		enabled = false;
		target = null;
		Destroy(gameObject);
		FindObjectOfType<BombSpawner>().Spawn();
	}
	
}
