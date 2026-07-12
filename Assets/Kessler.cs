using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections;


public class Kessler : MonoBehaviour
{
    public static Kessler me;
    public static List<GameObject> LEOobjects = new List<GameObject>();
    public static List<GameObject> MEOobjects = new List<GameObject>();

    public static List<GameObject> GEOobjects = new List<GameObject>();

    public static List<GameObject> Otherobjects = new List<GameObject>();

    public GameObject canvas;

    //public GameObject[] Notifications;

    public Economy economy;
    public Relations relations;

    public int Time;

    public TMP_Text date;

    public int totalDebris;

    public List<int> queue = new List<int>();

    public GameObject[] notifications;

    public bool lookingAtSomething;

    public List<int> previouslySeen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        me=this;
        for(int i = 0; i < notifications.Length; i++)
        {
            notifications[i].GetComponent<Notification>().ID = i;
        }
       // GameObject g = Instantiate(Notifications[0], Vector3.zero, Quaternion.identity);
      //  g.transform.SetParent(canvas.transform, false);
      queue.Add(0);
      NextMail();
      
    }

    // Update is called once per frame
    void Update()
    {
        totalDebris = LEOobjects.Count + MEOobjects.Count + GEOobjects.Count + Otherobjects.Count;
        UIStuff.me.buttons[0].interactable = queue.Count <= 0 && !lookingAtSomething;
        UIStuff.me.buttons[1].interactable = queue.Count > 0 && !lookingAtSomething;
        if(totalDebris < 100)
        {
            UIStuff.me.textBoxes[8].text = "Debris: Minimal";
        } else if(totalDebris < 300)
        {
            UIStuff.me.textBoxes[8].text = "Debris: Low";
        } else if(totalDebris < 750)
        {
            UIStuff.me.textBoxes[8].text = "Debris: Medium";
        } else if(totalDebris < 1250)
        {
            UIStuff.me.textBoxes[8].text = "Debris: High";
        } else
        {
            UIStuff.me.textBoxes[8].text = "Debris: Critical!";

        }
        UIStuff.me.textBoxes[13].text = "" + queue.Count;
        UIStuff.me.textBoxes[12].text = "Total: $" + economy.total + "b";
        UIStuff.me.textBoxes[11].text = "Surplus: $" + (economy.income - economy.spending) + "b";
        UIStuff.me.textBoxes[10].text = "Spending: $" + economy.spending + "b";
        UIStuff.me.textBoxes[9].text = "Income: $" + economy.income + "b";

        UIStuff.me.textBoxes[0].text = "Public: " + relations.totalReputation + " (" + relations.publicFeelings + "%)";

        UIStuff.me.textBoxes[1].text = "USA: " + relations.relations[0] + " (" + relations.relationsDelta[0] + "%)";
        UIStuff.me.textBoxes[2].text = "Russia: " + relations.relations[1] + " (" + relations.relationsDelta[1] + "%)";
        UIStuff.me.textBoxes[3].text = "China: " + relations.relations[2] + " (" + relations.relationsDelta[2] + "%)";
        UIStuff.me.textBoxes[4].text = "UK: " + relations.relations[3] + " (" + relations.relationsDelta[3] + "%)";
        UIStuff.me.textBoxes[5].text = "Poland: " + relations.relations[4] + " (" + relations.relationsDelta[4] + "%)";

        if(relations.chaos < 1)
        {
            UIStuff.me.textBoxes[6].text = "Chaos: Minimal";
            UIStuff.me.textBoxes[6].color = new Color(0.1f, 1, 0.1f);
        } else if(relations.chaos < 25)
        {
            UIStuff.me.textBoxes[6].text = "Chaos: Low";
            UIStuff.me.textBoxes[6].color = new Color(0.5f, 1f, 0.5f);
        } else if(relations.chaos < 50)
        {
            UIStuff.me.textBoxes[6].text = "Chaos: Medium";
            UIStuff.me.textBoxes[6].color = new Color(1, 1f, 1f);
        } else if(relations.chaos < 85)
        {
            UIStuff.me.textBoxes[6].text = "Chaos: High";
            UIStuff.me.textBoxes[6].color = new Color(1, 0.5f, 0.5f);
        } else
        {
            UIStuff.me.textBoxes[6].text = "Chaos: Critical!";
            UIStuff.me.textBoxes[6].color = new Color(1, 0.1f, 0.1f);
        }

        if(relations.marketStability < 15)
        {
            UIStuff.me.textBoxes[7].text = "Markets: Miserable!";
            UIStuff.me.textBoxes[7].color = new Color(1, 0.1f, 0.1f);

        } else if(relations.marketStability < 40)
        {
            UIStuff.me.textBoxes[7].text = "Markets: Bad";
            UIStuff.me.textBoxes[7].color = new Color(1, 0.5f, 0.5f);

        } else if(relations.marketStability < 60)
        {
            UIStuff.me.textBoxes[7].text = "Markets: Stable";
            UIStuff.me.textBoxes[7].color = new Color(1, 1f, 1f);

        } else if(relations.marketStability < 85)
        {
            UIStuff.me.textBoxes[7].text = "Markets: Good";
            UIStuff.me.textBoxes[7].color = new Color(0.5f, 1, 0.5f);
        } else
        {
            UIStuff.me.textBoxes[7].text = "Markets: Great!";
            UIStuff.me.textBoxes[7].color = new Color(0.1f, 1, 0.1f);
        }
            }

    IEnumerator TurnEnum()
    {
        Time++;
        date.text = "Q" + (Mathf.Repeat(Time, 4) + 1) + " " + (2035 + (int)(Time/4));
        yield return new WaitForSecondsRealtime(0.1f);

        DebrisSpawner.SpawnLEOobjects((int)(LEOobjects.Count * 0.15f), 0.01f);
        DebrisSpawner.SpawnMEOobjects((int)(MEOobjects.Count * 0.05f), 0.01f);
        DebrisSpawner.SpawnGEOobjects((int)(GEOobjects.Count * 0.25f), 0.01f);
        DebrisSpawner.SpawnOtherobjects((int)(Otherobjects.Count * 0.45f), 0.01f); 

        yield return new WaitForSecondsRealtime(0.5f);
        economy.updateStats();
        relations.updateRelations();   
        CalcMailQueue();
        previouslySeen.Concat(queue);
        yield return new WaitForSecondsRealtime(0.5f);
        NextMail();
        
    }

    public void CalcMailQueue()
    {
        
    }

    public void NextTurn()
    {
        //big!!
        queue.Clear();
        me.StartCoroutine(TurnEnum());

        


    }

    public void NextMail()
    {
        if(queue.Count > 0)
        {
            OpenMail(queue[0]);
            queue.RemoveAt(0);
        }
    }

    public void OpenMail(int i)
    {
        GameObject g = Instantiate(notifications[i], Vector3.zero, Quaternion.identity);
        g.transform.SetParent(canvas.transform, false); 
    }
}
