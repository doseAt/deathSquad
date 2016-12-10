using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.LogError(other.gameObject.name);
		if(other.gameObject.tag == "Player")
		{
			//Debug.LogError("Aloooo");
			other.gameObject.GetComponent<Player>().RestartJumps();
		}
	}
}
