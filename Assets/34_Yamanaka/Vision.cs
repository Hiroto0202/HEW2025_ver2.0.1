using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    bool m_throwedDust = false;
    bool m_throwedMoney = false;

    GameObject m_obj;
    public GameObject m_playerPre;

    DiscoverThrow m_discoverThrow;

    public static bool m_discoverPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        m_obj = Instantiate(m_playerPre);
    }

    // Update is called once per frame
    void Update()
    {
        m_obj.transform.position = this.transform.position;
        
        if (MoveEnemy.m_throwFlg == true)
        {
            if(m_discoverThrow.m_playerThrow)
            {
                m_discoverPlayer = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Dust")
        {
            m_throwedDust = true;
        }
        if(other.gameObject.tag=="Money")
        {
            m_throwedMoney = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
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
