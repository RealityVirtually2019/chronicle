using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PhotoChronicleObjectCreator : MonoBehaviour {


    public GameObject ChronicleObjectTemplate;
    public string imgURL = "https://lh6.googleusercontent.com/S_6Cwjn5Z0dbUUq7fcq_CC1UgQtquEMV8Q1M3I6Phq5uI-PIPkeGtpPAFRwB7tJ8K6bkWbN83XDWLJ1hMKV4=w2674-h1506-rw";



    public ChronicleObject Create(string imgData)
    {
        GameObject newObj = (GameObject)Instantiate(ChronicleObjectTemplate);

        Material newPhotoMat = new Material(Shader.Find("Unlit/Texture"));
        newObj.transform.GetChild(0)
              .GetComponent<Renderer>().material = newPhotoMat;
        Texture2D texture = new Texture2D(300,300);

        if(texture.LoadImage(System.Convert.FromBase64String(imgData))){
            Debug.Log("Texture Upload Success");
        }else{
            Debug.Log("Texture Upload Failed");
        }


        newPhotoMat.mainTexture = texture;

        //now scale the Photo and Frame proportionally
        var photoTransform = newObj.transform.GetChild(0).transform;
        var width = photoTransform.localScale.x;
        var height = photoTransform.localScale.y;
        var zLength = photoTransform.localScale.z;
        var ratio = texture.width / texture.height;
        photoTransform.localScale.Set(width, width/ratio, zLength);

        var frameTransform = newObj.transform.GetChild(1).transform;
        width = frameTransform.localScale.x;
        height = frameTransform.localScale.y;
        zLength = frameTransform.localScale.z;
        frameTransform.localScale.Set(width, width / ratio, zLength);

        //newObj.transform.GetChild(1).localScale //Frame

        //StartCoroutine(UploadTextureToMat(newPhotoMat));
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
