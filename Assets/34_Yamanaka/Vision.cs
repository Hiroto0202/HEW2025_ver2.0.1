using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    bool m_playerThrow = false;
    bool m_throwedDust = false;
    bool m_throwedMoney = false;

    bool m_throwFlg;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        m_throwFlg = MoveEnemy.m_throwFlg;

        if (m_throwFlg == true)
        {
            if(m_playerThrow==true)
            {
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            m_playerThrow = true;
        }
        if(other.gameObject.tag=="Dust")
        {
            m_throwedDust = true;
        }
        if(other.gameObject.tag=="Money")
        {
            m_throwedMoney = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_playerThrow = false;
        }
        if (other.gameObject.tag == "Dust")
        {
            m_throwedDust = false;
        }
        if (other.gameObject.tag == "Money")
        {
            m_throwedMoney = false;
        }
    }

    void DiscoverThrow()
    {

    }

    void DiscoverDust()
    {

    }

    void DiscoverMoney()
    {

    }
}
