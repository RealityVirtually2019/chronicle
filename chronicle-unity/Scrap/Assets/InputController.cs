using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class InputController : MonoBehaviour {
    
    private MLInputController controller;
    private Spawner spawner;

    void Awake()
    {
        MLInput.Start();
        controller = MLInput.GetController(MLInput.Hand.Left);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
