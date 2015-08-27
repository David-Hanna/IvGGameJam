using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ZombieSpawnManager : MonoBehaviour {

	public bool[] roomsUnlocked;
	
	public float spawnTime = 3.0f;
	public float decrement = 0.05f;
	public float decrementTime = 10.0f;
	public float decrementTimeIncrease = 1.0f;
	public float decrementTimeIncreaseTime = 30.0f;
	
	public float minimumSpawnTime = 1.0f;
	
	private CountdownTimer spawnTimer;
	private CountdownTimer decrementTimer;
	private CountdownTimer decrementTimeIncreaseTimer;
	private System.Random random;

	void Start () 
	{
		spawnTimer = new CountdownTimer();
		spawnTimer.Start (spawnTime);
		
		decrementTimer = new CountdownTimer();
		decrementTimer.Start (decrementTime);
		
		decrementTimeIncreaseTimer = new CountdownTimer();
		decrementTimeIncreaseTimer.Start (decrementTimeIncreaseTime);
		
		random = new System.Random();
	}
	
	void Update () 
	{
		spawnTimer.Update (Time.deltaTime);
		decrementTimer.Update (Time.deltaTime);
		decrementTimeIncreaseTimer.Update (Time.deltaTime);
		
		if (spawnTimer.done)
		{
			Spawn();
			spawnTimer.Start (spawnTime);
		}
		
		if (spawnTime > minimumSpawnTime)
		{
			if (decrementTimer.done)
			{
				spawnTime -= decrement;
				decrementTimer.Start (decrementTime);
			}
			
			if (decrementTimeIncreaseTimer.done)
			{
				decrementTime += decrementTimeIncrease;
				decrementTimeIncreaseTimer.Start (decrementTimeIncreaseTime);
			}
		}
	}
	
	private void Spawn()
	{
		List<Transform> allowedSpawnPoints = new List<Transform>();
		for (int i = 0; i < transform.childCount; ++i)
		{
			if (roomsUnlocked[i] == true)
			{
				Transform child = transform.GetChild(i);
				if (child)
				{
					for (int j = 0; j < child.childCount; ++j)
					{
						allowedSpawnPoints.Add (child.GetChild (j));
					}
				}
			}
		}
		
		GameObject zombie = GameObject.Instantiate (Resources.Load ("Zombie")) as GameObject;
		zombie.transform.position = allowedSpawnPoints[random.Next (allowedSpawnPoints.Count)].position;
		zombie.transform.rotation = Quaternion.LookRotation (Vector3.forward);
	}
}
