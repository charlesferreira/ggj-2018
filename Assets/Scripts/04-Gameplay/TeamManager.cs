using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {

	public List<Player> teamA;
	public List<Player> teamB;
	
	// Use this for initialization
	void Start () {
		if (GameManager.instance.playersSet == null) {
			throw new Exception("Player Set NULL.");
		}

		var playerSetTeamA = GameManager.instance.playersSet.teamA;
		for (int i = 0; i < teamA.Count; i++) {
			if (i < playerSetTeamA.Count) {
				print(" playerSetTeamA[i] = " + playerSetTeamA[i]);
				teamA[i].id = playerSetTeamA[i];
				teamA[i].gameObject.SetActive(true);
			}
			else {
				teamA[i].gameObject.SetActive(false);
			}
		}
		
		var playerSetTeamB = GameManager.instance.playersSet.teamB;
		for (int i = 0; i < teamB.Count; i++) {
			if (i < playerSetTeamB.Count) {
				print(" playerSetTeamB[i] = " + playerSetTeamB[i]);
				teamB[i].id = playerSetTeamB[i];
				teamB[i].gameObject.SetActive(true);
			}
			else {
				teamB[i].gameObject.SetActive(false);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
