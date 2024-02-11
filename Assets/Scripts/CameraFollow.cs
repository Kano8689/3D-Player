using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player,pivot;
    Vector3 offset;
    float rotateSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        offset = player.position - transform.position;
        pivot.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pivot.position = player.transform.position;
        float horizontal = Input.GetAxis("Mouse X")*rotateSpeed;
        float vertical= Input.GetAxis("Mouse Y")*rotateSpeed;
        //print(horizontal);
        pivot.Rotate(0,horizontal,0);
        pivot.Rotate(0,0,vertical);
        Quaternion rotation = Quaternion.Euler(0,pivot.rotation.eulerAngles.y,0);
        transform.position = player.position - (rotation * offset);
        transform.LookAt(player);
    }
}
