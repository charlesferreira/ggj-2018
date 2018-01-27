using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSlot : MonoBehaviour {

    RawImage image;

    public Texture joinedImage;
    public Texture disjoinedImage;
    public Texture highlightImage;

    [HideInInspector]
    public int joystickIndex;
    [HideInInspector]
    public bool isJoined = false;
    [HideInInspector]
    public bool isHighlighted = false;
	
	void Start () {
        image = GetComponent<RawImage>();
	}

    public void Join(int joystickIndex)
    {
        isJoined = true;
        this.joystickIndex = joystickIndex;
        image.texture = joinedImage;
    }

    public void Highlight()
    {
        isHighlighted = true;
        image.texture = highlightImage;
    }

    public void Unhighlight()
    {
        isHighlighted = false;
        image.texture = joinedImage;
    }

    public void Leave()
    {
        isJoined = false;
        image.texture = disjoinedImage;
    }
}
