using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    public UIManager m_UIManager;
    public ActMoney m_actMoney;
    CountDown m_countDown;
    public int m_money = 0; // すべてのお金

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = GetComponent<CountDown>();
        // 初期の所持金を表示
        m_UIManager.m_pocketText.enabled = true; 
        m_UIManager.m_pocketText.text = m_actMoney.m_pocket.ToString("$000000");
    }

    // Update is called once per frame
    void Update()
    {
        // カウントダウン終了後
        if (m_countDown.m_countDownFg == false)
        {
            // 所持金をテキストで表示
            m_UIManager.m_pocketText.text = m_actMoney.m_pocket.ToString("$000000");
        }
    }

    //===========================================================
    // 初期化処理
    //===========================================================
    public void Init()
    {
        m_actMoney.m_pocket = 0;                    // 所持金を0にする
    }
}
