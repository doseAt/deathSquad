using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	public int pointsForMe;

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.gameObject.name == "Player")
		{
			Player p = other.gameObject.GetComponent<Player>();
			if(p.attackModeOn)
			{
				p.points+=pointsForMe;
				Die();
			}
		}
		else if(other.gameObject.name == "Base")
		{
			Base.instance.Hurt();
			Destroy(gameObject);
			//unishtavam se
			//baci partikle
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		
		if(other.gameObject.name == "Player")
		{
			Player p = other.gameObject.GetComponent<Player>();
			if(p.attackModeOn)
			{
				Die();
			}
		}

	}

	void Start()
	{
		Vector3 movement = new Vector3(0, -5, 0) - transform.position;
		movement.Normalize();
		gameObject.GetComponent<Rigidbody2D>().velocity = movement;
	}


	void Die()
	{
		//instanciraj partikle
		//instanciraj krv na ekran
		Blood.instance.DropBlood();
		Pokega.SoundControl.instance.PlaySFX("hurt", 0.85f, 1.15f);
		Destroy(gameObject);
	}






}
