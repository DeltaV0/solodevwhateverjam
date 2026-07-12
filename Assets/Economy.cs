using UnityEngine;

public class Economy : MonoBehaviour
{
    public bool active;

    public float income;

    public float spending;
    public float total;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
      transform.position = new Vector3(-10f, 0, 0);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(active){
        transform.position = Vector3.Lerp(transform.position, Vector3.zero, 0.1f);
        }
    }

    public void updateStats()
    {
        total += income - spending;
    }
}
