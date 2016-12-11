using UnityEngine;
using System.Collections;

public class FollowAlpha : MonoBehaviour {

	public SpriteRenderer followHim;
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		gameObject.GetComponent<UISprite>().alpha = followHim.color.a;
	}
}
