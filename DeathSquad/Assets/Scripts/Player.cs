using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	Rigidbody2D rigidbody;
	public float horizontalMulti;
	public float verticalMulti;
	public float maxVelocity;
	public float velocityAddPerFrame;
	public float maxVeloPerX;
	public float maxVeloPerY;
	public float timeScale = 1;
	public int jumpsLeft;

	public int maxAttacks;
	public int attacksLeft;
	public bool attackModeOn = false;
	public float attackTime;
	public float attackRefillTime;


	void Awake()
	{
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
		jumpsLeft = 2;
		Time.timeScale = 1.2f;
	}

	void Attack()
	{
		if(attacksLeft <= 0 || attackModeOn)
			return;

		CancelInvoke("RefillAttack");
		attacksLeft--;
		attackModeOn = true;
		Invoke("AttackOff", attackTime);
	}

	void AttackOff()
	{
		attackModeOn = false;

		Invoke("RefillAttack", attackRefillTime);
	}

	void RefillAttack()
	{
		if(attacksLeft < maxAttacks)
		{
			attacksLeft++;
			Invoke("RefillAttack", attackRefillTime);
		}
	}










	void Update()
	{

		//kretnja levo
		if(Input.GetKey(KeyCode.A))
		{
			rigidbody.AddForce(new Vector2(-horizontalMulti, 0), ForceMode2D.Impulse);
			if(-rigidbody.velocity.x > maxVeloPerX)
			{
				rigidbody.velocity = new Vector2(-maxVeloPerX, rigidbody.velocity.y);
			}
		}
		//kretnja desno
		if(Input.GetKey(KeyCode.D))
		{
			rigidbody.AddForce(new Vector2(1* horizontalMulti, 0), ForceMode2D.Impulse);
			if(rigidbody.velocity.x > maxVeloPerX)
			{
				rigidbody.velocity = new Vector2(maxVeloPerX, rigidbody.velocity.y);
			}
		}

		//skok
		if(Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
		{
			rigidbody.AddForce(new Vector2(0, verticalMulti), ForceMode2D.Impulse);	

			if(rigidbody.velocity.y > maxVeloPerY)
			{
				rigidbody.velocity = new Vector2(rigidbody.velocity.x, maxVeloPerY);	
			}
			jumpsLeft--; 
		}

		//attack
		if(Input.GetKeyDown(KeyCode.S))
		{
			Attack();
		}

		if(Input.GetKeyDown(KeyCode.W))
		{
			Blood.instance.ClearBlood();
		}

		//test shake kamere
		if(Input.GetKeyDown(KeyCode.M))
		{
			CameraControl.instance.Shake();
		}

	}

	public void RestartJumps()
	{
		jumpsLeft = 2;
	}
}
