using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChronicleObjectCreator : MonoBehaviour {

    public GameObject ChronicleObjectTemplate;
    //DEBUG
    public Spawner spawner;

    public ChronicleObject Create(string text)
    {
        GameObject newObj = (GameObject)Instantiate(ChronicleObjectTemplate);
        return newObj.GetComponent<ChronicleObject>();
    }

	// Use this for initialization
	void Start () {
        spawner.Spawn(this.Create("DEBUG"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
