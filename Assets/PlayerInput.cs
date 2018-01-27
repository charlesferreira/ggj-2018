using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public Emitter emitter;
	
	public int playerId;
	
	public float cooldown;
	
	private float timeLeft;

	private bool selfDestructing;
	
	void Update () {
		if (Input.GetKey("joystick " + playerId + " button 0") && !selfDestructing) {
			Send(Message.Command.Fire, false);
			selfDestructing = true;
		}
		
		if (timeLeft > 0) {
			print("time left........");
			timeLeft -= Time.deltaTime;
			return;
		}

		if (Input.GetAxis("joystick " + playerId + " horizontal") > 0) {
			print("right");
			Send(Message.Command.Right);
		}
		else if (Input.GetAxis("joystick " + playerId + " horizontal") < 0) {
			print("left");
			Send(Message.Command.Left);
		}
		else if (Input.GetAxis("joystick " + playerId + " vertical") > 0) {
			print("up");
			Send(Message.Command.Up);
		}
		else if (Input.GetAxis("joystick " + playerId + " vertical") < 0) {
			print("down");
			Send(Message.Command.Down);
		}
	}

	private void Send(Message.Command command, bool resetCooldown = true) {
		emitter.EmitSignal(command, playerId);
		if (resetCooldown) {
			timeLeft = cooldown;
		}
	}
}
