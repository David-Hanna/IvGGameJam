using UnityEngine;
using System.Collections;

public abstract class ZombieState 
{
	protected Zombie zombie;
	
	public abstract void FixedUpdate ();
	public abstract void UpdateAI ();
	public abstract void OnStateChange ();
}