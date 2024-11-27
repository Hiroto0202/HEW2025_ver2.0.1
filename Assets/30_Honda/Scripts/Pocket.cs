using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    public UIManager m_UIManager;
    public ActMoney m_actMoney;
    Build m_build;
    CountDown m_countDown;
    public int m_money = 0; // すべてのお金

    // Start is called before the first frame update
    void Start()
    {
        m_build = GetComponent<Build>();
        m_countDown = GetComponent<CountDown>();
        m_UIManager.m_pocketText.enabled = false;   // 非表示
    }

    // Update is called once per frame
    void Update()
    {
        // カウントダウン終了後かつ、ビルド画面でないとき
        if (m_countDown.m_countDownFg == false && m_build.m_buildFg == false)
        {
            m_UIManager.m_pocketText.enabled = true;   // 表示
            m_UIManager.m_pocketText.text = m_actMoney.m_pocket.ToString("$000000"); // 所持金をテキストで表示
        }

        // 次のフェーズに移る時に初期化
        if (m_build.m_nextPhaseFg == true)
        {
            m_money += m_actMoney.m_pocket;             // 所持金をすべてのお金に加算
            m_actMoney.m_pocket = 0;                    // 所持金を0にする
            m_UIManager.m_pocketText.enabled = false;   // 非表示
        }
    }
}
