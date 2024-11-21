using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    float m_elapsedTime = 0;            // 経過時間
    public float m_deleteTime = 5;      // 何秒たったら削除するか
    public bool m_deleteFg = false;     // 削除するかどうか

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_elapsedTime += Time.deltaTime;

        // 削除する秒数になったらフラグを立てる
        if( m_elapsedTime >= m_deleteTime)
        {
            m_deleteFg = true;
            m_elapsedTime = 0;
        }

    }
}
