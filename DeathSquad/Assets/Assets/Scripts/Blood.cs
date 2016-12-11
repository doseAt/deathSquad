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

		droppedBloods = new List<GameObject>();

	}



	public void DropBlood()
	{
		int x = Random.Range(0, bloods.Length - 1);
		GameObject dropedBlood = Instantiate(bloods[x]) as GameObject;
		droppedBloods.Add(dropedBlood);
	}

	public void ClearBlood()
	{
		foreach(GameObject go in droppedBloods)
		{
			SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
			sr.color = new Color(1,1,1, sr.color.a - 0.3f);
		}
		if(droppedBloods.Count>0)
		{
			foreach(GameObject go1 in droppedBloods.ToArray())
			{
				SpriteRenderer sr1 = go1.GetComponent<SpriteRenderer>();
				if(sr1.color.a < 0.2f)
				{
					droppedBloods.Remove(go1);
					Destroy(go1);
				}
			}
		}
	}

}
