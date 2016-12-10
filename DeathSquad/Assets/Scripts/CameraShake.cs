using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public static CameraShake instance = null;
	public bool shaking = false;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}


	public void ShakeShake()
	{
		
	}




	void StopShake()
	{
		shaking = false;
	}
}
