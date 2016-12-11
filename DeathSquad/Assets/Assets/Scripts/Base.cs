using UnityEngine;
using System.Collections;
using Pokega;
using UnityEngine.SceneManagement;

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
		if(health <= 0)
		{
			Time.timeScale = 0.1f;
			Invoke("StartOver", 0.2f);
		}
	}


	void StartOver()
	{
		SceneManager.LoadScene("Main");
	}

}
