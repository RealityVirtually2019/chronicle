using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using DG.Tweening;

public class StickerController : MonoBehaviour {

    public MLImageTrackerBehavior imageTracker;
    public GameObject SpawnChronicle;
    public ParticleSystem previewSystem;
    private bool foundOnce = false;

	// Use this for initialization
	void Start () {
        imageTracker.OnTargetFound += OnTargetFound;
        SpawnChronicle.SetActive(false);
        previewSystem.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HandlePreviewIntersection(){
        previewSystem.Stop();
        SpawnChronicle.SetActive(true);
        Reveal();
        GetComponent<Collider>().enabled = false;
    }

    private void OnTargetFound(bool val){
        if(!foundOnce){
            foundOnce = true;
            previewSystem.Play();
            this.transform.position = imageTracker.transform.position;
            Reveal();
        }
    }

    public void Reveal(){

        foreach (Transform childTrans in SpawnChronicle.transform){
            
            var chronObj = childTrans.GetComponent<ChronicleObject>();
            chronObj.forceSaveRestTransform();
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
