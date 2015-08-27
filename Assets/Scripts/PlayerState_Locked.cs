using UnityEngine;
using System.Collections;

public class PlayerState_Locked : PlayerState 
{
	CountdownTimer lockedForCountdown;

	public PlayerState_Locked(Player p)
	{
		player = p;
		lockedForCountdown = new CountdownTimer ();
		lockedForCountdown.Start (0.5f);
	}

	override public void Update () 
	{
		lockedForCountdown.Update (Time.deltaTime);
		if (lockedForCountdown.done) 
		{
			player.ChangeState (new PlayerState_Normal (player));
		}
	}

	override public void FixedUpdate () {}
	override public void Move () {}
	override public void Fire () {}
	override public void TakeDamage () {}
	override public void OnChangeState () {}
	
	override public void PickupHealthRegen () {}
	override public void PickupAutoLife () {}
	override public void PickupRunJuice () {}
	override public void PickupRegenBarrier () {}
	override public void PickupVolcanoShells (int number) {}
	override public void PickupIceShot () {}
	override public void PickupLightningShot () {}
	override public void PickupInvincibleAura () {}
	override public void PickupBarrier () {}
}
