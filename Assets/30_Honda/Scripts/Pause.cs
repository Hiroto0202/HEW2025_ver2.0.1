using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public UIManager m_UIManager;
    CountDown m_countDown;
    Build m_build;
    public bool m_pauseFg = false;     // ポーズ中かどうか

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = GetComponent<CountDown>();
        m_build = GetComponent<Build>();
        m_UIManager.m_pauseText.enabled = false;    // 最初は表示しない
    }

    // Update is called once per frame
    void Update()
    {
        // カウントダウン終了後かつ、ビルド画面でないとき
        if(m_countDown.m_countDownFg == false && m_build.m_buildFg == false)
        {
            // エスケープキーが押された時
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                m_pauseFg = !m_pauseFg; // ポーズするかどうかを決定
            }

            // ポーズする時
            if(m_pauseFg == true)
            {
                Debug.Log("ポーズ中");
                //Time.timeScale = 0.0f;  // ゲームを止める
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
                Debug.Log("ポーズ解除");
                //Time.timeScale = 1.0f;  // ゲームを進める
                m_UIManager.m_pauseText.enabled = false;    // ポーズ非表示
            }
        }
    }

    //===========================================================
    // 初期化処理
    //===========================================================
    public void Init()
    {
        m_pauseFg = false;                          // ポーズしない
        m_UIManager.m_pauseText.enabled = false;    // 最初は表示しない
    }
}
