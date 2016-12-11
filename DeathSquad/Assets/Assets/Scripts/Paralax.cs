using UnityEngine;
using System.Collections;

public class Paralax : MonoBehaviour {

	public Transform playerTransform;
	public float coeficient;

	void FixedUpdate()
	{
		
		transform.position = new Vector3(-playerTransform.position.x * coeficient, transform.position.y, transform.position.z);
	}
}
