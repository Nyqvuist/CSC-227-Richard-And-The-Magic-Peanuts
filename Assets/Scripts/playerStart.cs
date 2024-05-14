using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStart : MonoBehaviour
{
    [SerializeField]
    private Vector3 playerStartPos;
    private GameObject player;


    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Richard");
        player.transform.position = playerStartPos;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
