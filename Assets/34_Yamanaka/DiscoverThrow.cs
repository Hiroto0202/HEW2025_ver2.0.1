using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoverThrow : MonoBehaviour
{

    public bool m_playerThrow = false;

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
        if (other.gameObject.tag == "Player")
        {
            m_playerThrow = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_playerThrow = false;
        }

    }
}