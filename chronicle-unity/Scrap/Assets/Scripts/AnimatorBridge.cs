using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBridge : MonoBehaviour {

    public Animator animator;
    public string Param = "isRecordExposed";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetBool(bool val){
        animator.SetBool(Param, val);
    }
}
