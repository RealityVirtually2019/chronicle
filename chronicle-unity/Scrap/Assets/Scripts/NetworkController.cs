﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class ChronicleData{

    public string type;
    public string data;

    public static ChronicleData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ChronicleData>(jsonString);
    }
    
}

public class NetworkController : MonoBehaviour {

    public string url;
    public Spawner spawner;
    public TextChronicleObjectCreator textChronicleObjectCreator;
    public PhotoChronicleObjectCreator photoChronicleObjectCreator;

	// Use this for initialization
	void Start () {
        
        InvokeRepeating("GetLatestItem", 0f, 1f);
	}
    	
    private void GetLatestItem(){
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                ChronicleData chronicleData = 
                    ChronicleData.CreateFromJSON(www.downloadHandler.text);

                if(chronicleData.type != "" && chronicleData.data != ""){
                    Debug.Log(chronicleData.data);

                    if (chronicleData.type == "text") {
                        spawner.Spawn(textChronicleObjectCreator.Create(chronicleData.data));
                    }
                }


                // Or retrieve results as binary data
                //byte[] results = www.downloadHandler.data;
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
