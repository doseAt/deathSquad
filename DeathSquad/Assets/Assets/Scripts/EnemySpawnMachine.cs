using UnityEngine;
using System.Collections;

public class EnemySpawnMachine : MonoBehaviour {

	public enum spawnPointType{
		ABOVE,
		SIDES,
		GROUND
	};

	public spawnPointType mSpawnPointType;
	public GameObject[] enemies;
	public int maxEnemies;
	public int horizontalSpawnDots;
	public int maxLivingEnemies;
	public float spawnTime = 10;
	private int enemyCounter;
	// Use this for initialization
	void Start () 
	{
		if (mSpawnPointType == spawnPointType.ABOVE) 
			InvokeRepeating ("addEnemyAbove", 5f, spawnTime);

	

	}


	void addEnemyAbove() 
	{
		//Debug.LogError ("aaa");
		enemyCounter++; // pomeri ovo u for blok
		revokeRepeatingIfShould ();

		int amountToSummon = Random.Range (0, 10);
		for (int i = 0; i < 2; i++) {
			int indexOfEnemyToBeSpawned = Random.Range (0, enemies.Length);
			Instantiate (enemies [indexOfEnemyToBeSpawned], enemies [indexOfEnemyToBeSpawned].transform.position, Quaternion.identity);
		}
	}

	void addEnemySides() {
		enemyCounter++;
		revokeRepeatingIfShould ();
		Renderer r = GetComponent<Renderer> ();
		float y = transform.position.y - r.bounds.size.y / 2;
		float y2 = transform.position.y + r.bounds.size.y / 2;
		Vector2 spawnPoint = new Vector2 (Random.Range (y, y2), transform.position.y);
	//	Instantiate (enemy, spawnPoint, Quaternion.identity);
	}

	private void revokeRepeatingIfShould() 
	{
		if (enemyCounter > maxEnemies) {
			//CancelInvoke ();//("addEnemyAbove");
			//add other later
		}
	}
}
