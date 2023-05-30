using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCounter : MonoBehaviour
{
    
    [SerializeField] GameObject mediumMap;
    public bool lapChanged;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag == "Car" && mediumMap.GetComponent<LapMediumMap>().mediumMapBoolean == true)
        {
            lapChanged = true;
            mediumMap.GetComponent<LapMediumMap>().mediumMapBoolean = false;

            
        }
    }
}
