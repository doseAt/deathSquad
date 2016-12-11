using UnityEngine;
using System.Collections;
using Pokega;

public class Base : MonoBehaviour {

	public float health = 1;
	public float damage;
	public static Base instance = null;
	public UISprite healthBar;
	public UILabel healthLabel;

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
		gameObject.GetComponent<UIPlayTween>().resetOnPlay = true;
		gameObject.GetComponent<UIPlayTween>().Play(true);
		Pokega.SoundControl.instance.PlaySFX("bomb", 0.8f, 1.05f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			Hurt();
		}
	}

	void Update()
	{
		healthBar.fillAmount = health;
		healthLabel.text = ((int)(health * 100)).ToString();
	}

}
