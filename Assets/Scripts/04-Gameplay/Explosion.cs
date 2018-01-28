using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public new CircleCollider2D collider;
	
	public float size;
	public float speed;
	public AudioSource sound;

	private float radius;
	
	private void Start() {
		if (sound != null) {
			sound.Play();
		}

		transform.localScale = Vector3.zero;
	}

	private void Update() {
		radius += speed * Time.deltaTime;
		transform.localScale = Vector3.one * radius;
		if (radius > size) {
			StartCoroutine(DestroiBomba());

		}
		
	}

	IEnumerator DestroiBomba() {
		GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<CircleCollider2D>().enabled = false;
		yield return new WaitForSeconds(1);
		Destroy(gameObject);
	}
	private void OnDrawGizmos() {
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere(transform.position, size);
	}
}
