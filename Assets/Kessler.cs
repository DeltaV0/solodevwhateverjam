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

    public GameObject[] Notifications;

    public Economy economy;
    public Relations relations;

    public int Time;

    public TMP_Text date;

    public int totalDebris;

    public List<int> queue = new List<int>();

    public GameObject[] notifications;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        me=this;
       // GameObject g = Instantiate(Notifications[0], Vector3.zero, Quaternion.identity);
      //  g.transform.SetParent(canvas.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        totalDebris = LEOobjects.Count + MEOobjects.Count + GEOobjects.Count + Otherobjects.Count;
    }

    IEnumerator TurnEnum()
    {
        Time++;
        date.text = "Q" + (Mathf.Repeat(Time, 4) + 1) + " " + (2035 + (int)(Time/4));
        yield return new WaitForSecondsRealtime(0.1f);

        DebrisSpawner.SpawnLEOobjects((int)(LEOobjects.Count * 0.1f), 0.01f);
        DebrisSpawner.SpawnMEOobjects((int)(MEOobjects.Count * 0.05f), 0.01f);
        DebrisSpawner.SpawnGEOobjects((int)(GEOobjects.Count * 0.15f), 0.01f);
        DebrisSpawner.SpawnOtherobjects((int)(Otherobjects.Count * 0.25f), 0.01f);    
    }

    public void NextTurn()
    {
        //big!!
        me.StartCoroutine(TurnEnum());

        


    }

    public void NextMail()
    {
        if(queue.Count > 0)
        {
            
        }
    }
}
