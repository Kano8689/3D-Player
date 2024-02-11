using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject lsrObj;
    public GameObject Coin, dangerCoin, Parent;
    public Text ScoreBoard;
    CharacterController controller;
    Vector3 movement;
    float speed = 10f;
    Animator animator;
    public int score = 0;
    Looser looser;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        looser = GetComponent<Looser>();

        //if (looser.isPlay)
        {
            InvokeRepeating("coinGenerator", 1f, 3f);
            InvokeRepeating("dangerCoinGenerator", 5f, 10f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal")*speed, 0, Input.GetAxis("Vertical")*speed);
        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal"))) + (Input.GetAxis("Vertical")));
        controller.Move(movement*Time.deltaTime);
        
        ScoreBoard.text = score.ToString();
        PlayerPrefs.SetInt("SCORE", score);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag=="coin")
        {
            Destroy(hit.gameObject);
            score++;
        }
        if(hit.gameObject.tag=="dangerCoin")
        {
            lsrObj.SetActive(true);
        }
    }

    void coinGenerator()
    {
        float x = Random.RandomRange(45, -45);
        float y = 0.5f;
        float z = Random.RandomRange(45, -45);
        Vector3 pos = new Vector3(x,y,z);
        //Parent.transform.position = pos;
        GameObject g = Instantiate(Coin, pos, Quaternion.Euler(90f, 0f, 0f));
    }
    void dangerCoinGenerator()
    {
        float x = Random.RandomRange(45, -45);
        float y = 0.5f;
        float z = Random.RandomRange(45, -45);
        Vector3 pos = new Vector3(x, y, z);
        //Parent.transform.position = pos;
        Instantiate(dangerCoin, pos, Quaternion.Euler(90f, 0f, 0f));
    }
}
