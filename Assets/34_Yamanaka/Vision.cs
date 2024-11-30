using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Vision : MonoBehaviour
{

    GameObject m_obj;
    public GameObject m_prefub;

    bool m_throwFlg;
    bool m_playerThrow;

    bool m_throwDust;
    bool m_throwMoney;

    public bool m_discoverPlayer = false;
    public bool m_discoverDust = false;
    public bool m_discoverMoney = false;

    Battle m_battle;

    public int m_enemyCount;

    public bool m_deleteFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        //m_obj = Instantiate(m_prefub,transform);
        m_obj = Instantiate(m_prefub);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_obj != null)
        {
            m_obj.transform.position = this.transform.position;
            m_obj.transform.localScale = Vector3.one * 5;

            m_throwFlg = this.GetComponent<MoveEnemy>().m_throwFlg;

            m_playerThrow = m_obj.GetComponent<Search>().m_playerThrow;
            m_throwDust = m_obj.GetComponent<Search>().m_throwDust;
            m_throwMoney = m_obj.GetComponent<Search>().m_throwMoney;
            m_enemyCount = m_obj.GetComponent<Search>().m_enemyCount;

            DiscoverPlayer();
            DiscoverDust();
            DiscoverMoney();
            DiscoverEnemy();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void DiscoverPlayer()
    {
        if (m_throwFlg)
        {
            if (m_playerThrow)
            {
                m_discoverPlayer = true;
            }
            else
            {
                m_discoverPlayer = false;
            }
        }
    }

    void DiscoverDust()
    {
        if (m_throwFlg)
        {
            if (!m_playerThrow)
            {
                m_discoverDust = true;
            }
            else
            {
                m_discoverDust = false;
            }
        }
    }

    void DiscoverMoney()
    {
        if (m_throwMoney)
        {
            m_discoverMoney = true;
        }
    }

    void DiscoverEnemy()
    {
        if (m_throwFlg)
        {
            if (!m_discoverPlayer)
            {
                if (m_enemyCount >= 2)
                {
                    m_battle = GetComponent<Battle>();
                    m_battle.Start();

                    Destroy(m_obj);
                    Destroy(this.gameObject);
                }
            }
        }
    }

}
