using UnityEngine;

public class Relations : MonoBehaviour
{
    public int totalReputation;
    public int publicFeelings;

    //nations: USA, Russia, China, UK, Poland
    //public int[,] nationalrelations = new int[5,5];

    public int[] relations = new int[5];
    public int[] relationsDelta = new int[5];

    public int chaos; //should stay near 0

    public int marketStability; //should stay near 50
    public int marketDelta;

    public bool active;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        transform.position = new Vector3(10f, 0, 0);
        chaos = 5 + Random.Range(-5, 5);
        marketStability = 60 + Random.Range(-25, 25);
        relations[0] = 50 + Random.Range(-25, 25);
        relations[1] = 50 + Random.Range(-25, 25);
        relations[2] = 50 + Random.Range(-25, 25);
        relations[3] = 50 + Random.Range(-25, 25);
        relations[4] = 50 + Random.Range(-25, 25);

        relationsDelta[0] = Random.Range(-2, 2);
        relationsDelta[1] = Random.Range(-2, 2);
        relationsDelta[2] = Random.Range(-2, 2);
        relationsDelta[3] = Random.Range(-2, 2);
        relationsDelta[4] = Random.Range(-2, 2);

        totalReputation = Random.Range(75, 95);
        publicFeelings = Random.Range(-2, 2);
        marketDelta = 1;
    }

    public void updateRelations()
    {
        chaos += (int)(((marketStability - 50) * 0.1f) + (Kessler.me.totalDebris * 0.01f)) + Random.Range(-3, 2 + (int)((marketStability - 50) * 0.1f));
        marketStability += marketDelta - (int)(chaos * 0.1f) - (int)(Kessler.me.totalDebris * 0.01f) + Random.Range(-3, 3);
        marketDelta += Random.Range(-3, 3);
        totalReputation += publicFeelings;
        if(totalReputation > 100)
        {
            totalReputation = 100;
        }

        for(int i = 0; i < relations.Length; i++)
        {
            relations[i] += relationsDelta[i];
            if(relations[i] > 100)
            {
                relations[i] = 100;
            } else if(relations[i] <= 0)
            {
                relations[i] = 0;
            }
        }

        for(int i = 0; i < relationsDelta.Length; i++)
        {
            relationsDelta[i] += Random.Range(-1, 1);
        }
        publicFeelings +=Random.Range(-1, 1);
    }

    void FixedUpdate()
    {
        if(active){
        transform.position = Vector3.Lerp(transform.position, Vector3.zero, 0.1f);
        }
    }
}
