using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    public UIManager m_UIManager;
    Build m_build;
    CountDown m_countDown;

    // Start is called before the first frame update
    void Start()
    {
        m_UIManager = GetComponent<UIManager>();
        m_build = GetComponent<Build>();
        m_countDown = GetComponent<CountDown>();
    }

    // Update is called once per frame
    void Update()
    {
        // �J�E���g�_�E���I���ォ�A�r���h��ʂłȂ��Ƃ�
        if (m_countDown.m_countDownFg == false && m_build.m_buildFg == false)
        {

        }
    }
}
