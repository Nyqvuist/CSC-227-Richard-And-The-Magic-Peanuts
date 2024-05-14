using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeanutScript : MonoBehaviour
{

    float result;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On pick up, generates random number, dependant on number, a powerup is given.
        if (collision.gameObject.tag == "Richard")
        {
            result = Random.Range(1, 11);
            AudioSource audio = GetComponent<AudioSource>();
            PlayerController.OnUpgradeApply(result);
            Destroy(transform.parent.gameObject);
        }
    }
}
