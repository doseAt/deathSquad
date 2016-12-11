using UnityEngine;
using System.Collections;

public class SpaceMaker : MonoBehaviour {

	public GameObject star;
	public GameObject starParent;
	public int numberOfStarts;

	void Start()
	{
		for(int i=0; i<numberOfStarts; i++)
		{
			Vector3 randomPos = Random.insideUnitCircle * 10;
			float randomScale = Random.Range(0.2f, 1f);
			GameObject go = Instantiate(star, randomPos, Quaternion.identity) as GameObject;
			go.transform.localScale = new Vector3(randomScale, randomScale, 0);
			go.transform.SetParent(starParent.transform);
			go.AddComponent<TweenAlpha>();
			TweenAlpha ta = go.GetComponent<TweenAlpha>();
			float tweenAlphaFrom = Random.Range(0.2f, 0.5f);
			float tweenAlphaTo = Random.Range(0.6f, 1f);
			ta.from = tweenAlphaFrom;
			ta.to = tweenAlphaTo;
			float duration = Random.Range(0.6f, 2f);
			ta.duration = duration;
			ta.enabled = true;
			ta.style = UITweener.Style.PingPong;
			ta.Play(true);
			//ta.

		}
	}
}
