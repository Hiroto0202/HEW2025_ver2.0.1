using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search : MonoBehaviour
{
    public bool m_throwMoney = false;
    public bool m_throwDust = false;
    public bool m_playerThrow = false;

    public int m_enemyCount = 0;

    public bool m_deleteFlg = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_playerThrow = true;
        }

        if (other.gameObject.tag == "Dust")
        {
            m_throwDust = true;
        }

        if (other.gameObject.tag == "ThrowMoney")
        {
            m_throwMoney = true;
        }

        if (other.transform.tag == "Enemy")
        {
            m_enemyCount++;
            Debug.Log("Enemy”­Œ©");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_playerThrow = false;
        }

        if (other.gameObject.tag == "Dust")
        {
            m_throwDust = false;
        }

        if (other.gameObject.tag == "ThrowMoney")
        {
            m_throwMoney = false;
        }

        if (other.transform.tag == "Enemy")
        {
            m_enemyCount--;
        }
    }

}
