using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    public float m_countDownTime = 4;   // カウントダウンする秒数
    int m_count = 0;                    // カウントダウン表示用
    public bool m_countDownFg;          // カウントダウンしているかどうか 
    public UIManager m_UIManager;
    Build m_build;

    // Start is called before the first frame update
    void Start()
    {
        m_build = GetComponent<Build>();
        m_countDownFg = true;
    }

    // Update is called once per frame
    void Update()
    {
        // カウントダウン中の時
        if(m_countDownTime > 1)
        {
            m_countDownTime -= Time.deltaTime;
            m_count = (int)m_countDownTime;
            m_UIManager.m_countDownText.text = m_count.ToString("0");
        }
        else
        {
            m_countDownFg = false;  // カウントダウン終了
            m_UIManager.m_countDownText.enabled = false; // テキストを非表示
        }

        // 次のフェーズに移る時に初期化
        if (m_build.m_nextPhaseFg == true)
        {
            m_countDownFg = true;
        }
    }
}
