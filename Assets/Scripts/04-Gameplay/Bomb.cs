using UnityEngine;

public class Bomb : MonoBehaviour {

	public Explosion explosion;

	private void OnTriggerEnter2D(Collider2D other) {
		var ship = other.GetComponent<Ship>();
		if (ship == null) {
			return;
		}

		AttachTo(ship);
	}

	private void AttachTo(Ship ship) {
		transform.position = ship.transform.position;
		transform.SetParent(ship.transform);
	}

	public void Detonate() {
		Instantiate(explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
