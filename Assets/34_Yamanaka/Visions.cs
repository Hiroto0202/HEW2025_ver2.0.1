using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visions : MonoBehaviour
{
    bool m_playerThrow = false;
    bool m_throwedDust = false;
    bool m_throwedMoney = false;

    bool m_throwFlg;

<<<<<<< Updated upstream
=======
    bool m_throwFlg;
    bool m_playerThrow;

    public bool m_discoverPlayer = false;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
=======
        m_obj = Instantiate(m_playerPre);
        m_obj.transform.localScale = Vector3.one * 5;
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        m_throwFlg = MoveEnemy.m_throwFlg;

        if (m_throwFlg == true)
        {
            if(m_playerThrow==true)
=======
        m_obj.transform.position = this.transform.position;

        m_throwFlg = this.GetComponent<MoveEnemy>().m_throwFlg;
        m_playerThrow = m_obj.GetComponent<DiscoverThrow>().m_playerThrow;
        
        if (m_throwFlg)
        {
            if(m_playerThrow)
>>>>>>> Stashed changes
            {
                
            }
            else
            {
                m_discoverPlayer = false;
            }
        }
        else
        {
            m_discoverPlayer = false;
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
