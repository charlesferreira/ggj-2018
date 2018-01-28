using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayersController : MonoBehaviour {

    public GameManager gameManager;
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
                InformPlayers();
                SceneManager.LoadScene(2);
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

    void InformPlayers()
    {
        var teamA = new List<int>();
        var teamB = new List<int>();

        for (int i = 0; i < 8; i += 2)
        {
            if (slots[i].isJoined)
            {
                teamA.Add(slots[i].joystickIndex);
            }
        }
        for (int i = 1; i < 8; i += 2)
        {
            if (slots[i].isJoined)
            {
                teamB.Add(slots[i].joystickIndex);
            }
        }

        var playersSet = new PlayersSet();
        playersSet.teamA = teamA;
        playersSet.teamB = teamB;

        gameManager.playersSet = playersSet;
    }
}
