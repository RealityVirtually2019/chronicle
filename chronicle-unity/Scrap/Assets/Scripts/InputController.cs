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
    private GameObject objectHit = null;

    private bool isScaling = false;
    private Vector3 initScalingTriggerPoint, initScale = Vector3.zero;

    void Awake()
    {
        MLInput.Start();
        MLInput.OnControllerButtonDown += OnButtonDown;

        controller = MLInput.GetController(MLInput.Hand.Left);
        spawner = this.GetComponent<Spawner>();

    }

    void OnDestroy()
    {
        MLInput.OnControllerButtonDown -= OnButtonDown;
        MLInput.Stop();
    }

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        //Update the cursor to follow our controller
        Cursor.position =
           controller.Position +
               controller.Orientation * Vector3.forward * 0.05f;

        Cursor.rotation = controller.Orientation;

        //Init the scaling process when trigger is pressed
        if(controller.TriggerValue > 0.8f 
           && !isScaling && spawner.isOccupied){

            isScaling = true;
            initScalingTriggerPoint = Cursor.position;
            initScale = objectHit.transform.localScale;
            spawner.Detach();

        }

        //Disable the scaling process when trigger is released
        if(controller.TriggerValue < 0.2f && isScaling){
            
            isScaling = false;
            spawner.Attach(spawner.SelectedObject);
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


    void OnButtonDown(byte controller_id, MLInputControllerButton button)
    {

        if ((button == MLInputControllerButton.Bumper))
        {
            if (spawner.isOccupied)
            {
                spawner.Detach();
            }
            else{
                
                spawner.Attach(objectHit);
            }
        }


        //Reset the orientation if we press the menu button
        if(button == MLInputControllerButton.HomeTap && spawner.isOccupied)
        {
            spawner.ResetOrientation();
        }

        //Debug spawning
        if (button == MLInputControllerButton.HomeTap && !spawner.isOccupied)
        {
            spawner.Spawn();
        }
    }

	private void OnTriggerEnter(Collider other)
	{
        objectHit = other.gameObject;
	}

	private void OnTriggerExit(Collider other)
	{
        objectHit = null;
	}


}
