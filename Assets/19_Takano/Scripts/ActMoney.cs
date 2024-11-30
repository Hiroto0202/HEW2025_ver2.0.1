using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ActMoney : MonoBehaviour
{
    public int m_pocket = 0;
    public GameObject m_gameManager;
    CountDown m_countDown;
    Pause m_pause;
    Build m_build;

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = m_gameManager.GetComponent<CountDown>();
        m_pause = m_gameManager.GetComponent<Pause>();
        m_build = m_gameManager.GetComponent<Build>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_countDown.m_countDownFg == false && m_pause.m_pauseFg == false && m_build.m_buildFg == false)
        {
            m_pocket++;
        }
    }
}
