using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAhead : GhostChase
{
    private Node CloseNodeToTarget;

    void Start()
    {

        base.Start();
    }
    
    void Update()
    {
        base.Update();

        SetNewTargetPosition();
    }

    private void SetNewTargetPosition()
    {

    }
}
