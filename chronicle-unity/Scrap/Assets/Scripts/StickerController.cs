using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using DG.Tweening;

public class StickerController : MonoBehaviour {

    public MLImageTrackerBehavior imageTracker;
    public GameObject SpawnChronicle;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reveal(){

        foreach (Transform childTrans in SpawnChronicle.transform){
            
            var chronObj = childTrans.GetComponent<ChronicleObject>();
            childTrans.localScale = Vector3.zero;
            childTrans.DOScale(chronObj.restScale, 1f).SetEase(Ease.OutBounce);
        }
    }

    public void Hide(){

        foreach (Transform childTrans in SpawnChronicle.transform)
        {
            var chronObj = childTrans.GetComponent<ChronicleObject>();
            childTrans.DOScale(Vector3.zero, 1f).SetEase(Ease.InBack);
        }            

    }
}
