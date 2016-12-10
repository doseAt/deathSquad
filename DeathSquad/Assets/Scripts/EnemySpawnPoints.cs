using UnityEngine;
using System.Collections;

public class EnemySpawnPoints : MonoBehaviour {

	public GameObject[] spawnPoints;
	public static EnemySpawnPoints instance = null;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		spawnPoints = new GameObject[transform.childCount];
		for(int i=0; i<transform.childCount; i++)
		{
			spawnPoints[i] = transform.GetChild(i);
		}
	}




}
