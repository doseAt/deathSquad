using UnityEngine;

public class TestWalkerScript : MonoBehaviour {

	public BezierSpline curve;

	public float [] durations;
	public int currDuration;
	private float progress;
	Vector3 old;
	bool t;

	private void Update () {
		progress += Time.deltaTime / durations[currDuration]; //Debug.Log(durations[currDuration]);
		if (t) {
			t = false;
			//Debug.Log ("sad " + progress);
		}
		if (progress > 1f) {
			progress = 1f;
		}
		Vector3 currPoint = curve.GetPoint (progress);
		old = transform.localPosition;
		transform.localPosition = currPoint;
		if (currPoint == old) {
			progress = 0;
			old = new Vector3 (0, 0, 0);
			currDuration = 0;
		}

	}

	private void Start() {
		currDuration = 0;
		BezierSpline line = GetComponentsInChildren (typeof(BezierSpline)) [0] as BezierSpline;
		line.enabled = true;
	
		curve = line;
	}

	public void incrementCurrDuration() {
		currDuration++;
		t = true;
	}
}