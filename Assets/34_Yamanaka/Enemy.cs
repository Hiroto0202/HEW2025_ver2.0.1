using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool m_throwFlg = false;
    public bool m_discoverPlayer = false;
    public bool m_discoverDust = false;
    public bool m_discoverMoney = false;

    public int m_enemyCount = 0;

    GameObject m_search;

    public bool m_deleteFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_throwFlg = GetComponent<MoveEnemy>().m_throwFlg;
        m_discoverPlayer = GetComponent<Vision>().m_discoverPlayer;
        m_discoverDust = GetComponent<Vision>().m_discoverDust;
        m_discoverMoney = GetComponent<Vision>().m_discoverMoney;
        m_enemyCount = GetComponent<Vision>().m_enemyCount;

        m_deleteFlg = GetComponent<Vision>().m_deleteFlg;
    }
}
