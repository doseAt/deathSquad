using UnityEngine;
using System.Collections;

public class SphereScript : MonoBehaviour {

	public bool shouldMoveAlongTheCurve = true;
	void OnCollisionEnter (Collision col) {
		shouldMoveAlongTheCurve = false;
	}

}
