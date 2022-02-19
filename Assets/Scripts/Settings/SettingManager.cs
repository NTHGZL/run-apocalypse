using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance;
    public string playerPseudo;

    private void Awake()
    {
        Instance = this;
        // Saves the nickname in the next scene
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
