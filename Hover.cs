/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : Singleton<Hover> {

    public SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		this.spriteRenderer = GetComponent<SpriteRenderer>();
            }
	
	// Update is called once per frame
	void Update ()
    {
        FollowMouse();
	}


    void FollowMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void Activate(Sprite sprite)
    {
        this.spriteRenderer.sprite = sprite;
    }
    public void Deactivate()
    {
        spriteRenderer.enabled = false;
    }
}*/
