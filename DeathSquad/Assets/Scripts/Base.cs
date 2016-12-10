using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	public float health = 1;
	public float damage;
	public static Base instance = null;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}

	public void Hurt()
	{
		health-=damage;

	}

}
