using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChase : MonoBehaviour
{

	[SerializeField]
	private Graph graph;

	[SerializeField]
	private float speed = 0.1f;

	private Node currentNode;
	private Node previousNode;

	private int layerMask = 1 << 8;

	[SerializeField] 
	private Transform pacman;

	private Node PossibleNewEndNode;
	
	void Start ()
	{
		layerMask = ~layerMask;
		currentNode = ClosestStartNodeToTarget();
		previousNode = currentNode; 
		Follow();
	}
	
	void Update()
	{
		if (currentNode != null)
		{
			transform.position = Vector3.MoveTowards(transform.position, currentNode.transform.position, speed);
		}
	}

	protected void Follow()
	{
		StopCoroutine ("FollowPath");

		StartCoroutine ("FollowPath");
	}
	
	IEnumerator FollowPath()
	{
		yield return new WaitUntil (HasReachedDestination );

		Node newPrevious = currentNode;
		currentNode = ClosestNeighboringNodeToTarget();
		previousNode = newPrevious;
		Follow();
	}

	private Node ClosestStartNodeToTarget()
	{
		List<Node> possibleStartNodes = new List<Node>();
		Collider[] nodes = Physics.OverlapSphere(transform.position, 7.0f);
            foreach (Collider hit in nodes)
            {
                if (hit.transform.GetComponent<Node>() != null && !Physics.Linecast(transform.position,hit.transform.position,layerMask))
                {
	                possibleStartNodes.Add(hit.transform.GetComponent<Node>());
                }
            }
            return graph.GetClosestNodeToTargetFromSelection(pacman,possibleStartNodes);
	}

	private Node ClosestNeighboringNodeToTarget()
	{
		return graph.GetClosestNeighborToTarget(pacman, currentNode, previousNode);
	}

	private bool HasReachedDestination()
	{
		return (transform.position.x == currentNode.transform.position.x && transform.position.z == currentNode.transform.position.z);
	}

	private float DistanceToPacMan()
	{
		return Vector3.Distance(transform.position, pacman.position);
	}
}
