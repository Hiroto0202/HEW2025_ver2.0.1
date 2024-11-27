using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoverDust : MonoBehaviour
{
    bool m_throwDust = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Dust")
        {
            m_throwDust = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag =="Dust")
        {
            m_throwDust= false;
        }
    }
}
