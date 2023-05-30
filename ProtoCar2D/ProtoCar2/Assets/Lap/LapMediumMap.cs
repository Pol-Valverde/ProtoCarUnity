using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapMediumMap : MonoBehaviour
{
    public bool mediumMapBoolean;
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
        if (collision.tag == "Car")
        {
            mediumMapBoolean = true;
            
        }
    }
}
