using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
	[SerializeField]
	protected List<Node> m_Nodes = new List<Node>();
	
	public List<Node> Nodes => m_Nodes;

	public Node GetClosestNodeToTarget(Transform target)
	{
		return GetClosestNodeToTargetFromSelection(target, m_Nodes);
	}

	public Node GetClosestNodeToTargetFromSelection(Transform target, List<Node> nodes)
	{
		Node closestNode = nodes[0];
		float closestNodeDistance = Vector3.Distance(closestNode.transform.position, target.position);
		foreach (Node node in nodes)
		{
			float newDistance = Vector3.Distance(node.transform.position, target.position);
			if (newDistance < closestNodeDistance)
			{
				closestNode = node;
				closestNodeDistance = Vector3.Distance(closestNode.transform.position, target.position);
			}
		}
		return closestNode;
	}
	
	public Node GetClosestNeighborToTarget(Transform target, Node node,Node previousNode)
	{
		Node closestNode = node.neighbors[0];
		float closestNodeDistance = Vector3.Distance(closestNode.transform.position, target.position);
		foreach (Node neighbor in node.neighbors)
		{
			float newDistance = Vector3.Distance(neighbor.transform.position, target.position);
			if (newDistance < closestNodeDistance && neighbor != previousNode)
			{
				closestNode = neighbor;
				closestNodeDistance = Vector3.Distance(closestNode.transform.position, target.position);
			}
		}
		return closestNode;
	}
}
