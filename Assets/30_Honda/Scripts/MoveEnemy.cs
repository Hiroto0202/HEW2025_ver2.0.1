using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    float m_elapsedTime = 0;            // �o�ߎ���
    public float m_deleteTime = 5;      // ���b��������폜���邩
    public bool m_deleteFg = false;     // �폜���邩�ǂ���

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_elapsedTime += Time.deltaTime;

        // �폜����b���ɂȂ�����t���O�𗧂Ă�
        if( m_elapsedTime >= m_deleteTime)
        {
            m_deleteFg = true;
            m_elapsedTime = 0;
        }

    }
}
