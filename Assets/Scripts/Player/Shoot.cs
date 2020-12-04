using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //This class create bullet.
    public GameObject bulletPrefab;
    public float intervalOfShooting = 0.3f;
    public GameObject [] bulletPrefabSp;
    public float [] intervalOfShootingSp = {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f};
    public AudioClip bulletAudio;
    public AudioClip [] bulletAudioSp;
    public GameObject shootHintPrefab;
    public GameObject shootHint;
    public int [] hintForward = {0, 8, 10, 0, 0, 0};
    public int hintIndex;
    public int currentSkillType = 0;
    
    public GameObject fireVFXPrefab;
    private ParticleSystem fireVFX;

    private float timeCounting = 0;
    private float [] timeCountingSp = {0, 0, 0, 0, 0, 0};
    private int numOfSkillType;
    private float [] coolOfSkill;
    public float [] coolCounting = {0,0,0,0,0,0};
    private AudioSource audioSource;

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
        fireVFX = fireVFXPrefab.GetComponent<ParticleSystem>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void ShowShootingHint(int index){
        hintIndex = index;
        float checkInterval = 100f;
        Vector3 gunForward = mainCamera.transform.forward;
        Vector3 initVelocity = gunForward * hintForward[index];
        Vector3 initPos = transform.position;
        Vector3 hintPos = Vector3.zero;
        Debug.Log("Index: " + "   " + index);
        Debug.Log("hintForward: "+ "   " + hintForward[index]);
        Debug.Log("Fake Velocity" + "   " + initVelocity);
        Debug.Log("Fake Pos" + "  " + initPos);
        int timeInterval = 3;
        // simulate bullet shoot, and make prefab;
        for(int i=1; i < 200; i+=2){

            float fakeDeltaTime = (float)timeInterval / checkInterval;
            initVelocity.y -= 9.8f * fakeDeltaTime; 
            initPos += initVelocity * fakeDeltaTime;
            Debug.Log("PosPos" + "   " + initPos);
            if (initPos.y <= 0.2){
                hintPos = new Vector3(initPos.x, 0f, initPos.z);
                break;
            }
        }
        Debug.Log("Hint Pos" + "   " + hintPos);
        shootHint = (GameObject)Instantiate(shootHintPrefab,hintPos,Quaternion.identity);
        shootHint.transform.parent = transform;
    }
    void DestroyShootingHint(){
        if (shootHint){
            Object.Destroy(shootHint);
        }
    }

    void Update()
    {   
        if (shootHint){
            DestroyShootingHint();
            ShowShootingHint(hintIndex);
        }
        timeCounting -= Time.deltaTime;
        for(int i=0; i<numOfSkillType; i++)
        {
            timeCountingSp[i] -= Time.deltaTime;
            coolCounting[i] -= Time.deltaTime;
        }

        // shoot special bullet
        if(Input.GetMouseButtonDown(1) && timeCountingSp[currentSkillType]<=0 && coolCounting[currentSkillType]<=0)
        {
            int layerMask = 1 << 8 | 1 << 9;    
            RaycastHit hit;
            Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, Mathf.Infinity, layerMask);
            Vector3 bulletFoward = hit.point - transform.position;


            animator.Play("GunShoot_v1");
            GameObject specialBullet = (GameObject)Instantiate(bulletPrefabSp[currentSkillType],transform.position,mainCamera.transform.rotation);
            specialBullet.transform.forward = bulletFoward;
            bool isFull = skillManager.GetComponent<SkillManager>().RegistBullet(specialBullet);
            if(isFull) coolCounting[currentSkillType] = coolOfSkill[currentSkillType];
            timeCountingSp[currentSkillType] = intervalOfShootingSp[currentSkillType];
            fireVFX.Play();
            audioSource.PlayOneShot(bulletAudioSp[currentSkillType]);
        }

        // shoot normal bullet
        if(Input.GetMouseButtonDown(0) && timeCounting<=0)
        {   
            
            int layerMask = 1 << 8 | 1 << 9;
            RaycastHit hit;
            Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, Mathf.Infinity, layerMask);
            Vector3 bulletFoward = hit.point - transform.position;

            
            animator.Play("GunShoot_v1");
            GameObject bullet = Instantiate(bulletPrefab,transform.position,mainCamera.transform.rotation);
            bullet.transform.forward = bulletFoward;
            timeCounting = intervalOfShooting;
            fireVFX.Play();
            audioSource.PlayOneShot(bulletAudio);
        }

        // change currentSkillType
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            DestroyShootingHint();
            animator.Play("BulletSwitch_v1");
            currentSkillType = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {   
            DestroyShootingHint();
            ShowShootingHint(1);
            animator.Play("BulletSwitch_v1");
            currentSkillType = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {   
            DestroyShootingHint();
            ShowShootingHint(2);
            animator.Play("BulletSwitch_v1");
            currentSkillType = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {   
            DestroyShootingHint();
            animator.Play("BulletSwitch_v1");
            currentSkillType = 3;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            DestroyShootingHint();
            animator.Play("BulletSwitch_v1");
            currentSkillType = 4;
        }
        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            DestroyShootingHint();
            animator.Play("BulletSwitch_v1");
            currentSkillType = 5;
        }
        
    }
}
