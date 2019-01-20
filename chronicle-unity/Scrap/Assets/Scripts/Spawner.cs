using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spawner : MonoBehaviour {

    public ChronicleObject SelectedObject;
    public Transform Cursor;
    private GameObject cursorMesh;
    [HideInInspector]
    public bool isOccupied = false;

	// Use this for initialization
	void Start () {
        cursorMesh = Cursor.GetChild(0).gameObject;
        GameStateController.OnChronicleStateChanged.AddListener(setCursorToolTip);
        setCursorToolTip();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Spawns an object above the cursor
    public void Spawn(){
        
        SelectedObject.gameObject.SetActive(true);

        SelectedObject.transform.position = Cursor.position
            + Cursor.transform.up * 0.03f;
        SelectedObject.transform.LookAt(Camera.main.transform);
        SelectedObject.transform.localScale = Vector3.zero;
        SelectedObject.transform.DOScale(Vector3.one, 1f)
                   .SetEase(Ease.OutBack);

        //SelectedObject.transform.parent = Cursor;

        //isOccupied = true;
    }

    //Spawns an object above the cursor
    public void Spawn(ChronicleObject chronicleObject)
    {

        chronicleObject.gameObject.SetActive(true);

        chronicleObject.transform.position = Cursor.position
            + Cursor.transform.up * 0.03f;
        chronicleObject.transform.LookAt(Camera.main.transform);
        chronicleObject.transform.localScale = Vector3.zero;
        chronicleObject.transform.DOScale(Vector3.one, 1f)
                   .SetEase(Ease.OutBack);

        //SelectedObject.transform.parent = Cursor;

        //isOccupied = true;
    }

    public void Attach(ChronicleObject obj){

        SelectedObject = obj;
        SelectedObject.transform.parent = Cursor.transform;
        isOccupied = true;
        cursorMesh.SetActive(false);
    }

    public void Detach(){

        SelectedObject.transform.parent = null;
        isOccupied = false;
        cursorMesh.SetActive(true);
    }

    public void ResetOrientation(){

        SelectedObject.transform.DOLookAt(Camera.main.transform.position, 0.5f)
                   .SetEase(Ease.InCubic);
    }

    private void setCursorToolTip(){
        
        var cursorOutline = cursorMesh.GetComponent<OutlineController>();
        var cursorText = cursorMesh.GetComponentInChildren<TextMesh>();
        if(GameStateController.CurrentState == GameStateController.ChronicleState.Edit){
            cursorOutline.ShowOutline();
            cursorText.text = "Edit";
            cursorText.color = new Color(0f, 0f, 0f, 0f);
            DOTween.To(() => cursorText.color, x => cursorText.color = x, new Color(191f/255f, 120f/255f, 5f/255f, 1f), 1f)
                   .OnComplete(()=> { DOTween.To(() => cursorText.color, x => cursorText.color = x, new Color(191f/255f, 120f/255f, 5f/255f, 0f), 1f); });
        }else{
            cursorOutline.HideOutline();
            cursorText.text = "View";
            cursorText.color = new Color(0f, 0f, 0f, 0f);
            DOTween.To(() => cursorText.color, x => cursorText.color = x, new Color(99f/255f, 199f/255f, 207f/255f, 1f), 1f)
                   .OnComplete(() => { DOTween.To(() => cursorText.color, x => cursorText.color = x, new Color(99f/255f, 199f/255f, 207/255f, 0f), 1f); });
        }
    }


}
