using UnityEngine;

public class Relations : MonoBehaviour
{
    public int totalReputation;
    public int publicFeelings;

    //nations: USA, Russia, China, UK, Poland
    public int[,] nationalrelations = new int[5,5];

    public int[] relations = new int[5];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void updateRelations()
    {
        totalReputation += publicFeelings;
        if(totalReputation > 100)
        {
            totalReputation = 100;
        }
    }

    void FixedUpdate()
    {
        
    }
}
