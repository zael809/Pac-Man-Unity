using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : MonoBehaviour
{
    //this will hold basic ghost behaviour for calling chase, retreat and fear behaviour changes
    //chase will have 4 different iterations based on a base class to call the same function applied differently
    //
    private GhostChase chaseBehaviour;


    // Start is called before the first frame update
    void Start()
    {
        chaseBehaviour = GetComponent<GhostChase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    
    
}
