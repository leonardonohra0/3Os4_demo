using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Button play_btn, settings_btn;
    public Canvas main_menu, settings, game;
    public Text instructions;

    public GameObject spawner;

	// Use this for initialization
	void Start () {
        play_btn.GetComponent<Button>().onClick.AddListener(() => Play());
        settings_btn.GetComponent<Button>().onClick.AddListener(() => Settings());

        settings.enabled = false;
        game.enabled = false;
        spawner.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
		
	}

    void Play()
    {
        spawner.SetActive(true);
        instructions.enabled = false;
        main_menu.enabled = false;
        game.enabled = true;
    }

    void Settings()
    {
        main_menu.enabled = false;
        settings.enabled = true;
    }
}
