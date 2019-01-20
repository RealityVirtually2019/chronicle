using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PolyChronicleObjectCreator : MonoBehaviour {
    
    public ChronicleObject Create(string polyName)
    {
        GameObject polyObject = Instantiate(Resources.Load("Polys/"+polyName, typeof(GameObject))) as GameObject;
        return polyObject.GetComponent<ChronicleObject>();
    }

}
