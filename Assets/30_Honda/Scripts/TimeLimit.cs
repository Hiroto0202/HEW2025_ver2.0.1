using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    public UIManager m_UIManager;
    CountDown m_countDown;
    Pause m_pause;
    Build m_build;
    public float m_time = 10;
    public bool m_endFg = false;    // 制限時間になったかどうか

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = GetComponent<CountDown>();
        m_pause = GetComponent<Pause>();
        m_build = GetComponent<Build>();
    }

    // Update is called once per frame
    void Update()
    {
        // カウントダウン終了後に実行
        if(m_countDown.m_countDownFg == false)
        {
            m_UIManager.m_timeLimitText.enabled = true; // 表示

            // ポーズ、ビルド以外の時に時間を減らす
            if (m_time > 0 && m_pause.m_pauseFg == false && m_build.m_buildFg == false)
            {

                m_time -= Time.deltaTime;
                m_UIManager.m_timeLimitText.text = m_time.ToString("0.00s");
            }
            else
            {
                m_endFg = true;
            }
        }
    }

    //===========================================================
    // 初期化処理
    //===========================================================
     public void Init()
    {
        Debug.Log("Hoge");
        m_time = 10;
        m_endFg = false;    // 制限時間になったかどうか
        m_UIManager.m_timeLimitText.enabled = false; // 非表示
    }
}
