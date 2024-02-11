using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achieve_Generator : MonoBehaviour
{
    public GameObject Coin, dieCoin;
    public GameObject Parent;

    float[] posX1 = {81f, 72.80f, 55.10f, 66.80f, 69.70f, 69f, 55.15f, 68f};
    float[] posX2 = {87.5f, 81.90f, 83.20f, 72.50f, 72.50f, 72f, 64.15f, 73f};

    float[] posZ1 = {46f, 51.25f, 54.90f, 62.50f, 50f, 44f, 42.40f, 38.85f };
    float[] posZ2 = {48f, 53.9f, 55.60f, 64.70f, 55f, 50.50f, 45.15f, 34f };

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("CoinGenerator", 0f, 3f);
        InvokeRepeating("DieCoinGenerator", 3f, 5f);
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    void CoinGenerator()
    {
        int r = Random.Range(0, posX1.Length);

        float Px = Random.Range(posX1[r], posX2[r]);
        float y = 22.5f;
        float Pz = Random.Range(posZ1[r], posZ2[r]);

        Vector3 pos = new Vector3(Px, y, Pz);
        GameObject g = Instantiate(Coin, pos, Quaternion.Euler(90f, 0f, 0f));
    }
    void DieCoinGenerator()
    {
        int r = Random.Range(0, posX1.Length);

        float Px = Random.Range(posX1[r], posX2[r]);
        float y = 22.5f;
        float Pz = Random.Range(posZ1[r], posZ2[r]);

        Vector3 pos = new Vector3(Px, y, Pz);
        GameObject g = Instantiate(dieCoin, pos, Quaternion.Euler(90f, 0f, 0f));
    }
}
