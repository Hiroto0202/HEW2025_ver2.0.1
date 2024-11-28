using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    public UIManager m_UIManager;
    CountDown m_countDown;
    Pause m_pause;
    Build m_build;
    public float m_time = 10;
    public bool m_endFg = false;    // �������ԂɂȂ������ǂ���

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = GetComponent<CountDown>();
        m_pause = GetComponent<Pause>();
        m_build = GetComponent<Build>();
    }

    // Update is called once per frame
    void Update()
    {
        // �J�E���g�_�E���I����Ɏ��s
        if(m_countDown.m_countDownFg == false)
        {
            m_UIManager.m_timeLimitText.enabled = true; // �\��

            // �|�[�Y�A�r���h�ȊO�̎��Ɏ��Ԃ����炷
            if (m_time > 0 && m_pause.m_pauseFg == false && m_build.m_buildFg == false)
            {

                m_time -= Time.deltaTime;
                m_UIManager.m_timeLimitText.text = m_time.ToString("0.00s");
            }
            else
            {
                m_endFg = true;
            }
        }
    }

    //===========================================================
    // ����������
    //===========================================================
     public void Init()
    {
        Debug.Log("Hoge");
        m_time = 10;
        m_endFg = false;    // �������ԂɂȂ������ǂ���
        m_UIManager.m_timeLimitText.enabled = false; // ��\��
    }
}
