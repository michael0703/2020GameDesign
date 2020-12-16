using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class setHint : MonoBehaviour
{   
    public string hintMsg;
    GameObject tutorialBar;
    // Start is called before the first frame update
    void Start()
    {
        tutorialBar = GameObject.Find("/TutorialArea/exampleHint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            
            tutorialBar.GetComponent<TextMeshPro>().SetText(hintMsg);
            //Debug.Log("Show Hint Message  " + hintMsg);
        }
    }
    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){

            tutorialBar.GetComponent<TextMeshPro>().SetText("");
            //Debug.Log("Clear Message");
        }

    }
}
