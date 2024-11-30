using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{

    GameObject m_obj;
    public GameObject m_prefub;

    bool m_discoverThrow;
    bool m_throwFlg;

    bool m_throwDust;
    bool m_throwMoney;

    public bool m_discoverPlayer = false;
    public bool m_discoverDust = false;
    public bool m_discoverMoney = false;

    Battle m_battle;

    public int m_enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        m_obj = Instantiate(m_prefub);
    }

    // Update is called once per frame
    void Update()
    {
        m_obj.transform.position = this.transform.position;

        m_obj.transform.localScale = Vector3.one * 5;

        m_throwFlg = this.GetComponent<MoveEnemy>().m_throwFlg;

        string m_name = m_obj.name;


        switch (m_name)
        {
            case "SearchPlayer(Clone)":
                DiscoverPlayer();
                break;

            case "SearchDust(Clone)":
                DiscoverDust();
                break;

            case "SearchMoney(Clone)":
                DiscoverMoney();
                break;

            case "SearchEnemy(Clone)":
                DiscoverEnemy();
                break;
        }
    }

    void DiscoverPlayer()
    {
        if (m_obj.name == "SearchPlayer(Clone)")
        {
            m_discoverThrow = m_obj.GetComponent<DiscoverThrow>().m_playerThrow;
        }


        if (m_throwFlg)
        {
            if (m_discoverThrow)
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
        if (m_obj.name == "SearchDust(Clone)")
        {
            m_throwDust = m_obj.GetComponent<DiscoverDust>().m_throwDust;
        }


        if (m_throwFlg)
        {
            if (!m_discoverThrow)
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
        if (m_obj.name == "SearchMoney(Clone)")
        {
            m_throwMoney = m_obj.GetComponent<DiscoverMoney>().m_throwMoney;
        }


        if (m_throwMoney)
        {
            m_discoverMoney = true;
        }
    }

    void DiscoverEnemy()
    {
        if (m_obj.name == "SearchEnemy(Clone)")
        {
            m_enemyCount = m_obj.GetComponent<DiscoverEnemy>().m_enemyCount;
        }

        m_throwFlg = GetComponent<MoveEnemy>().m_throwFlg;

        if (m_throwFlg)
        {
            if (m_enemyCount >= 2)
            {
                m_battle = GetComponent<Battle>();
                m_battle.Start();
            }
        }
    }
}
