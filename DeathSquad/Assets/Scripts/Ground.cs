using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			//Debug.Log("Aloooo");
			other.gameObject.transform.parent.GetComponent<Player>().RestartJumps();
		}
	}
}
