using UnityEngine;

public class Ship : MonoBehaviour {

	public Explosion explosion;

	public void SelfDestruct() {
		Instantiate(explosion, transform.position, Quaternion.identity);
	}
	
}
