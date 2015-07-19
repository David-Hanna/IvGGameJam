using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombiePathNode : MonoBehaviour 
{
	public ZombiePathNode[] neighbors;
	
	void Start()
	{
		
	}
	
	// check for nil
	public Transform nextClosestNode()
	{
		float shortestDistance = float.MaxValue;
		Transform closestNode = null;
		for (int i = 0; i < neighbors.Length; ++i)
		{
			float distance = shortestPathToPlayerDistance(new List<ZombiePathNode>());
			if (distance < shortestDistance)
			{
				shortestDistance = distance;
				//Debug.Log (neighbors[i].ToString () + " distance: " + distance);
				closestNode = neighbors[i].transform;
			}
		}
		return closestNode;
	}
	
	// to be called recursively by other ZombiePathNodes.
	public float shortestPathToPlayerDistance(List<ZombiePathNode> alreadySearched)
	{
		alreadySearched.Add (this);
		
		// early exit - base case - this is the closest node.
		StoreClosestNodeToPlayer closestNodeScript = transform.parent.gameObject.GetComponent<StoreClosestNodeToPlayer>();
		if (transform.position == closestNodeScript.closestNode.position)
		{
			Debug.Log ("Closest node to player " + this.ToString () + " distance found: " + closestNodeScript.sqrDistanceToTarget);
			return closestNodeScript.sqrDistanceToTarget;
		}
	
		// find out which neighbor has the shortest distance, unless it's already been traversed.
		float shortestPathDistance = float.MaxValue;
		ZombiePathNode closestNode = null;
		for (int i = 0; i < neighbors.Length; ++i)
		{
			if (neighbors[i] != null)
			{
				bool contains = false;
				int j = 0;
				while (!contains && j < alreadySearched.Count)
				{
					if (neighbors[i].transform.position == alreadySearched[j].transform.position)
					{
						contains = true;
					}
					
					++j;
				}
				
				if (!contains)
				{
					float neighborShortestPathDistance = neighbors[i].shortestPathToPlayerDistance(alreadySearched);
					if (neighborShortestPathDistance < shortestPathDistance)
					{
						shortestPathDistance = neighborShortestPathDistance;
						closestNode = neighbors[i];
					}
				}
			}
		}
		
		// if closest node is null here, then there is no path from here to the player.
		// if not, return the shortest neighboring distance found plus the distance from here to that neighbor.
		if (closestNode != null)
		{
			float distanceToClosestNode = (transform.position - closestNode.transform.position).sqrMagnitude;
			shortestPathDistance += distanceToClosestNode;
		}
		
		Debug.Log (this.ToString () + " distance found: " + shortestPathDistance);
		return shortestPathDistance;
	}
}
