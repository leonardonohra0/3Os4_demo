using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public Button pause_btn, restart_btn;
    public Text score_txt;
    public Text gameover_txt;
    public Text instructions;
    public GameObject[] lives;

    public GameObject[] birds;

    public bool is_paused, is_over;
    public int score;
    public int life;

	// Use this for initialization
	void Start () {
        is_paused = false;
        is_over = false;
        score = 0;
        life = 3;
        score_txt.text = "Score: " + score;
        gameover_txt.enabled = false;
        restart_btn.gameObject.SetActive(false);
        pause_btn.GetComponent<Button>().onClick.AddListener(() => Pause());
        restart_btn.GetComponent<Button>().onClick.AddListener(() => Restart());
        lives = GameObject.FindGameObjectsWithTag("life");

        foreach(GameObject live in lives)
        {
            live.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/heart");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    void Pause()
    {
        if (!is_paused)
        {
            pause_btn.GetComponentInChildren<Text>().text = "Resume";
            Time.timeScale = 0;
            restart_btn.gameObject.SetActive(true);
            is_paused = true;
        } else
        {
            pause_btn.GetComponentInChildren<Text>().text = "Pause";
            Time.timeScale = 1;
            restart_btn.gameObject.SetActive(false);
            is_paused = false;
        }
    }

    public void Restart()
    {
        score = 0;
        score_txt.text = "Score: " + 0;
        life = 3;
        is_over = false;

        birds = GameObject.FindGameObjectsWithTag("bird");
        foreach (GameObject bird in birds)
        {
            Destroy(bird);
        }

        foreach(GameObject life in lives)
        {
            life.GetComponent<Image>().enabled = true;
        }
        Time.timeScale = 1;
        gameover_txt.enabled = false;
        instructions.enabled = true;
        pause_btn.enabled = true;
        is_paused = true;
        Pause();
        restart_btn.gameObject.SetActive(false);

    }

    public void hitBomb()
    {
        life -= 1;
        lives[life].GetComponent<Image>().enabled = false;
    }
}
