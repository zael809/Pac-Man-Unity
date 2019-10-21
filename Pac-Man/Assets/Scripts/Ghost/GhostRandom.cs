using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRandom : GhostChase
{
    // Start is called before the first frame update
    void Start()
    {
        target = graph.GetRandomNode().transform;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        
        if (DistanceToTarget() < 3.0f)
            target = graph.GetRandomNode().transform;
    }
}
