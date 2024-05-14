using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private Transform spawnLocation;

    public static Action OnThrow;

    private void OnEnable()
    {

        OnThrow += Throw;
    }

    private void OnDisable()
    {

        OnThrow -= Throw;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Throw(){

        Instantiate(prefab, spawnLocation.position, Quaternion.identity);
}
    
}
