using UnityEngine;
using System.Collections;

public class SideWalls : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			
		}
	}
}
