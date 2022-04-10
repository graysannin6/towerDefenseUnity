using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static int Gold;
    public int startMoney = 400;
    public static int Lives;
    public int startLives = 20;

    public static int Rounds;


    // Start is called before the first frame update
    void Start()
    {
        Gold = startMoney;
        Lives = startLives;

        Rounds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
