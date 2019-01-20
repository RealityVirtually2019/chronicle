using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using PolyToolkit;


public class PolyChronicleObjectCreator : MonoBehaviour {


 //   public void Create(string assetID){
 //       PolyApi.GetAsset("assets/5vbJ5vildOq", GetAssetCallback);
 //   }

 //   // Callback invoked when the featured assets results are returned.
 //   private void GetAssetCallback(PolyStatusOr<PolyAsset> result)
 //   {
 //       if (!result.Ok)
 //       {
 //           Debug.LogError("Failed to get assets. Reason: " + result.Status);
 //           return;
 //       }

 //       Debug.Log("Successfully got asset!");

 //       // Set the import options.
 //       PolyImportOptions options = PolyImportOptions.Default();
 //       // We want to rescale the imported mesh to a specific size.
 //       options.rescalingMode = PolyImportOptions.RescalingMode.FIT;
 //       // The specific size we want assets rescaled to (fit in a 5x5x5 box):
 //       options.desiredSize = 5.0f;
 //       // We want the imported assets to be recentered such that their centroid coincides with the origin:
 //       options.recenter = true;

 //       PolyApi.Import(result.Value, options, ImportAssetCallback);
 //   }

 //   // Callback invoked when an asset has just been imported.
 //   private void ImportAssetCallback(PolyAsset asset, PolyStatusOr<PolyImportResult> result)
 //   {
 //       if (!result.Ok)
 //       {
 //           Debug.LogError("Failed to import asset. :( Reason: " + result.Status);
 //           return;
 //       }
 //       Debug.Log("Successfully imported asset!");

 //       // Show attribution (asset title and author).
 //       // Here, you would place your object where you want it in your scene, and add any
 //       // behaviors to it as needed by your app. As an example, let's just make it
 //       // slowly rotate:
 //       result.Value.gameObject.AddComponent<Rotate>();
 //   }

	//// Use this for initialization
	//void Start () {
		
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}
}
