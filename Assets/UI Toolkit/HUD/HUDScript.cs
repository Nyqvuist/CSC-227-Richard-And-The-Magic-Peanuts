using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class HUDScript : MonoBehaviour
{

    [SerializeField]
    private UIDocument document;
    private Label countText;

    // Start is called before the first frame update
    void Start()
    {
        var root = document.rootVisualElement;
        countText = root.Q<Label>("PeanutCount");
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = "x" + GameManager.count;
    }

    
}
