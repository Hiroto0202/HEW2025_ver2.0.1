using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public UIManager m_UIManager;
    TimeLimit m_timeLimit;
    public bool m_buildFg;  // ビルド画面かどうか


    // Start is called before the first frame update
    void Start()
    {
        m_timeLimit = GetComponent<TimeLimit>();
        m_UIManager.m_buildText.enabled = false;    // ビルドを非表示
    }

    // Update is called once per frame
    void Update()
    {
        // 制限時間が過ぎたら
        if(m_timeLimit.m_time <= 0)
        {
            m_buildFg = true;   // ビルド画面にする
        }

        // ビルド画面の時
        if(m_buildFg == true)
        {
            Time.timeScale = 0.0f;  // ゲームを止める
            m_UIManager.m_buildText.enabled = true; // ビルドを表示

            // エンターキーが押されたら
            if(Input.GetKeyDown(KeyCode.Return))
            {
                m_buildFg = false;   // ゲームに戻る
            }
        }
        // ビルド画面でない時
        else
        {
            m_UIManager.m_buildText.enabled = false; // ビルドを表示
            Time.timeScale = 1.0f;  // 時間を進める
        }
    }
}
