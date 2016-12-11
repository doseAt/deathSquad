using UnityEngine;
using System.Collections;
using Pokega;

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
		CameraControl.instance.Shake();
		Pokega.SoundControl.instance.PlaySFX("bomb");


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Hurt();
		}
	}

}
