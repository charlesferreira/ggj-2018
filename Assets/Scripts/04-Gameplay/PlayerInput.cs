using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public Player player;
	public Emitter emitter;
	
	public float cooldown;
	
	private float timeLeft;

	private bool isSelfDestructing;
	
	void Update () {
		if (Input.GetKey("joystick " + player.id + " button 0") && !isSelfDestructing) {
			Send(Message.Command.Fire, false);
			isSelfDestructing = true;
		}
		
		if (timeLeft > 0) {
			timeLeft -= Time.deltaTime;
			return;
		}

		if (Input.GetAxis("joystick " + player.id + " horizontal") > 0) {
			Send(Message.Command.Right);
		}
		else if (Input.GetAxis("joystick " + player.id + " horizontal") < 0) {
			Send(Message.Command.Left);
		}
		else if (Input.GetAxis("joystick " + player.id + " vertical") > 0) {
			Send(Message.Command.Up);
		}
		else if (Input.GetAxis("joystick " + player.id + " vertical") < 0) {
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
