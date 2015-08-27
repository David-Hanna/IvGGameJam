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
	}
	
	public override void FixedUpdate () 
	{
		lockedTimer.Update (Time.fixedDeltaTime);
		if (lockedTimer.done)
		{
			zombie.ChangeState (new ZombieState_Normal(zombie));
		}
	}
	
	public override void UpdateAI () {}
	public override void OnStateChange () {}
}
