using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    private bool taken = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!taken && other.gameObject.tag == "Player")
        {
            GlobalVar globalVar = GameObject.Find("GlobalVar").GetComponent<GlobalVar>();
            for (int i = 0; i < 6; i++)
            {
                globalVar.coolOfSkill[i] = 0;
            }
            other.transform.position = new Vector3(10f, 1.3f, -43f);
            text.text = "Zero Cooldown";
            Destroy(text, 3f);
            taken = true;
        }
    }
}
