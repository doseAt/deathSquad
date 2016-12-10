using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Blood : MonoBehaviour {

	public static Blood instance = null;
	public GameObject[] bloods;
	List<SpriteRenderer> droppedBloods;



	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}



	public void DropBlood()
	{
		/*
		int x = Random.Range(0, bloods.Length - 1);
		GameObject dropedBlood = Instantiate(bloods[x]) as GameObject;
		SpriteRenderer sr = dropedBlood.GetComponent<SpriteRenderer>();
		droppedBloods.Add(sr);
		*/
	}

	public void ClearBlood()
	{
		/*
		foreach(SpriteRenderer sr in droppedBloods)
		{
			sr.color = new Color(1,1,1, sr.color.a - 0.3f);

		}
		foreach(SpriteRenderer sr in droppedBloods)
		{
			if(sr.color.a < 0.2f)
			{
				droppedBloods.Remove(sr);
			}
		}
*/
	}

}
