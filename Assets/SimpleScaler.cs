using UnityEngine;

public class SimpleScaler : MonoBehaviour {

	public float startRatio = 1;
	public float finalRatio = 1;
	public float duration;

	private Vector3 originalScale;
	private float elapsedTime;

	private void Start() {
		originalScale = transform.localScale;
		transform.localScale = originalScale * startRatio;
	}

	void Update () {
		if (elapsedTime > duration) {
			enabled = false;
			return;
		}
		
		elapsedTime += Time.deltaTime;
		var deltaRatio = (finalRatio - startRatio) * elapsedTime / duration;
		transform.localScale = originalScale * (startRatio + deltaRatio);
	}

	public void Restart() {
		elapsedTime = 0;
		enabled = true;
	}
}
