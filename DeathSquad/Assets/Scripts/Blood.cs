using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Blood : MonoBehaviour {

	public static Blood instance = null;
	public GameObject[] bloods;
	List<GameObject> droppedBloods;



	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}

	void Start()
	{
		droppedBloods = new List<GameObject>();
	}



	public void DropBlood()
	{
		Debug.LogError("ALo bre");
		int x = Random.Range(0, bloods.Length - 1);
		GameObject dropedBlood = Instantiate(bloods[x], Vector3.zero, Quaternion.identity) as GameObject;
		droppedBloods.Add(bloods[x]);
	}

	public void ClearBlood()
	{
		Debug.LogError("Error");
		foreach(GameObject go in droppedBloods)
		{
			go.GetComponent<SpriteRenderer>().color = new Color(1,1,1, go.GetComponent<SpriteRenderer>().color.a - 0.3f);
		}
		foreach(GameObject go in droppedBloods)
		{
			if(go.GetComponent<SpriteRenderer>().color.a < 0.2f)
			{
				Destroy(go);
				droppedBloods.Remove(go);
			}
		}
	}

}
