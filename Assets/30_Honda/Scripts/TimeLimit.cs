using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    public UIManager m_UIManager;
    CountDown m_countDown;
    public float m_time = 10;
    public bool m_endFg = false;    // �������ԂɂȂ������ǂ���

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = GetComponent<CountDown>();
    }

    // Update is called once per frame
    void Update()
    {
        // �J�E���g�_�E���I����Ɏ��s
        if(m_countDown.m_countDownFg == false)
        {
            if (m_time > 0)
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
}
