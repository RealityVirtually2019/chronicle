using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PhotoChronicleObjectCreator : MonoBehaviour {


    public GameObject ChronicleObjectTemplate;
    public string imgURL = "https://lh6.googleusercontent.com/S_6Cwjn5Z0dbUUq7fcq_CC1UgQtquEMV8Q1M3I6Phq5uI-PIPkeGtpPAFRwB7tJ8K6bkWbN83XDWLJ1hMKV4=w2674-h1506-rw";



    public ChronicleObject Create()
    {
        GameObject newObj = (GameObject)Instantiate(ChronicleObjectTemplate);
        Material newPhotoMat = new Material(Shader.Find("Unlit/Texture"));
        newObj.transform.GetChild(0)
              .GetComponent<Renderer>().material = newPhotoMat;
        StartCoroutine(UploadTextureToMat(newPhotoMat));
        return newObj.GetComponent<ChronicleObject>();
    }

    IEnumerator UploadTextureToMat(Material material)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(imgURL))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log("IMAGE REQUEST ERROR");
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                Debug.Log("IMAGE REQUEST SUCCEEDED");
                var texture = DownloadHandlerTexture.GetContent(uwr);
                material.mainTexture = texture;

            }
        }
    }

	// Use this for initialization
	void Start () {
        GameObject.Find("Cursor")
                  .GetComponent<Spawner>().SelectedObject = this.Create();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
