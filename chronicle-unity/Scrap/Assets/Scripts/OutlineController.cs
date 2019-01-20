using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OutlineController : MonoBehaviour
{

    private Material outlineMat;
    private float firstOutlineWidth = 0.11f;
    private float secondOutlineWidth = 0.07f;
    private float speed = 0.25f;


    private void Awake()
    {
        outlineMat = GetComponent<Renderer>().material;
        firstOutlineWidth = outlineMat.GetFloat("_FirstOutlineWidth");
        secondOutlineWidth = outlineMat.GetFloat("_SecondOutlineWidth");
        GameStateController.OnChronicleStateChanged.AddListener(changeColor);
    }

    // Use this for initialization
    void Start()
    {

        HideOutline();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowOutline()
    {
        outlineMat.DOFloat(firstOutlineWidth, "_FirstOutlineWidth", speed);
        outlineMat.DOFloat(secondOutlineWidth, "_SecondOutlineWidth", speed);

        //outlineMat.SetFloat("_FirstOutlineWidth", firstOutlineWidth);
        //outlineMat.SetFloat("_SecondOutlineWidth", secondOutlineWidth);

    }

    public void HideOutline()
    {
        outlineMat.DOFloat(0f, "_FirstOutlineWidth", speed);
        outlineMat.DOFloat(0f, "_SecondOutlineWidth", speed);
        //outlineMat.SetFloat("_FirstOutlineWidth", 0f);
        //outlineMat.SetFloat("_SecondOutlineWidth", 0f);
    }

    public void ShowHoverOutline()
    {
        outlineMat.SetFloat("_FirstOutlineWidth", secondOutlineWidth);
        outlineMat.SetFloat("_SecondOutlineWidth", 0f);
    }

    private void changeColor(){
        if(GameStateController.CurrentState == GameStateController.ChronicleState.Edit){
            outlineMat.SetColor("_FirstOutlineColor", new Color(191f / 255f, 120f / 255f, 5f / 255f, 89f / 255f));
            outlineMat.SetColor("_SecondOutlineColor", new Color(191f / 255f, 120f / 255f, 5f / 255f, 1f));
        }else{
            outlineMat.SetColor("_FirstOutlineColor", new Color(99f / 255f, 199f / 255f, 207f / 255f, 89f/255f));
            outlineMat.SetColor("_SecondOutlineColor", new Color(99f / 255f, 199f / 255f, 207f / 255f, 1f));
        }
    }
}


