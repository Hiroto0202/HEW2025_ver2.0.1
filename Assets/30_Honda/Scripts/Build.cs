using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public UIManager m_UIManager;
    TimeLimit m_timeLimit;
    public bool m_buildFg;              // ビルド画面かどうか
    public int m_phaseCnt = 0;          // 何フェーズ目か
    public bool m_nextPhaseFg = false;
    //bool m_phaseUpdateFg = false;         // フェーズを更新するかどうか
    //bool m_ = false;       

    // Start is called before the first frame update
    void Start()
    {
        m_timeLimit = GetComponent<TimeLimit>();
        m_UIManager.m_buildText.enabled = false;    // ビルドを非表示
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_phaseCnt);
        // 制限時間が過ぎたら
        if(m_timeLimit.m_time <= 0)
        {
            m_buildFg = true;   // ビルド画面にする
            //m_phaseUpdateFg = true;
            //// フェーズ情報を次のものに更新する
            //if (m_phaseUpdateFg == true)
            //{
            //    m_phaseCnt++;            // 次のフェーズにする
            //    m_phaseUpdateFg = false; // これ以上変化させない
            //}
        }

        // ビルド画面の時
        if(m_buildFg == true)
        {
            //Time.timeScale = 0.0f;  // ゲームを止める
            m_UIManager.m_buildText.enabled = true; // ビルドを表示

            // エンターキーが押されたら
            if(Input.GetKeyDown(KeyCode.Return))
            {
                m_phaseCnt++;           // 次のフェーズにする
                m_buildFg = false;      // ゲームに戻る
                m_nextPhaseFg = true;   // 次のフェーズに移る
                //m_phaseUpdateFg = false;
            }
        }
        // ビルド画面でない時
        else
        {
            Debug.Log("ビルド終了");
            m_UIManager.m_buildText.enabled = false; // ビルドを非表示
            //Time.timeScale = 1.0f;  // 時間を進める
        }
    }

    public void GameInit()
    {
        m_timeLimit.Init();

    }
}
