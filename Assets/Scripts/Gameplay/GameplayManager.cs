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
     * Fonction appelée quand le joueur a perdu
     */
    public void GameOver()
    {
        StartCoroutine(SaveScore());
        
        isGameOver = true;
        Time.timeScale = 0;
        gameOverText.SetActive(true);
        
       
        
        // var res =  SaveScore("Nathan");
        // Debug.Log(res.GetType());
        

    }
    /**
     * Fonction permettant de recommencer une partie
     */
    private  void Restart()
    {
        SceneManager.LoadScene(1);
        isGameOver = false;
        Time.timeScale = 1;
        score = 0;
    }
    
    /**
     * Fonction permettant de sauvegarder le score en base de donnée
     */
     private IEnumerator SaveScore()
    {
        
        var form = new WWWForm();
        Debug.Log("Sauvegarde du score...");
        Debug.Log(score);
        var today = DateTime.Today;
        form.AddField("score", score.ToString());
        form.AddField("pseudo", pseudo);
        
        form.AddField("createdAt", DateTime.Today.ToString());
        
        using (UnityWebRequest www = UnityWebRequest.Post("https://api-scoreboard.nathangonzalez.fr/api/score", form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }

    }
}
