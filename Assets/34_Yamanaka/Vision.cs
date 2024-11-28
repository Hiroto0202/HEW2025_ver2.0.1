using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
<<<<<<< Updated upstream

    GameObject m_obj;
    public GameObject m_prefub;

    bool m_discoverThrow;
    public bool m_throwFlg;

    bool m_throwDust;
    bool m_throwMoney;

    public bool m_discoverPlayer = false;
    public bool m_discoverDust = false;
    public bool m_discoverMoney = false;
=======
    bool m_throwedDust = false;
    bool m_throwedMoney = false;

    GameObject m_obj;
    public GameObject m_playerPre;

    DiscoverThrow m_discoverThrow;

    public static bool m_discoverPlayer = false;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        m_obj = Instantiate(m_prefub);
=======
        m_obj = Instantiate(m_playerPre);
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        m_obj.transform.position = this.transform.position;
<<<<<<< Updated upstream

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
=======
        
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
>>>>>>> Stashed changes

    }

    void DiscoverDust()
    {
<<<<<<< Updated upstream
        m_throwDust = m_obj.GetComponent<DiscoverDust>().m_throwDust;
        m_discoverThrow = m_obj.GetComponent<DiscoverThrow>().m_playerThrow;

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
=======
>>>>>>> Stashed changes

    }

    void DiscoverMoney()
    {
<<<<<<< Updated upstream
        bool m_throwMoney = m_obj.GetComponent<DiscoverMoney>().m_throwMoney;

        if(m_throwMoney)
        {
            m_discoverMoney = true;
        }
=======

>>>>>>> Stashed changes
    }
}
