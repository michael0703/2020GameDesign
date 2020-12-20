using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 startAngle = Vector3.zero;
    public Vector3 endAngle = Vector3.zero;
    public Vector3 startPosition;
    public Vector3 endPosition;
    float counter = 3f;
    public float looptime;
    public float smoothEffect = 0.02f;
    public float movingEffect = 0.05f;
    void Start()
    {
        transform.rotation = Quaternion.Euler(startAngle.x, startAngle.y, startAngle.z);
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
        counter = looptime;
    }

    // Update is called once per frame
    void Update()
    {   
        Quaternion target = Quaternion.Euler(endAngle.x, endAngle.y, endAngle.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, smoothEffect);

        Vector3 Pos = Vector3.Slerp(transform.position, endPosition, movingEffect);
        transform.position = new Vector3(Pos.x, Pos.y, Pos.z);

        counter -= Time.deltaTime;
        if (counter <= 0f){
            counter = looptime;
            transform.rotation = Quaternion.Euler(startAngle.x, startAngle.y, startAngle.z);     
            transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z); 
        }

    }
}
