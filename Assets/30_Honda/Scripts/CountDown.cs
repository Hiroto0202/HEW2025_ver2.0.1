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
    public GameObject m_UIManager;      // UIを保持するオブジェクト
    TextMeshProUGUI m_text;             // カウントダウンのテキスト

    // Start is called before the first frame update
    void Start()
    {
        m_countDownFg = true;
        m_text = m_UIManager.GetComponent<UIManager>().m_countDownText;
    }

    // Update is called once per frame
    void Update()
    {
        // カウントダウン中の時
        if(m_countDownTime > 1)
        {
            m_countDownTime -= Time.deltaTime;
            m_count = (int)m_countDownTime;
            m_text.text = m_count.ToString("0");
        }
        else
        {
            m_countDownFg = false;  // カウントダウン終了
            m_text.enabled = false; // テキストを非表示
        }
    }
}
