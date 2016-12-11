using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour {

	void Start()
	{
		Time.timeScale = 0.0f;
	}

	public void StartMeUp()
	{
		Time.timeScale = 1.0f;
		gameObject.GetComponent<UISprite>().enabled=  false;
	}
}
