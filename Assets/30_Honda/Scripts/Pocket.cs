using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    public UIManager m_UIManager;
    public ActMoney m_actMoney;
    Build m_build;
    CountDown m_countDown;
    public int m_money = 0; // ���ׂĂ̂���

    // Start is called before the first frame update
    void Start()
    {
        m_build = GetComponent<Build>();
        m_countDown = GetComponent<CountDown>();
        m_UIManager.m_pocketText.enabled = false;   // ��\��
    }

    // Update is called once per frame
    void Update()
    {
        // �J�E���g�_�E���I���ォ�A�r���h��ʂłȂ��Ƃ�
        if (m_countDown.m_countDownFg == false && m_build.m_buildFg == false)
        {
            m_UIManager.m_pocketText.enabled = true;   // �\��
            m_UIManager.m_pocketText.text = m_actMoney.m_pocket.ToString("$000000"); // ���������e�L�X�g�ŕ\��
        }

        // ���̃t�F�[�Y�Ɉڂ鎞�ɏ�����
        if (m_build.m_nextPhaseFg == true)
        {
            m_money += m_actMoney.m_pocket;             // �����������ׂĂ̂����ɉ��Z
            m_actMoney.m_pocket = 0;                    // ��������0�ɂ���
            m_UIManager.m_pocketText.enabled = false;   // ��\��
        }
    }
}
