using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class PlayAudio : MonoBehaviour {
    private AudioSource audioSource;

    public void FadeIn(){
        audioSource.DOKill();
        audioSource.Play();
        audioSource.DOFade(1f, 1f).SetEase(Ease.InSine);
                  
    }

    public void FadeOut(){
        audioSource.DOKill();
        audioSource.DOFade(0f, 4f).SetEase(Ease.OutSine)
                   .OnComplete(() => { audioSource.Stop(); });
    }

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
