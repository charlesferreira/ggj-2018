using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour {

    public List<PlayerSlot> slots;
    public Dictionary<int, int> slotByJoystick = new Dictionary<int, int>();

    public float countdownTime;
    private float currentCountdown;
    private bool inCountdown = false;

	void Start () {
        for (int i = 0; i < 8; i++)
        {
            slotByJoystick[i + 1] = i;
        }

    }
	
	void Update () {

        if (inCountdown)
        {
            currentCountdown -= Time.deltaTime;
            if (currentCountdown <= 0)
            {
                print("Start");
            }
        } else
        {
            CheckPlayersReady();
        }

        for (int joystick = 1; joystick <= 8; joystick++)
        {
            if (Input.GetKeyDown("joystick " + joystick + " button " + 0))
            {
                if (slots[slotByJoystick[joystick]].joystickIndex == joystick)
                {
                    if (!slots[slotByJoystick[joystick]].isJoined)
                    {
                        Join(joystick);
                        StopCountdown();
                    }
                }
                else
                {
                    Join(joystick);
                    StopCountdown();
                }
            }
            if (Input.GetKey("joystick " + joystick + " button " + 0))
            {
                slots[slotByJoystick[joystick]].Highlight();
            }
            if (Input.GetKeyUp("joystick " + joystick + " button " + 0))
            {
                slots[slotByJoystick[joystick]].Unhighlight();
                StopCountdown();
            }
            if (Input.GetKeyDown("joystick " + joystick + " button " + 1))
            {
                slots[slotByJoystick[joystick]].Leave();
                StopCountdown();
            }
        }
    }

    private void Join(int joystick)
    {
        int first = slots.FindIndex(x => !x.isJoined);
        slotByJoystick[joystick] = first;
        slots[slotByJoystick[joystick]].Join(joystick);
    }

    void CheckPlayersReady()
    {
        if (slots.FindAll(x => x.isHighlighted).Count < 2)
        {
            return;
        }
        if (slots.FindAll(x => x.isHighlighted).Count == slots.FindAll(x => x.isJoined).Count)
        {
            StartCountdown();
        }
    }

    void StartCountdown()
    {
        inCountdown = true;
        currentCountdown = countdownTime;
    }

    void StopCountdown()
    {
        inCountdown = false;
    }
}
