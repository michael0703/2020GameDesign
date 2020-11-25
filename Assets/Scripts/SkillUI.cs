using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{

    public Shoot shoot;
    int lastSkillType=0;
    float lastYPosition = 0;
    public GameObject[] skills;

    public GlobalVar globalVar;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = skills[lastSkillType].GetComponent<RectTransform>().anchoredPosition;
        lastYPosition=position.y;
        position.y += 1f/50*Screen.height;
        skills[lastSkillType].GetComponent<RectTransform>().anchoredPosition = position;
    }

    // Update is called once per frame
    void Update()
    {
        int currentSkillType = shoot.currentSkillType;
        //Debug.Log(lastSkillType +" "+currentSkillType);

        if (lastSkillType != currentSkillType)
        {
            //move back
            Vector3 position = skills[lastSkillType].GetComponent<RectTransform>().anchoredPosition;
            position.y = lastYPosition;
            skills[lastSkillType].GetComponent<RectTransform>().anchoredPosition = position;

            //move new skill out.
            lastSkillType = currentSkillType;
            position = skills[lastSkillType].GetComponent<RectTransform>().anchoredPosition;
            lastYPosition = position.y;
            position.y += 1f / 50 * Screen.height;
            skills[lastSkillType].GetComponent<RectTransform>().anchoredPosition = position;

        }

        for (int i = 0; i < globalVar.numOfSkillType; i++)
        {


            skills[i].transform.GetChild(1).gameObject.GetComponent<Image>().fillAmount = (globalVar.coolOfSkill[i] - shoot.coolCounting[i]) / globalVar.coolOfSkill[i];
            skills[i].transform.GetChild(2).GetComponent<Text>().text = shoot.coolCounting[i] <= 0 ? "" : shoot.coolCounting[i].ToString("0.0");



        }
    }
}
