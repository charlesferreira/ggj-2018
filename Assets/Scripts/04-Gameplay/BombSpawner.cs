using UnityEngine;

public class BombSpawner : MonoBehaviour {

	public Bomb bombPrefab;
	public float spawnDelay;

	private void Start() {
		Spawn();
	}

	public void Spawn() {
		Invoke("Deploy", spawnDelay);
	}

	private void Deploy() {
		Instantiate(bombPrefab, transform.position, Quaternion.identity);
	}
	
}
