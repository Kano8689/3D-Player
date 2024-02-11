using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Looser : MonoBehaviour
{
    public GameObject Player;
    public GameObject lsrObj;
    public Text ScoreBox;
    Player player;
    public bool isPlay = false;
    SceneManager sceneManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        int score = PlayerPrefs.GetInt("SCORE", 0);
        ScoreBox.text = "Your Score = "+score;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void onClickReplay()
    {
        //isPlay = true;
        lsrObj.SetActive(false);
        SceneManager.LoadScene("Play");
    }
}
