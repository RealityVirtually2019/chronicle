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
        //firstOutlineWidth = outlineMat.GetFloat(" _FirstOutlineWidth");
        //secondOutlineWidth = outlineMat.GetFloat(" _SecondOutlineWidth");
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
}


