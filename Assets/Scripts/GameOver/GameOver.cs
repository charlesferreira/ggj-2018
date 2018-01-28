using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    SpriteRenderer victoryImage;
    public Sprite teamAImage;
    public Sprite teamBImage;

    public float deadTime;
    private float currentDeadTime;

	void Start () {

        currentDeadTime = deadTime;

        victoryImage = GetComponent<SpriteRenderer>();
        victoryImage.sprite = true ? teamAImage : teamBImage;
	}
	
	void Update () {

        currentDeadTime -= Time.deltaTime;

        if (currentDeadTime > 0)
        {
            return;
        }

        if (Input.anyKey)
        {
            SceneManager.LoadScene(1);
        }

        currentDeadTime = 0;
    }
}
