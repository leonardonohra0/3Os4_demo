using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

    public Slider audio_slider;
    public Button back_btn;
    public Canvas main_menu, settings;

    // Use this for initialization
    void Start () {
        audio_slider.value = 1.0f;
        back_btn.GetComponent<Button>().onClick.AddListener(() => Back());
    }

    // Update is called once per frame
    void Update () {
        AudioListener.volume = audio_slider.value;
	}

    public void Back()
    {
        main_menu.enabled = true;
        settings.enabled = false;
    }
}
