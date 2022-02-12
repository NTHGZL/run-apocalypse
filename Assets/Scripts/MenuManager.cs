using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance; 
    public TMP_InputField input;
    public GameObject inputPanel;
    public GameObject menuPanel;
    public string pseudo;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        if (pseudo.Length == 0)
        {
            menuPanel.SetActive(false);
            inputPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Submit()
    {
        pseudo = input.text;
        SettingManager.Instance.playerPseudo = pseudo;
        menuPanel.SetActive(true);
        inputPanel.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
