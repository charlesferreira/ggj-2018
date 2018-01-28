using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public Player player;
	public Emitter emitter;
	public AudioSource signalSound;
	
	public float cooldown;
	
	private float timeLeft;

	private bool isSelfDestructing;

	private float sensitivity = 0.5f;
	
	void Update () {
		if (Input.GetKey("joystick " + player.id + " button 0") && !isSelfDestructing) {
			signalSound.Play();
			Send(Message.Command.Fire, false);
			isSelfDestructing = true;
		}
		
		if (timeLeft > 0) {
			timeLeft -= Time.deltaTime;
			return;
		}

		if (Input.GetAxis("joystick " + player.id + " horizontal") > sensitivity) {
			Send(Message.Command.Right);
		}
		else if (Input.GetAxis("joystick " + player.id + " horizontal") < -sensitivity) {
			Send(Message.Command.Left);
		}
		
		if (Input.GetAxis("joystick " + player.id + " vertical") > sensitivity) {
			Send(Message.Command.Up);
		}
		else if (Input.GetAxis("joystick " + player.id + " vertical") < -sensitivity) {
			Send(Message.Command.Down);
		}
	}

	private void Send(Message.Command command, bool resetCooldown = true) {
		emitter.EmitSignal(command);
		if (resetCooldown) {
			timeLeft = cooldown;
		}
	}

	public void Restart() {
		isSelfDestructing = false;
	}
}
