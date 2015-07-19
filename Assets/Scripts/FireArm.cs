using UnityEngine;
using System.Collections;

public class FireArm : MonoBehaviour {

	public float timeToDisappear = 0.25f;

	private CountdownTimer disappearTimer;
	private SpriteRenderer renderer;

	// Use this for initialization
	void Awake () 
	{
		disappearTimer = new CountdownTimer();
		renderer = GetComponent<SpriteRenderer>();
		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!disappearTimer.done)
		{
			disappearTimer.Update (Time.deltaTime);
		}	
		else if (renderer.enabled)
		{
			renderer.enabled = false;
		}
	}
	
	public void Fire()
	{
		renderer.enabled = true;
		disappearTimer.Start (timeToDisappear);
	}
}
