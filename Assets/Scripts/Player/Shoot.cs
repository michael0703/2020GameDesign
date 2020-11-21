using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //This class create bullet.
    public GameObject bulletPrefab;
    public float intervalOfShooting = 0.1f;
    public GameObject [] bulletPrefabSp;
    public float [] intervalOfShootingSp = {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f};
    
    public int currentSkillType = 0;

    private float timeCounting = 0;
    private float [] timeCountingSp = {0, 0, 0, 0, 0, 0};
    private int numOfSkillType;
    private float [] coolOfSkill;
    private float [] coolCounting = {0,0,0,0,0,0};

    private GameObject skillManager;
    private GameObject mainCamera;
    Animator animator;
    void Start()
    {
        numOfSkillType = GameObject.Find("GlobalVar").GetComponent<GlobalVar>().numOfSkillType;
        coolOfSkill = GameObject.Find("GlobalVar").GetComponent<GlobalVar>().coolOfSkill;
        skillManager = GameObject.Find("SkillManager");
        GameObject gun = transform.parent.gameObject;
        mainCamera = gun.transform.parent.gameObject;
        animator = gun.GetComponent<Animator>();
    }
    void Update()
    {
        timeCounting -= Time.deltaTime;
        for(int i=0; i<numOfSkillType; i++)
        {
            timeCountingSp[i] -= Time.deltaTime;
            coolCounting[i] -= Time.deltaTime;
        }

        // shoot special bullet
        if(Input.GetMouseButtonDown(1) && timeCountingSp[currentSkillType]<=0 && coolCounting[currentSkillType]<=0)
        {
            GameObject specialBullet = (GameObject)Instantiate(bulletPrefabSp[currentSkillType],transform.position,mainCamera.transform.rotation);
            bool isFull = skillManager.GetComponent<SkillManager>().RegistBullet(specialBullet);
            if(isFull) coolCounting[currentSkillType] = coolOfSkill[currentSkillType];
            timeCountingSp[currentSkillType] = intervalOfShootingSp[currentSkillType];
        }

        // shoot normal bullet
        if(Input.GetMouseButtonDown(0) && timeCounting<=0)
        {
            animator.Play("GunShoot_v1");
            Instantiate(bulletPrefab,transform.position,mainCamera.transform.rotation);
            timeCounting = intervalOfShooting;
        }

        // change currentSkillType
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.Play("BulletSwitch_v1");
            currentSkillType = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSkillType = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSkillType = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentSkillType = 3;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentSkillType = 4;
        }
        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            currentSkillType = 5;
        }
        
    }
}
