using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public GameObject homeObj;
    public GameObject Player;
    Looser looser;
    // Start is called before the first frame update
    void Start()
    {
        looser = GetComponent<Looser>();
        //looser.isPlay = false;
        homeObj.SetActive(true);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void onClickPlay()
    {
        //looser.isPlay = true;
        homeObj.SetActive(false);
    }
}
