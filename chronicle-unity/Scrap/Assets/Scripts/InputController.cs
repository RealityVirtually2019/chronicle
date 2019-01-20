using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

//Must be attached to the 'Cursor'
[RequireComponent(typeof(SphereCollider))]

public class InputController : MonoBehaviour {
    
    private MLInputController controller;
    public Transform Cursor;
    private Spawner spawner;
    private ChronicleObject objectHit = null;

    private bool isScaling, isGrabbing = false;
    private Vector3 initScalingTriggerPoint, initScale = Vector3.zero;

    void Awake()
    {
        MLInput.Start();
        MLInput.OnControllerButtonDown += OnButtonDown;
        MLInput.OnControllerButtonUp += OnButtonUp;

        controller = MLInput.GetController(MLInput.Hand.Left);
        spawner = this.GetComponent<Spawner>();

    }

    void OnDestroy()
    {
        MLInput.OnControllerButtonDown -= OnButtonDown;
        MLInput.OnControllerButtonUp -= OnButtonUp;
        MLInput.Stop();
    }

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        //HACK Change Gamestate
        if(Input.GetKeyDown(KeyCode.Space)){
            GameStateController.ToggleChronicleState();
        }

        //Update the cursor to follow our controller
        Cursor.position =
           controller.Position +
               controller.Orientation * Vector3.forward * 0.05f;

        Cursor.rotation = controller.Orientation;

        //Enable Grab on Trigger
        if(controller.TriggerValue > 0.8f && !isGrabbing
           && objectHit!= null){

            spawner.Attach(objectHit);
            isGrabbing = true;

            spawner.SelectedObject.outlineController.ShowOutline();

            if (GameStateController.CurrentState
                == GameStateController.ChronicleState.View)
            {
                //lets us play stuff in view mode
                spawner.SelectedObject.OnPickup.Invoke();
            }


        }

        //Detach Grabbed Object on Trigger Release
        if(controller.TriggerValue < 0.2f && isGrabbing){
            

            if (spawner.isOccupied){

                spawner.SelectedObject.outlineController.HideOutline();

                if (GameStateController.CurrentState
                    == GameStateController.ChronicleState.View)
                {
                    //Return Object to rest position
                    spawner.SelectedObject.ReturnToRest();
                    //lets us play stuff in view mode
                    spawner.SelectedObject.OnRelease.Invoke();
                }

                spawner.Detach();
                isGrabbing = false;
            }

        }


        if(isScaling){

            UpdateScaling();
        }

    }

    private void UpdateScaling(){

        float distanceToInitPoint = Vector3.Distance(initScalingTriggerPoint,
                                          Cursor.position);

        float maxScaleModifier = 3f;
        float maxDistance = 0.25f;

        spawner.SelectedObject.transform.localScale =
                     Vector3.Lerp(initScale, initScale * maxScaleModifier,
                         Mathf.Clamp01(distanceToInitPoint / maxDistance));

    }
    void OnButtonUp(byte controller_id, MLInputControllerButton button)
    {
        if (button == MLInputControllerButton.Bumper && isScaling)
        {

            isScaling = false;

        }
    }

    void OnButtonDown(byte controller_id, MLInputControllerButton button)
    {

        if(button == MLInputControllerButton.Bumper && !isScaling
           && objectHit != null && GameStateController.CurrentState 
           == GameStateController.ChronicleState.Edit){

                isScaling = true;
                initScalingTriggerPoint = spawner.SelectedObject.transform.position;
                initScale = objectHit.transform.localScale;
                if(spawner.isOccupied)
                    spawner.Detach();
        }


        //Reset the orientation if we press the menu button
        if(button == MLInputControllerButton.HomeTap && spawner.isOccupied)
        {
            spawner.ResetOrientation();
        }

        //Debug spawning
        if (button == MLInputControllerButton.HomeTap && !spawner.isOccupied)
        {
            //spawner.Spawn();
            GameStateController.ToggleChronicleState();
            //isGrabbing = true;
        }
    }

	private void OnTriggerEnter(Collider other)
	{
        objectHit = other.GetComponent<ChronicleObject>();

        if(objectHit!=null)
            objectHit.outlineController.ShowHoverOutline();
	}

	private void OnTriggerExit(Collider other)
	{
        if(objectHit != null)
            objectHit.outlineController.HideOutline();
        
        objectHit = null;

	}


}
