using UnityEngine;

public class Jet : MonoBehaviour {

	public Rigidbody2D rb;
	public ParticleSystem particles;
	public float power;
	public float duration;

	private float timeLeft;

	private bool IsOn {
		get { return timeLeft > 0; }
		set {
			timeLeft = value ? duration : 0;
			if (value) {
				particles.Play();
			}
			else {
				particles.Stop();
			}
		}
	}

	void FixedUpdate () {
		if (!IsOn) return;

		rb.AddForce(transform.right * power * Time.fixedDeltaTime, ForceMode2D.Impulse);
		timeLeft -= Time.fixedDeltaTime;

		if (timeLeft <= 0) {
			TurnOff();
		}
	}

	public void TurnOn() {
		IsOn = true;
	}

	public void TurnOff() {
		IsOn = false;
	}
}
