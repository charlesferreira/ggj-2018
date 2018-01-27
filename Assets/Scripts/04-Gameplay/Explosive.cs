using UnityEngine;

public class Explosive : MonoBehaviour {

	public Explosion explosion;

	private bool isDetonating;

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Explosion")) {
			Detonate();
		}
	}

	public void Detonate() {
		if (isDetonating) {
			return;
		}

		isDetonating = true;
		Instantiate(explosion, transform.position, Quaternion.identity);
	}

	public void Restart() {
		isDetonating = false;
	}
}
