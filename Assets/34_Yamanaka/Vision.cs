using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{

    GameObject m_obj;
    public GameObject m_prefub;

    bool m_discoverThrow;
    public bool m_throwFlg;

    bool m_throwDust;
    bool m_throwMoney;

    public bool m_discoverPlayer = false;
    public bool m_discoverMoney = false;

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
                Debug.Log("Searchplayeré¿çsíÜ");
                break;

            case "DiscoverDust(Clone)":
                //DiscoverDust();
                break;

            case "DiscoverMoney(Clone)":
                //DiscoverMoney();
                break;
        }
    }

    void DiscoverPlayer()
    {

        m_discoverThrow = m_obj.GetComponent<DiscoverThrow>().m_playerThrow;

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
        //m_throwDust = m_obj.GetComponent<DiscoverDust>().m_throwDust;
        //m_discoverThrow = m_obj.GetComponent<DiscoverThrow>().m_playerThrow;

        //if (!m_throwFlg)
        //{
        //    if (m_discoverThrow)
        //    {
        //        m_discoverPlayer = true;
        //    }
        //    else
        //    {
        //        m_discoverPlayer = false;
        //    }
        //}

    }

    void DiscoverMoney()
    {
        bool m_throwMoney = m_obj.GetComponent<DiscoverMoney>().m_throwMoney;

        if(m_throwMoney)
        {
            m_discoverMoney = true;
        }
    }
}
