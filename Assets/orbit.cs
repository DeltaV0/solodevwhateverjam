using UnityEngine;

public class orbit : MonoBehaviour
{

    //public float rot;

    public float smA;
    public float e;

    public float angle;

    public float offset;
    public float speed;

    //public float d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        angle = Random.Range(0f, 360f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float d = (smA * (1-Mathf.Pow(e, 2)))/(1+e*Mathf.Cos(angle));
        angle = angle + (1/(Mathf.Pow(d, 2))) * speed;

        transform.position = new Vector3(Mathf.Cos(angle + offset), Mathf.Sin(angle + offset), 0) * d;
    }

    public static float NextGaussianDouble()
{
    float u, v, S;

    do
    {
        u = 2.0f * Random.value - 1.0f;
        v = 2.0f * Random.value - 1.0f;
        S = u * u + v * v;
    }
    while (S >= 1.0);

    float fac = Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);
    return u * fac;
}

}
