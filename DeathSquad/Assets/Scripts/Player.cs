using UnityEngine;
using System.Collections;
using SocketIO;

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
	public Vector2 netMove;
	public int jumpsLeft;
	public string data;


	//public GameObject player;

	void Awake()
	{
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
		jumpsLeft = 2;
		Time.timeScale = 1.2f;
		//data = TestSocketIO.instance.data;

	}



	void Update()
	{
		if (data =gameObject.GetComponent<TestSocketIO> ().data != null)
			data = gameObject.GetComponent<TestSocketIO> ().data;
		else data = "test";
		//stringToJson moves = JsonUtility.FromJson<stringToJson>(data);
		if (1 == 2){
		if (Input.GetKey (KeyCode.A)) {
			rigidbody.AddForce (new Vector2 (-horizontalMulti, 0), ForceMode2D.Impulse);
			if (-rigidbody.velocity.x > maxVeloPerX) {
				rigidbody.velocity = new Vector2 (-maxVeloPerX, rigidbody.velocity.y);
			}
		}
		if (Input.GetKey (KeyCode.D)) {
			rigidbody.AddForce (new Vector2 (1 * horizontalMulti, 0), ForceMode2D.Impulse);
			if (rigidbody.velocity.x > maxVeloPerX) {
				rigidbody.velocity = new Vector2 (maxVeloPerX, rigidbody.velocity.y);
			}
		}

		if (Input.GetKeyDown (KeyCode.Space) && jumpsLeft > 0) {
			rigidbody.AddForce (new Vector2 (0, verticalMulti), ForceMode2D.Impulse);	

			if (rigidbody.velocity.y > maxVeloPerY) {
				rigidbody.velocity = new Vector2 (rigidbody.velocity.x, maxVeloPerY);	
			}
			jumpsLeft--; 
		}

		netMove = new Vector2 (this.transform.position.x, this.transform.position.y);

		gameObject.GetComponent<NetworkMove> ().OnMove (netMove);

		}
	else {
			
			//this.transform.position = new Vector2 (moves.x, moves.y);	
			Debug.Log(data);
	}
	}

	public void RestartJumps()
	{
		jumpsLeft = 2;
	}

	public void AddForcePerY()
	{
		//rigidbody.AddForce(new Vector2(0, verticalMulti), ForceMode2D.Impulse);
	}

}
