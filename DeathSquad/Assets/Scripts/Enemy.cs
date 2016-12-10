using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			Player p = other.gameObject.GetComponent<Player>();
			if(p.attackModeOn)
			{
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



	void Die()
	{
		//instanciraj partikle
		//instanciraj krv na ekran
		Blood.instance.DropBlood();
		Debug.Log("Enemy died");

	}






}
