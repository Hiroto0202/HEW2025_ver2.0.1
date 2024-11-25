using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public UIManager m_UIManager;
    CountDown m_countDown;

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = GetComponent<CountDown>();
        m_UIManager.m_pauseText.enabled = false;    // 最初は表示しない
    }

    // Update is called once per frame
    void Update()
    {
        // カウントダウン終了後
        if(m_countDown.m_countDownFg == false)
        {
            // エスケープキーが押された時
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0.0f;  // ゲームを止める
                m_UIManager.m_pauseText.enabled = true;    // ポーズ表示                                                                     

                // もう一度エスケープキーが押された時
                if (Input.GetKeyDown(KeyCode.Escape)) 
                {
                    // UnityEditorでの実行なら再生モードを解除
                    #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
                    // ビルド後ならアプリケーションを終了
                    #else
                        Application.Quit();
                    #endif
                }
                // バックスペースが押された時
                else if(Input.GetKeyDown(KeyCode.Backspace))
                {
                    m_UIManager.m_pauseText.enabled = false;    // ポーズ非表示
                    Time.timeScale = 1.0f;                     // ゲームに戻る
                }
            }
        }
    }
}
