using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		
		// Activate the menu from the title screen, and revert to the title screen
		if (Input.anyKeyDown)
		{
			Debug.Log("Press Button: " + Input.compositionString );
			this.goToLobby();
		}                    
		
	}

	public void goToLobby()
	{
		SceneManager.LoadScene("03-Lobby");
	}
}
