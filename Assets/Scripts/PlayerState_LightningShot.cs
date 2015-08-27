using UnityEngine;
using System.Collections;

public class PlayerState_LightningShot : PlayerState_Normal 
{
	public PlayerState_LightningShot(Player p) : base(p) 
	{
	}

	override public void Update () {}
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
