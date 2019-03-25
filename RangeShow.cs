using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeShow : MonoBehaviour {

    public SpriteRenderer range;

	void Start () {
        range = GetComponent<SpriteRenderer>();
        this.range = transform.GetChild(0).GetComponent<SpriteRenderer>();
	}
	

    void OnMouseDown()
    {
        range.enabled = false;
    }

    void OnMouseExit()
    {
        range.enabled = false;
    }

	
}
