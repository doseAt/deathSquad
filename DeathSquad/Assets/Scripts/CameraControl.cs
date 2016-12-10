using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public static CameraControl instance = null;
	bool isShaking;
	Camera camera;

	void Awake()
	{
		if(instance == null)
			instance = this;
		else if(instance!=this)
			Destroy(gameObject);
		camera = gameObject.GetComponent<Camera>();
	}

	public void Shake()
	{
		//Debug.LogError ("Shake");
		if(!isShaking)
			StartCoroutine(ShakeCo());
	}


	IEnumerator ShakeCo()
	{
		isShaking = true;
		for (int i = 0; i < 50; i++) 
		{			
			if(transform.rotation.z == 0.0f)
			{
				transform.Rotate(new Vector3(0,0,1), Random.Range(-2.5f, 2.5f));
			}
			else
			{
				transform.rotation = new Quaternion(0,0,0,1);
			}
			yield return null;
		}
		//Debug.LogError ("Shake Done");
		isShaking = false;
		transform.rotation = new Quaternion(0,0,0,1);
	}


}
