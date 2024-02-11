using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Manager : MonoBehaviour
{
    public GameObject Player;
    public GameObject ImgBG;
    public GameObject JoyStick;
    int mode;
    // Start is called before the first frame update
    void Start()
    {
        JoyStick.SetActive(false);
        ImgBG.SetActive(false);
        mode = PlayerPrefs.GetInt("MODE",1);
        if(mode == 1)
        {
            Player.GetComponent<Players>().enabled = true;
            Player.GetComponent<Players1>().enabled = false;
            JoyStick.SetActive(true);
        }
        else
        {
            Player.GetComponent<Players1>().enabled = true;
            Player.GetComponent<Players>().enabled = false;
            JoyStick.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSettingClick()
    {
        ImgBG.SetActive(true);
    }

    public void onJoystickClick()
    {
        Player.GetComponent<Players>().enabled = true;
        Player.GetComponent<Players1>().enabled = false;
        ImgBG.SetActive(false);
        mode = 1;
        PlayerPrefs.SetInt("MODE", 1);
        JoyStick.SetActive(true);
    }

    public void onkeyboardClick()
    {
        Player.GetComponent<Players1>().enabled = true;
        Player.GetComponent<Players>().enabled = false;
        ImgBG.SetActive(false);
        mode = 2;
        PlayerPrefs.SetInt("MODE", 2);
        JoyStick.SetActive(false);
    }
}
