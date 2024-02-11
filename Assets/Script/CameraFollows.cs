using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform Player, Pivot;
    Vector3 offset;
    float rotateSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        offset = Player.position - transform.position;
        Pivot.position = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Pivot.position = Player.transform.position;
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        Debug.Log(horizontal);
        Pivot.Rotate(0, -horizontal, 0);
        Quaternion rotation = Quaternion.Euler(0, Pivot.rotation.eulerAngles.y, 0);
        transform.position = Player.position - (rotation * offset);
        transform.LookAt(Player);
    }
}
