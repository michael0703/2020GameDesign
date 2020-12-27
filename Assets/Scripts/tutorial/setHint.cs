using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class setHint : MonoBehaviour
{
    [TextArea]
    public string hintMsg;
    GameObject tutorialBar;
    // Start is called before the first frame update
    void Start()
    {
        tutorialBar = GameObject.Find("/Canvas/exampleHint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            
            tutorialBar.GetComponent<Text>().text=hintMsg;
            //Debug.Log("Show Hint Message  " + hintMsg);
        }
    }
    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){

            tutorialBar.GetComponent<Text>().text = "";
            //Debug.Log("Clear Message");
        }

    }
}
