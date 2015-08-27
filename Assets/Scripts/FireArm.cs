using UnityEngine;
using System.Collections;

public class FireArm : MonoBehaviour {

	public float timeToDisappear = 0.25f;

	private CountdownTimer disappearTimer;
	private SpriteRenderer renderer;

	void Awake () 
	{
		disappearTimer = new CountdownTimer();
		renderer = GetComponent<SpriteRenderer>();
		renderer.enabled = false;
	}
	
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
