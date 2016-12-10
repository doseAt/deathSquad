using UnityEngine;
using System.Collections;

public class EnemyDaddy : MonoBehaviour {

	public static EnemyDaddy instance = null;
	public GameObject[] enemies;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}

	void Start()
	{
		InvokeRepeating("DropEnemy", 0f, 0.5f);
	}

	void DropEnemy()
	{
		int x = Random.Range(0, enemies.Length-1);
		int randomSpot = Random.Range(0, EnemySpawnPoints.instance.spawnPoints.Length-1);
		Vector3 pos = EnemySpawnPoints.instance.spawnPoints[randomSpot].transform.position;
		Instantiate(enemies[x], pos, Quaternion.identity);
	}




}
