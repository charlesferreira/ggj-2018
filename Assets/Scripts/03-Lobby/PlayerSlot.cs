using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSlot : MonoBehaviour {

    SpriteRenderer image;

    public Sprite joinedImage;
    public Sprite disjoinedImage;
    public Sprite highlightImage;

    [HideInInspector]
    public int joystickIndex;
    [HideInInspector]
    public bool isJoined = false;
    [HideInInspector]
    public bool isHighlighted = false;
	
	void Start () {
        image = GetComponent<SpriteRenderer>();
	}

    public void Join(int joystickIndex)
    {
        isJoined = true;
        this.joystickIndex = joystickIndex;
        image.sprite = joinedImage;
    }

    public void Highlight()
    {
        isHighlighted = true;
        image.sprite = highlightImage;
    }

    public void Unhighlight()
    {
        isHighlighted = false;
        image.sprite = joinedImage;
    }

    public void Leave()
    {
        isJoined = false;
        isHighlighted = false;
        image.sprite = disjoinedImage;
    }
}
