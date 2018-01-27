using UnityEngine;

public class BombSpawner : MonoBehaviour {

	public Bomb bombPrefab;

	private void Start() {
		Instantiate(bombPrefab, transform.position, Quaternion.identity);
	}
	
}
