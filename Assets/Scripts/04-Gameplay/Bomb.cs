using UnityEngine;

public class Bomb : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Explosion")) {
			Detach();
		}
		
		if (other.CompareTag("Ship")) {
			AttachTo(other);
		}
	}

	private void AttachTo(Component ship) {
		transform.position = ship.transform.position;
		transform.SetParent(ship.transform);
	}

	private void Detach() {
		Destroy(gameObject);
		FindObjectOfType<BombSpawner>().Spawn();
	}
	
}
