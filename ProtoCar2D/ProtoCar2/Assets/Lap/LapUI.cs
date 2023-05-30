using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LapUI : MonoBehaviour
{
    int CounterLap = 1;
    [SerializeField] GameObject LapController;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject Car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Car.GetComponent<CarLogic>().justCollided)
        {
            CounterLap = 1;
            text.text = CounterLap.ToString();
        }


        if(LapController.GetComponent<LapCounter>().lapChanged == true)
        {
            CounterLap++;
            text.text = CounterLap.ToString();
            LapController.GetComponent<LapCounter>().lapChanged = false;
            Debug.Log("HELLOOOO");
            
        }
    }
}
