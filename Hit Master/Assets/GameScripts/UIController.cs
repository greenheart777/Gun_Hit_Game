using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIController : MonoBehaviour
{
    public Image playBtn;
    public Canvas menu;
    public AudioSource audio;
    public AudioClip Click;
    public AudioMixerSnapshot mixrInGame;
    public AudioMixerSnapshot mixrInMenu;


    void Start()
    {
        audio = GetComponent<AudioSource>();
        if(WaypointController.inGame == false)
        {
            menu.gameObject.SetActive(true);
        } else
        {
            menu.gameObject.SetActive(false);
        }
    }

    public void playButtonDown()
    {
        playBtn.rectTransform.sizeDelta = new Vector2(670, 370);
    }

    public void playButtonUp()
    {
        Handheld.Vibrate();
        playBtn.rectTransform.sizeDelta = new Vector2(700, 400);
        menu.gameObject.SetActive(false);
        audio.PlayOneShot(Click);
        WaypointController.inGame = true;
        mixrInGame.TransitionTo(1.0f);
    }
}
