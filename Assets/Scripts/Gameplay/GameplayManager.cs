using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{

    public static GameplayManager Instance;
    public float speed;
    public int score = 0;
    public GameObject gameOverText;
    public TextMeshProUGUI scoreText;
    public bool isGameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        speed = 25f;
    }

    // Update is called once per frame
    void Update()
    {

       
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

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        gameOverText.SetActive(true);
        
    }

    private  void Restart()
    {
        SceneManager.LoadScene(0);
        isGameOver = false;
        Time.timeScale = 1;
        score = 0;
    }
}
