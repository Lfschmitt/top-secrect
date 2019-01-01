using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public bool tycoon1, tycoon2, tycoon3, tycoon4;
    public int Tycoon1, Tycoon2, Tycoon3, Tycoon4;
    private MoneyCollect moneyCollect;

    private void Start()
    {
        moneyCollect = GetComponent<MoneyCollect>();
    }

    void Update () {
        if (tycoon1)
        {
            moneyCollect.ReciveMoney(0, Tycoon1);
            tycoon1 = !tycoon1;
        }
        else if (tycoon2)
        {
            moneyCollect.ReciveMoney(1, Tycoon2);
            tycoon2 = !tycoon2;
        }
        else if(tycoon3)
        {
            moneyCollect.ReciveMoney(2, Tycoon3);
            tycoon3 = !tycoon3;
        }
        else if(tycoon4)
        {
            moneyCollect.ReciveMoney(3, Tycoon4);
            tycoon4 = !tycoon4;
        }

    }
}
