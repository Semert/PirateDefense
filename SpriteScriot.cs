using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScriot : MonoBehaviour {

    private SpriteRenderer rend;

    public Color startColor = Color.black;
    public Color otherColor;


	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
        rend.color = startColor;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            rend.color = otherColor;
        } 
	}

  

}
