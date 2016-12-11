using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public float dieForSeconds;

	void Awake()
	{
		Invoke("Die", dieForSeconds);
	}

	void Die()
	{
		Destroy(gameObject);
	}
}
