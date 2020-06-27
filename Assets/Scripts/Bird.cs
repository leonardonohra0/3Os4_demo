using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour {

    public float speed = 5.0f;
    public int difficulty, hits;
    public bool go_right;
    public bool is_over;

    public Canvas game;

    // Use this for initialization
    void Start () {
        hits = 0;
        difficulty = Random.Range(0, 3);
        SetDifficulty();
        if (this.transform.position.x == -20)
            go_right = true;
        else
            go_right = false;

        is_over = false;

        game = GameObject.FindGameObjectWithTag("game").GetComponent<Canvas>(); ;
        this.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0);

    }

    // Update is called once per frame
    void Update () {
        if (go_right)
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        } else
        {
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        Vector2 touchPos = new Vector2(worldPoint.x, worldPoint.y);

        if (Input.GetMouseButtonUp(0) && !game.GetComponent<Game>().is_over)
        {
            //Debug.Log("Transform" + gameObject.transform.position.x + "TOUCH POS" + touchPos.x);

            float x_diff = gameObject.transform.position.x - touchPos.x;
            float y_diff = gameObject.transform.position.y - touchPos.y;

            if (x_diff <= 1.5f && x_diff >= -1.5f && y_diff <= 1.5f && y_diff >= -1.5f)
            {
                IncrementHits();
                Debug.Log("TOUCHDOWN");
            }


        }
        StartCoroutine(OnDestroyed());
    }

    void SetDifficulty()
    {
        switch (difficulty)
        {
            case 0:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/bird_brown");
                
                break;
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/bird_cap");
                speed *= 2.5f;


                break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/bomb");
                speed *= 2;
                break;
                default: break;
        }
    }

    void IncrementHits()
    {
        hits += 1;
        switch (difficulty)
        {
            case 0:
                if (hits >= 1)
                {
                    updateScore(10);
                    Destroy(this.gameObject);
                    Debug.Log("DESTROY");
                }
                break;
            case 1:
                if (hits >= 2)
                {
                    updateScore(30);
                    Destroy(this.gameObject);
                }
                break;
            case 2:
                if (hits >= 1)
                {
                    game.GetComponent<Game>().hitBomb();
                    Destroy(this.gameObject);
                    if (game.GetComponent<Game>().life <= 0)
                    {
                        GameOver();
                    }
                }
                break;
            default: break;
        }
    }

    void updateScore(int score)
    {
        game.GetComponent<Game>().score += score;
        game.GetComponent<Game>().score_txt.text = "Score: " + game.GetComponent<Game>().score;
    }

    private IEnumerator OnDestroyed()
    {
        yield return new WaitForSeconds(8.5f);
        Destroy(gameObject);
        Debug.Log("DESTROY CALLED");
    }

    void GameOver()
    {
        game.GetComponent<Game>().is_over = true;
        game.GetComponent<Game>().gameover_txt.enabled = true;
        game.GetComponent<Game>().pause_btn.enabled = false;
        game.GetComponent<Game>().restart_btn.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
