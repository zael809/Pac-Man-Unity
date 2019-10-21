using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(Graph))]
public class GraphEditor : Editor
{
	private Graph graph;

	private void OnEnable()
	{
		graph = target as Graph;
	}

	private void OnSceneGUI()
	{
		if ( graph == null )
		{
			return;
		}
		for (int i = 0; i < graph.Nodes.Count; i++)
		{
			Node node = graph.Nodes [i];
			for (int j = 0; j < node.neighbors.Count; j++)
			{
				Node neighbor = node.neighbors [j];
				if (neighbor == null)
				{
					continue;
				}
				Handles.DrawLine (node.transform.position, neighbor.transform.position);
			}
		}
	}

	public override void OnInspectorGUI()
	{
		graph.Nodes.Clear();
		foreach (Transform child in graph.transform)
		{
			Node node = child.GetComponent<Node>();
			if (node != null)
			{
				graph.Nodes.Add (node);
			}
		}
	}
}
