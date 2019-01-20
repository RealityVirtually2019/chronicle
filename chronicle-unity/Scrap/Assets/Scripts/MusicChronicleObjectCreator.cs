using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChronicleObjectCreator : MonoBehaviour {

    public GameObject ChronicleObjectTemplate;
    //DEBUG
    public Spawner spawner;

    public ChronicleObject Create(string musicName)
    {
        GameObject newObj = Instantiate(Resources.Load("MusicChronicles/" + musicName + "MusicChronicle", typeof(GameObject))) as GameObject;
        return newObj.GetComponent<ChronicleObject>();
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
