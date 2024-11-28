using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CountDown m_countDown;
    public TimeLimit m_timeLimit;
    public EnemyManager m_enemyManager;
    public Pocket m_pocket;
    public PhaseInfo m_phaseInfo;
    public Pause m_pause;
    public Build m_build;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_build.m_nextPhaseFg == true)
        {
            GameInit();
            m_build.m_nextPhaseFg = false;
        }
    }

    //===============================================
    // ÉQÅ[ÉÄÇÃèâä˙âª
    //===============================================
    public void GameInit()
    {
        m_countDown.Init();
        m_timeLimit.Init();
        m_enemyManager.Init();
        m_phaseInfo.Init();
        m_pause.Init();
        m_build.GameInit();
    }
}
