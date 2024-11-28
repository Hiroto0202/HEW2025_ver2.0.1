using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject m_enemyPrefab;                        // 敵のプレハブ
    GameObject m_newEnemy;                                  // 新しく生成された敵
    List<GameObject> m_enemyList = new List<GameObject>();  // 現在の敵のリスト
    public int m_maxEnemyNum = 20;                          // 敵の最大出現数
    public float m_searchFlagTime = 1;                      // 何秒ごとにフラグが立ったかを調べるか
    float m_elapsedTime = 0;                                // 経過時間

    [Header("敵の生成範囲")]
    public int m_minX = -8;
    public int m_maxX = 8;
    public int m_minY = -5;
    public int m_maxY = 5;

    CountDown m_countDown;
    Pause m_pause;
    Build m_build;
    Fade m_fade;

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = GetComponent<CountDown>();
        m_pause = GetComponent<Pause>();
        m_build = GetComponent<Build>();
        m_fade = GetComponent<Fade>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_countDown.m_countDownFg == false && m_pause.m_pauseFg == false && m_build.m_buildFg == false)
        {
            m_elapsedTime += Time.deltaTime;    // 経過時間を求める

            CreateEnemy();  // 最大出現数まで敵を作成する
            DeleteEnemy();  // フラグの立っている敵を削除する
        }

        // 次のフェーズに移る時に初期化
        if(m_build.m_nextPhaseFg == true)
        {
            Init();
        }
    }

    //===========================================
    // 初期化処理
    //===========================================
    public void Init()
    {
        // 敵が存在する場合
        if (m_enemyList.Count > 0)
        {
            // すべての敵を削除する
            for (int _index = m_enemyList.Count - 1; _index >= 0; --_index)
            {
                Destroy(m_enemyList[_index]);
                m_enemyList.RemoveAt(_index);
            }
        }
    }

    //===========================================
    // 敵をランダムな位置に作成する処理
    //===========================================
    private void CreateEnemy()
    {
        // 敵が最大出現数より少ない時
        if(m_enemyList.Count < m_maxEnemyNum )
        {
            // フェードインしていない時
            //if(m_fade.m_isFadeIn == false)
            {
                m_newEnemy = Instantiate(m_enemyPrefab);    // 敵を生成
                m_enemyList.Add(m_newEnemy);                // 敵をリストに追加
                // 決められた範囲内のランダムな位置にする
                float _x = Random.Range(m_minX, m_maxX);
                float _y = Random.Range(m_minY, m_maxY);
                m_newEnemy.transform.position = new Vector2(_x, _y);
               // m_fade.FadeIn(m_newEnemy);  // フェードイン開始
            }
            // フェードインしている時
            //else
            {
               // m_fade.FadeIn(m_newEnemy);  // フェードインのみ実行
            }

        }
    }

    //===========================================
    // 敵を削除する処理
    //===========================================
    private void DeleteEnemy()
    {
        // 検索時間になった時
        if(m_elapsedTime >= m_searchFlagTime)
        {
            int _index = Random.Range(0, m_enemyList.Count);    // 削除する敵の添え字を決定
            // 敵スクリプト内の削除フラグが立っている時
            if (m_enemyList[_index].GetComponent<MoveEnemy>().m_deleteFg == true)
            {
                m_fade.FadeOut(m_enemyList[_index]);    // フェードアウト開始
                // フェードアウトしている時
                if(m_fade.m_isFadeOut == true)
                {
                    m_fade.FadeOut(m_enemyList[_index]);    // フェードアウトのみ実行
                }
                // フェードアウト終了後
                else
                {
                    // 敵を削除する
                    Destroy(m_enemyList[_index]);
                    m_enemyList.RemoveAt(_index);
                    Debug.Log(_index + "番目を削除した");
                }
            }
            m_elapsedTime = 0;  // 経過時間をリセット
        }
    }
}
