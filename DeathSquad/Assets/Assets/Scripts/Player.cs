using UnityEngine;
using System.Collections;
using Pokega;

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
	public GameObject lightSaber;
	public GameObject[] attacksLeftUIElemets;
	public UILabel pointsLabel;

	public int points = 0;

	void Start(){
		Pokega.SoundControl.instance.PlaySFX("theme");
	}

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
		gameObject.GetComponent<UIPlayTween>().tweenGroup = 2;
		gameObject.GetComponent<UIPlayTween>().Play(true);
		gameObject.GetComponent<SpriteRenderer>().color = Color.red;
		Pokega.SoundControl.instance.PlaySFX("impact");
		CancelInvoke("RefillAttack");
		attacksLeft--;
		attackModeOn = true;
		Invoke("AttackOff", attackTime);
	}

	void AttackOff()
	{
		TweenRotation[] trs = gameObject.GetComponentsInChildren<TweenRotation>();
		foreach(TweenRotation tr in trs)
		{
			if(tr.tweenGroup == 2)
				tr.enabled = false;
		}
		//gameObject.GetComponent<UIPlayTween>().
		gameObject.GetComponent<UIPlayTween>().tweenGroup = 1;
		gameObject.GetComponent<UIPlayTween>().Play(true);
		attackModeOn = false;
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
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

		lightSaber.SetActive(attackModeOn);

		if(rigidbody.velocity.x < 0)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}
		else if(rigidbody.velocity.x > 0)
		{
			transform.localScale = new Vector3(1, 1, 1);
		}
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
		if(Input.GetKeyDown(KeyCode.W) && jumpsLeft > 0)
		{
			Pokega.SoundControl.instance.PlaySFX ("jump");
			rigidbody.AddForce(new Vector2(0, verticalMulti), ForceMode2D.Impulse);	

			if(rigidbody.velocity.y > maxVeloPerY)
			{
				rigidbody.velocity = new Vector2(rigidbody.velocity.x, maxVeloPerY);	
			}
			jumpsLeft--; 
			gameObject.GetComponentInChildren<ParticleSystem>().Play(false);
			//gameObject.GetComponentInChildren<ParticleSystem>().
		}

		//attack
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			Attack();

		}

		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			Blood.instance.ClearBlood();
		}

		//test shake kamere
		if(Input.GetKeyDown(KeyCode.M))
		{
			CameraControl.instance.Shake();
		}

		for(int i=0; i<5; i++)
		{
			if(attacksLeft > i)
				attacksLeftUIElemets[i].SetActive(true);
			else
				attacksLeftUIElemets[i].SetActive(false);
		}


		pointsLabel.text = points.ToString();
	}

	public void RestartJumps()
	{
		jumpsLeft = 2;
	}
}
