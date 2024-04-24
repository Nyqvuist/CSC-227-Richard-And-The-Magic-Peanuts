using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    private float points;

    private float died;

    public static Action<float> OnPointsUpdate;
    public static Action OnDeathUpdate;

    private void OnEnable()
    {
        OnPointsUpdate += increasePoints;
        OnDeathUpdate += increaseDeath;
    }

    private void OnDisable()
    {
        OnPointsUpdate -= increasePoints;
        OnDeathUpdate -= increaseDeath;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Manager is up.");
    }

    public void Awake()
    {

        
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void increasePoints(float p) {

        points += p;
    
    }

    private void increaseDeath()
    {
        died++;
    }
}
