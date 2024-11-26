using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public UIManager m_UIManager;
    CountDown m_countDown;
    bool m_pauseFg = false;     // ポーズ中かどうか

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
                m_pauseFg = !m_pauseFg; // ポーズするかどうかを決定
            }

            // ポーズする時
            if(m_pauseFg == true)
            {
                Time.timeScale = 0.0f;  // ゲームを止める
                m_UIManager.m_pauseText.enabled = true;    // ポーズ表示

                // バックスペースでゲーム終了
                if (Input.GetKeyDown(KeyCode.Backspace))
                {

                    // UnityEditorでの実行なら再生モードを解除
                    #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
                    // ビルド後ならアプリケーションを終了
                    #else
                        Application.Quit();
                    #endif
                }
            }
            // ポーズしない時
            else
            {
                Time.timeScale = 1.0f;  // ゲームを進める
                m_UIManager.m_pauseText.enabled = false;    // ポーズ非表示
            }
        }
    }
}
