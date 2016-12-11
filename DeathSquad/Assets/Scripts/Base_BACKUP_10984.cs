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
<<<<<<< HEAD
		gameObject.GetComponent<UIPlayTween>().Play(true);
=======
		Pokega.SoundControl.instance.PlaySFX("bomb");


>>>>>>> bc33f2d1305904af570ae2b06a351b6857f6be56
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Hurt();
		}
	}

}
