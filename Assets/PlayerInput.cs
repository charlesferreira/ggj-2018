using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public int emitter;

	public int playerID;
	
	public float cooldown;
	
	private float timeLeft;
	
	void Update () {
		if (timeLeft > 0) {
			timeLeft -= Time.deltaTime;
			return;
		}

		if (Input.GetAxis("joystick " + playerID + " horizontal") > 0) {
			//Send(Message.Command.Right);
		}
		else if (Input.GetAxis("joystick " + playerID + " horizontal") < 0) {
			//Send(Message.Command.Left);
		}
		else if (Input.GetAxis("joystick " + playerID + " vertical") > 0) {
			//Send(Message.Command.Up);
		}
		else if (Input.GetAxis("joystick " + playerID + " vertical") < 0) {
			//Send(Message.Command.Down);
		}
		else if (Input.GetKey("joystick " + playerID + " button 0")) {
			//Send(Message.Command.Fire);
		}
	}

	private void Send(int command) {
		// emitter.send(new Message(command), playerID)
		timeLeft = cooldown;
	}
}
