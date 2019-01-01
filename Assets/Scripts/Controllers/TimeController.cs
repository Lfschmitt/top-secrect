using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {

    public int totalDays;
    public bool avanceDay;
    public int avanceMoreDays;   
    public bool confirm;   
    public int limitiDays;
    public Text days;
    public InputField inputField;

    private bool send;
    private MoneyCollect moneyCollect;
    private float waitTime = 1;
    private AllPoints allpoints;

    void Start()
    {
        allpoints = GameObject.Find("PointsController").GetComponent<AllPoints>();    
        if(allpoints == null)
        {
            Debug.Log("The game object -PointsController- not find in scene");
        }

        moneyCollect = GameObject.Find("PointsController").GetComponent<MoneyCollect>();
        if (moneyCollect == null)
        {
            Debug.Log("The game object -PointsController- not find in scene");
        }
    }

    void Update () {
        if (totalDays + avanceMoreDays <= limitiDays)
        {
            if (avanceDay && totalDays < limitiDays)
            {
                moneyCollect.SendMoney(1);          
                totalDays++;
                allpoints.SavePoints("TotalDays", totalDays);
                avanceDay = !avanceDay;
            }
            else
            {
                avanceDay = false;
            }

            if (avanceMoreDays > 0 && confirm)
            {
                //moneyCollect.SendMoney(avanceMoreDays, true);
                StartCoroutine(ChangeDays());
            }
            else if (avanceMoreDays == 0)
            {
                confirm = false;
                send = true;
            }
        }
        else
        {
            avanceMoreDays = limitiDays - totalDays;
        }

        days.text = "Day " + totalDays.ToString();
    }

    IEnumerator ChangeDays()
    {
        while (avanceMoreDays > 0 && confirm)
        {
            confirm = true;
            if (send)
            {
                moneyCollect.SendMoney(avanceMoreDays);
                send = false;
            }
            totalDays++;
            avanceMoreDays--;
            allpoints.SavePoints("TotalDays", totalDays);
            inputField.text = avanceMoreDays.ToString();
            yield return new WaitForSeconds(waitTime);
        }       
    }

    public void AvanceDayClick()
    {
        avanceDay = true;
    }

    public void ConfirmClick()
    {
        confirm = true;
    }

    public void InputDays()
    {
        avanceMoreDays = int.Parse(inputField.text);
    }

    public void SetDays(int number)
    {
        totalDays = number;
        allpoints.SavePoints("TotalDays", totalDays);
    }
}
