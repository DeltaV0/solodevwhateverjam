using UnityEngine;
using UnityEngine.UI;
using System.Collections;


using TMPro;

public class Notification : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text info;

    public string titleText;
    public string infoText;

    public GameObject nextNotif;

    public Button CloseButton;

    public bool canClose;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        StartCoroutine(openAnim());
        CloseButton.interactable = canClose;
        title.text = titleText;
        info.text = infoText;
    }

    public void Next()
    {
        if(nextNotif == null)
        {
            Close();
        }
    }

    public void Close()
    {
        //DebrisSpawner.DeleteLEOobjects(100, 0.1f);
        StartCoroutine(closeAnim());

    }

    public IEnumerator closeAnim()
    {
        for(int i = 0; i < 100; i++)
        {
            transform.localScale = new Vector3(transform.localScale.x * 0.9f, transform.localScale.y * 0.8f, 1);
            yield return new WaitForSecondsRealtime(0.01f);

        }
        Destroy(gameObject);

    }

    public IEnumerator openAnim()
    {
        transform.localScale = new Vector3(0f, 0.0f, 0.0f);
        for(int i = 0; i < 100; i++)
        {
            //Debug.Log(Mathf.Lerp(0.1f, transform.localScale.x, 1f));
            transform.localScale = new Vector3(Mathf.Lerp(transform.localScale.x, 1f, 0.1f), Mathf.Lerp(transform.localScale.y, 1f, 0.075f), 1);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        transform.localScale = new Vector3(1f, 1f, 1f);
        //Destroy(gameObject);

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
