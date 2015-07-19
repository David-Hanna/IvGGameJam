using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Dijkstras;

public class ZombiePathNodeManager : MonoBehaviour {

	public Transform closestNode { get; private set; }
	public Graph graph { get; private set; }
	
	private Transform target;
	private CountdownTimer reSearchTimer;
	
	void Start()
	{
		graph = new Graph();
		
		for (int i = 0; i < transform.childCount; ++i)
		{
			ZombiePathNode node = transform.GetChild (i).GetComponent<ZombiePathNode>();
			if (node != null)
			{
				Dictionary<string, int> edges = new Dictionary<string, int>();
				
				for (int j = 0; j < node.neighbors.Length; ++j)
				{
					edges.Add (node.neighbors[j].gameObject.name, (int)(node.transform.position - node.neighbors[j].transform.position).sqrMagnitude);
				}
				
				graph.add_vertex (node.gameObject.name, edges);
			}
		}
	
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		findClosestNodeToPlayer();
		reSearchTimer = new CountdownTimer();
		reSearchTimer.Start (3.0f);
	}
	
	void Update () 
	{
		reSearchTimer.Update (Time.deltaTime);
		if (reSearchTimer.done)
		{
			findClosestNodeToPlayer();
			reSearchTimer.Start (3.0f);
		}
	}
	
	public GameObject FindNextNode(GameObject currentNode)
	{
		GameObject nextNode = null;
	
		List<string> result = graph.shortest_path (currentNode.name, closestNode.gameObject.name);
		if (result != null && result.Count > 0)
		{
			bool found = false;
			int i = 0;
			
			while (!found && i < transform.childCount)
			{
				nextNode = transform.GetChild(i).gameObject;
				if (nextNode.name == result[result.Count - 1])
				{
					found = true;
				}
				++i;
			}
		}
		
		return nextNode;
	}
	
	private void findClosestNodeToPlayer()
	{
		float closestSqrDistance = float.MaxValue;
		for (int i = 0; i < transform.childCount; ++i)
		{
			Transform node = transform.GetChild (i);
			Vector3 toPlayer = target.position - node.position;
			float sqrDistance = toPlayer.sqrMagnitude;
			if (sqrDistance < closestSqrDistance)
			{
				node.GetComponent<CircleCollider2D>().enabled = false;
				RaycastHit2D hit = Physics2D.Raycast (node.transform.position, toPlayer);
				node.GetComponent<CircleCollider2D>().enabled = true;
				if (hit.collider != null && hit.collider.tag == "Player")
				{
					closestSqrDistance = sqrDistance;
					closestNode = node;
				}
			}
		}
	}
}
