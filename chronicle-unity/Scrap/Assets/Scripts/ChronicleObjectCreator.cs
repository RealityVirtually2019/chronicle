using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronicleObjectCreator : MonoBehaviour {

    public GameObject ChronicleObjectTemplate;

    public virtual ChronicleObject Create(){
        return null;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
