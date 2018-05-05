using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehaviour : MonoBehaviour {

    Rigidbody2D rgb;
    float move;
    bool groundChecker;
    public LayerMask ground;
	
    // Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Jump()
    {
       
    }
}
