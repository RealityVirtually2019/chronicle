﻿using System.Collections;
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
        SelectedObject.gameObject.SetActive(false);
        cursorMesh = Cursor.GetChild(0).gameObject;
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

        isOccupied = true;
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

        isOccupied = true;
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


}
