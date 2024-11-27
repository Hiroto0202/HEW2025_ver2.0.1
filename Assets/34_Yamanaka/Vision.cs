using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    bool m_throwedMoney = false;

    GameObject m_obj;
    public GameObject m_prefub;

    bool m_discoverThrow;
    bool m_throwFlg;

    bool m_throwdust;
    bool m_throwMoney;

    public bool m_discoverPlayer = false;

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


        switch (m_obj.name.ToString())
        {
            case "DiscoverThrow":
                DiscoverPlayer();
                break;

            case "DiscoverDust":
                DiscoverDust();
                break;

            case "DiscoverMoney":
                DiscoverMoney();
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

    }

    void DiscoverMoney()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Money")
        {
            m_throwedMoney = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Money")
        {
            m_throwedMoney = false;
        }
    }

}
