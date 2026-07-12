using UnityEngine;
using System.Collections;


public class DebrisSpawner : MonoBehaviour
{
    public static DebrisSpawner me;
    public GameObject debrisPf;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        me=this;
        SpawnLEOobjects(50, 0.01f);
        SpawnMEOobjects(50, 0.01f);
        SpawnGEOobjects(50, 0.01f);
        SpawnOtherobjects(60, 0.01f);


    }

    public static IEnumerator SpawnLEOobjectsEnum(int q, float t)
    {
        for(int i = 0; i < q; i++)
        {
            GameObject g = Instantiate(me.debrisPf, Vector3.zero, Quaternion.identity);
            orbit O = g.GetComponent<orbit>();
            O.smA = Random.Range(0.65f, 1f);
            O.e = Random.Range(0f, 0.1f);
            O.offset = Random.Range(0f, 10f);
            O.speed = 0.01f;
            Kessler.LEOobjects.Add(g);
            yield return new WaitForSecondsRealtime(t);
        }
    }

    public static void SpawnLEOobjects(int q, float t)
    {
        me.StartCoroutine(SpawnLEOobjectsEnum(q, t));
    }

    public static IEnumerator SpawnMEOobjectsEnum(int q, float t)
    {
        for(int i = 0; i < q; i++)
        {
            GameObject g = Instantiate(me.debrisPf, Vector3.zero, Quaternion.identity);
            orbit O = g.GetComponent<orbit>();
            O.smA = 2f + (orbit.NextGaussianDouble() * 0.25f);
            O.e = Random.Range(0f, 0.1f);
            O.offset = Random.Range(0f, 10f);
            O.speed = 0.01f;
            Kessler.MEOobjects.Add(g);
            yield return new WaitForSecondsRealtime(t);
        }
    }

    public static void SpawnMEOobjects(int q, float t)
    {
        me.StartCoroutine(SpawnMEOobjectsEnum(q, t));
    }

    public static IEnumerator SpawnGEOobjectsEnum(int q, float t)
    {
        for(int i = 0; i < q; i++)
        {
            GameObject g = Instantiate(me.debrisPf, Vector3.zero, Quaternion.identity);
            orbit O = g.GetComponent<orbit>();
            O.smA = 3.5f + (orbit.NextGaussianDouble() * 0.25f);
            O.e = Random.Range(0f, 0f);
            O.offset = Random.Range(0f, 10f);
            O.speed = 0.01f;
            Kessler.GEOobjects.Add(g);
            yield return new WaitForSecondsRealtime(t);
        }
    }

    public static void SpawnGEOobjects(int q, float t)
    {
        me.StartCoroutine(SpawnGEOobjectsEnum(q, t));

    }

    public static IEnumerator SpawnOtherobjectsEnum(int q, float t)
    {
        for(int i = 0; i < q; i++)
        {
            GameObject g = Instantiate(me.debrisPf, Vector3.zero, Quaternion.identity);
            orbit O = g.GetComponent<orbit>();
            if(Mathf.Repeat(q, 3) == 0)
            {
                O.smA = Random.Range(1f, 2f);
            } else if(Mathf.Repeat(q, 3) == 1)
            {
                O.smA = Random.Range(2.25f, 3.5f);
            } else
            {
                O.smA = Random.Range(3.75f, 8f);

            }
            O.e = Random.Range(0f, 0f);
            O.offset = Random.Range(0f, 10f);
            O.speed = 0.01f;
            Kessler.GEOobjects.Add(g);
            yield return new WaitForSecondsRealtime(t);
        }
    }

    public static void SpawnOtherobjects(int q, float t)
    {
        me.StartCoroutine(SpawnOtherobjectsEnum(q, t));
    }

    public static IEnumerator DeleteLEOobjectsEnum(int q, float t)
    {
        //Kessler.LEOobjects = Kessler.LEOobjects.OrderBy( x => Random.value ).ToList( );
        for(int i = 0; i < q; i++)
        {
            Destroy(Kessler.LEOobjects[0]);
            Kessler.LEOobjects.RemoveAt(0);
            yield return new WaitForSecondsRealtime(t);
        }
    } 
    public static IEnumerator DeleteMEOobjectsEnum(int q, float t)
    {
        //Kessler.MEOobjects = Kessler.MEOobjects.OrderBy( x => Random.value ).ToList( );
        for(int i = 0; i < q; i++)
        {
            Destroy(Kessler.MEOobjects[0]);
            Kessler.MEOobjects.RemoveAt(0);
            yield return new WaitForSecondsRealtime(t);
        }
    } 
    public static IEnumerator DeleteGEOobjectsEnum(int q, float t)
    {
        //Kessler.GEOobjects = Kessler.GEOobjects.OrderBy( x => Random.value ).ToList( );
        for(int i = 0; i < q; i++)
        {
            Destroy(Kessler.GEOobjects[0]);
            Kessler.GEOobjects.RemoveAt(0);
            yield return new WaitForSecondsRealtime(t);
        }
    } 

    public static IEnumerator DeleteOtherobjectsEnum(int q, float t)
    {
       // Kessler.Otherobjects = Kessler.Otherobjects.OrderBy( x => Random.value ).ToList( );
        for(int i = 0; i < q; i++)
        {
            Destroy(Kessler.Otherobjects[0]);
            Kessler.Otherobjects.RemoveAt(0);
            yield return new WaitForSecondsRealtime(t);
        }
    } 

    public static void DeleteOtherobjects(int q, float t)
    {
        me.StartCoroutine(DeleteOtherobjectsEnum(q, t));
    }
    public static void DeleteLEOobjects(int q, float t)
    {
        me.StartCoroutine(DeleteLEOobjectsEnum(q, t));
    }
    public static void DeleteMEOobjects(int q, float t)
    {
        me.StartCoroutine(DeleteMEOobjectsEnum(q, t));
    }

    public static void DeleteGEOobjects(int q, float t)
    {
        me.StartCoroutine(DeleteGEOobjectsEnum(q, t));
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
