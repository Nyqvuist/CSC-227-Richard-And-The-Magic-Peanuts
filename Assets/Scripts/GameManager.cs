using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    private float died;

    public static int count = 0;

    public static Action OnDeathUpdate;

    private void OnEnable()
    {
        
        OnDeathUpdate += increaseDeath;
    }

    private void OnDisable()
    {
        
        OnDeathUpdate -= increaseDeath;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Manager is up.");

        DontDestroyOnLoad(this.gameObject);
    }

    public void Awake()
    {

        
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void increaseDeath()
    {
        died++;
    }
}
