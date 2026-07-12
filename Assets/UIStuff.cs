using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIStuff : MonoBehaviour
{
    public static UIStuff me;
    public TMP_Text[] textBoxes;

    public Button[] buttons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        me = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
