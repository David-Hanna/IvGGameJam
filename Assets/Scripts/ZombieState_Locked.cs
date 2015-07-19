using UnityEngine;
using System.Collections;

public class ZombieState_Locked : ZombieState
{
	CountdownTimer lockedTimer;

	public ZombieState_Locked(Zombie z)
	{
		zombie = z;
		
		lockedTimer = new CountdownTimer();
		lockedTimer.Start (1.0f);
		//Debug.Log ("Zombie State is LOCKED.");
	}

	public override void Update () 
	{
		lockedTimer.Update (Time.deltaTime);
		if (lockedTimer.done)
		{
			zombie.ChangeState (new ZombieState_Normal(zombie));
		}
	}
	
	public override void FixedUpdate () {}
	public override void UpdateAI () {}
	public override void OnStateChange () {}
}
