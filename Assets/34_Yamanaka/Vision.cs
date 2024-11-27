using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    bool m_throwedDust = false;
    bool m_throwedMoney = false;

    GameObject m_obj;
    public GameObject m_playerPre;

    bool m_discoverThrow;
    bool m_throwFlg;

    public bool m_discoverPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        m_obj = Instantiate(m_playerPre);
    }

    // Update is called once per frame
    void Update()
    {
        m_obj.transform.position = this.transform.position;

        m_obj.transform.localScale = Vector3.one * 5;

        m_throwFlg = this.GetComponent<MoveEnemy>().m_throwFlg;
        m_discoverThrow = m_obj.GetComponent<DiscoverThrow>().m_playerThrow;
        
        if (m_throwFlg)
        {
            if(m_discoverThrow)
            {
                m_discoverPlayer = true;
            }
            else
            {
                m_discoverPlayer = false;
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
