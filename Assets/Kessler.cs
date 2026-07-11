using UnityEngine;
using System.Collections.Generic;

public class Kessler : MonoBehaviour
{
    public static List<GameObject> LEOobjects = new List<GameObject>();
    public static List<GameObject> MEOobjects = new List<GameObject>();

    public static List<GameObject> GEOobjects = new List<GameObject>();

    public static List<GameObject> Otherobjects = new List<GameObject>();

    public GameObject canvas;

    public GameObject[] Notifications;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject g = Instantiate(Notifications[0], Vector3.zero, Quaternion.identity);
        g.transform.SetParent(canvas.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
