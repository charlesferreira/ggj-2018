using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

	public List<Sprite> lives;
	public SpriteRenderer sprite;
	public AudioSource sound;

	[Header("Border")] 
	public float borderMinAlpha;
	public float borderMaxAlpha;
	public SpriteRenderer border;
	public float borderSpeed;
	
	void Update () {
		if (border.enabled) {
			UpdateBorder();
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Bomb")) {
			border.enabled = true;
			sound.Play();
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Bomb")) {
			border.enabled = false;
			sound.Stop();
		}
	}

	private void UpdateBorder() {
		var alpha = borderMinAlpha + (borderMaxAlpha - borderMinAlpha) * Mathf.Abs(Mathf.Sin(borderSpeed * Time.time));
		var color = border.color;
		color.a = alpha;
		border.color = color;
	}
}
