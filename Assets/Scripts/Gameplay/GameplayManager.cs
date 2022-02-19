using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{

    public static GameplayManager Instance;
    public float speed;
    public int score = 0;
    public GameObject gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI pseudoText;
    public bool isGameOver = false;

    public string pseudo;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pseudo = SettingManager.Instance.playerPseudo;
        pseudoText.text = "Pseudo : " + pseudo;
        
        
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (score % 500 == 0)
        {
            if (speed < 30)
            {
                speed += 0.5f;
            }

            // Reduces the time interval between two obstacles
            if (SpawnerObstacleManager.Instance.minTime > 0.5f)
            {
                SpawnerObstacleManager.Instance.minTime -= 0.05f;
                
            }

            if (SpawnerObstacleManager.Instance.maxTime > 1f)
            {
                SpawnerObstacleManager.Instance.maxTime -= 0.05f;
            }
            
        }
       
        if (!isGameOver)
        {
            score += Mathf.CeilToInt(speed * Time.deltaTime/100);
            scoreText.text = "Score : " + score;
        }
        else
        {
            if (Input.anyKeyDown)
            {
                Restart();
            }
        }
    }
    /**
     * Function called when the player has lost
     */
    public void GameOver()
    {
        Time.timeScale = 0;
        StartCoroutine(SaveScore());
        isGameOver = true;
        gameOverText.SetActive(true);
    }
    /**
     * Function to restart a game
     */
    private  void Restart()
    {
        SceneManager.LoadScene(1);
        isGameOver = false;
        Time.timeScale = 1;
        speed = 10f;
        score = 0;
    }
    
    /**
     * Function communicating with the API to save the score
     */
     private IEnumerator SaveScore()
    {
        
        var form = new WWWForm();
        var today = DateTime.Today;
        form.AddField("score", score.ToString());
        form.AddField("pseudo", pseudo);
        
        using (UnityWebRequest www = UnityWebRequest.Post("https://api-scoreboard.nathangonzalez.fr/api/score", form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                // Ideally, I should have displayed an error message on the screen
                Debug.Log(www.error);
            }
            
        }

    }
}
