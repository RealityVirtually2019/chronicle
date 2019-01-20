using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChronicleObject : MonoBehaviour {

    public OutlineController outlineController;
    private Vector3 restPosition;
    private Quaternion restOrientation;


	private void Awake()
	{
	       GameStateController.OnChronicleStateChanged.AddListener(saveRestTransform);
	}


	public void ReturnToRest()
    {

        this.transform.DOMove(restPosition, 1f)
            .SetEase(Ease.OutBack);
        
        this.transform.DORotateQuaternion(restOrientation, 1f)
            .SetEase(Ease.OutBack);
    }
	
    private void saveRestTransform(){
        
        if(GameStateController.CurrentState 
           == GameStateController.ChronicleState.View){
            restPosition = this.transform.position;
            restOrientation = this.transform.rotation;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
