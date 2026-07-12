using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


using TMPro;

public class Notification : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text info;

    public string titleText;
    public string infoText;

    //public int nextNotif;

    public Button CloseButton;

    public bool canClose;

    public int ID;

    //chaos, markets, happiness, nation relations(5,,,,,),  
    //public float[] req;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        StopAllCoroutines();
        StartCoroutine(openAnim());
        CloseButton.interactable = canClose;
        title.text = titleText;
        info.text = infoText;
    }

    public void OpenNotif(string i)
    {
        string[] s = i.Split('|');
        Debug.Log(s[0] + " and also " + s[1] + " " + float.Parse(s[1]));
            StartCoroutine(OpenThingy(Int32.Parse(s[0]), float.Parse(s[1])));
    }

    public IEnumerator OpenThingy(int i, float dur)
    {
        Close();
        yield return new WaitForSecondsRealtime(dur);
        Kessler.me.OpenMail(i);
    }

    public void BookMark()
    {
        Kessler.me.queue.Add(ID);
        Close();
    }

    public void Close()
    {
        //DebrisSpawner.DeleteLEOobjects(100, 0.1f);
        StopCoroutine(openAnim());
        StartCoroutine(closeAnim());
    }

   // public void 

    public IEnumerator closeAnim()
    {
        for(int i = 0; i < 100; i++)
        {
            transform.localScale = new Vector3(transform.localScale.x * 0.9f, transform.localScale.y * 0.8f, 1);
            yield return new WaitForSecondsRealtime(0.01f);

        }
        //yield return new WaitForSecondsRealtime(1f);
        Kessler.me.lookingAtSomething = false;
        Destroy(gameObject);

    }

    public IEnumerator openAnim()
    {
        Kessler.me.lookingAtSomething = true;
        transform.localScale = new Vector3(0f, 0.0f, 0.0f);
        for(int i = 0; i < 100; i++)
        {
            //Debug.Log(Mathf.Lerp(0.1f, transform.localScale.x, 1f));
            transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, 1f, 0.1f), Mathf.Lerp(transform.localScale.y, 1f, 0.075f), 1);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        Kessler.me.lookingAtSomething = true;
        transform.localScale = new Vector3(1f, 1f, 1f);
        //Destroy(gameObject);

    }
    //BELOW THIS IS NOTIF SPECIFIFC htignss
    public void ActivateUIFunction(int i)
    {
        if(i == 0)
        {
           Kessler.me.economy.active = true;

        } else
        {
            Kessler.me.relations.active = true;
        }
    }



}
