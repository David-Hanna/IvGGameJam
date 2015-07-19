using UnityEngine;
using System.Collections;

public abstract class PlayerState 
{
	protected Player player;

	abstract public void Update ();
	abstract public void FixedUpdate ();
	abstract public void Move ();
	abstract public void Fire ();
	abstract public void TakeDamage ();
	abstract public void OnChangeState ();
	
	abstract public void PickupHealthRegen ();
	abstract public void PickupAutoLife ();
	abstract public void PickupRunJuice ();
	abstract public void PickupRegenBarrier ();
	abstract public void PickupVolcanoShells (int number);
	abstract public void PickupIceShot ();
	abstract public void PickupLightningShot ();
	abstract public void PickupInvincibleAura ();
	abstract public void PickupBarrier ();
}
