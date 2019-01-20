using System.Collections;
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
    public PolyChronicleObjectCreator polyChronicleObjectCreator;
    public MusicChronicleObjectCreator musicChronicleObjectCreator;

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

                    switch (chronicleData.type)
                    {
                        case "text":
                            spawner.Spawn(textChronicleObjectCreator.Create(chronicleData.data));
                            break;
                        case "photo":
                            spawner.Spawn(photoChronicleObjectCreator.Create(chronicleData.data));
                            break;
                        case "poly":
                            spawner.Spawn(polyChronicleObjectCreator.Create(chronicleData.data));
                            break;
                        case "music":
                            spawner.Spawn(musicChronicleObjectCreator.Create(chronicleData.data));
                            break;

                        default:
                            break;
                    }

                }


                // Or retrieve results as binary data
                //byte[] results = www.downloadHandler.data;
            }
        }
    }

	// Update is called once per frame
	void Update () {

        //DEBUG SPAWN POLY
        if(Input.GetKeyDown(KeyCode.P)){
            spawner.Spawn(polyChronicleObjectCreator.Create("BoomboxPoly"));
        }
		
	}
}
