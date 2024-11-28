using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseInfo : MonoBehaviour
{
    public UIManager m_UIManager;
    CountDown m_countDown;
    Build m_build;

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = GetComponent<CountDown>();
        m_build = GetComponent<Build>();
        m_UIManager.m_weatherText.text = "Asa";         // 初期フェーズ
        m_UIManager.m_situationText.text = "Hare";      // 初期フェーズ状態
        m_UIManager.m_weatherText.enabled = true;       // 表示
        m_UIManager.m_situationText.enabled = true;     // 表示
    }

    // Update is called once per frame
    void Update()
    {
        // カウントダウン終了後
        if (m_countDown.m_countDownFg == false)
        {
            switch (m_build.m_phaseCnt)
            {
                case 0:
                    m_UIManager.m_weatherText.text = "Asa";      // フェーズ更新
                    m_UIManager.m_situationText.text = "Hare";   // フェーズ状態更新
                    break;
                case 1:
                    m_UIManager.m_weatherText.text = "Hiru";     // フェーズ更新
                    m_UIManager.m_situationText.text = "Kumori"; // フェーズ状態更新
                    break;
                case 2:
                    m_UIManager.m_weatherText.text = "Yoru";     // フェーズ更新
                    m_UIManager.m_situationText.text = "Ame";    // フェーズ状態更新
                    break;
                case 3:
                    m_build.m_phaseCnt = 0; // フェーズリセット
                    break;
            }
        }
    }

    //===========================================================
    // 初期化処理
    //===========================================================
    public void Init()
    {

    }
}