using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseInfo : MonoBehaviour
{
    public UIManager m_UIManager;
    CountDown m_countDown;
    Build m_build;

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = GetComponent<CountDown>();
        m_build = GetComponent<Build>();
        m_UIManager.m_weatherText.enabled = false;      // ��\��
        m_UIManager.m_situationText.enabled = false;    // ��\��
    }

    // Update is called once per frame
    void Update()
    {
        // �J�E���g�_�E���I����
        if (m_countDown.m_countDownFg == false)
        {
            m_UIManager.m_weatherText.enabled = true;      // �\��
            m_UIManager.m_situationText.enabled = true;    // �\��

            switch (m_build.m_phaseCnt)
            {
                case 0:
                    m_UIManager.m_weatherText.text = "Asa";      // �t�F�[�Y�X�V
                    m_UIManager.m_situationText.text = "Hare";   // �t�F�[�Y��ԍX�V
                    break;
                case 1:
                    m_UIManager.m_weatherText.text = "Hiru";     // �t�F�[�Y�X�V
                    m_UIManager.m_situationText.text = "Kumori"; // �t�F�[�Y��ԍX�V
                    break;
                case 2:
                    m_UIManager.m_weatherText.text = "Yoru";     // �t�F�[�Y�X�V
                    m_UIManager.m_situationText.text = "Ame";    // �t�F�[�Y��ԍX�V
                    break;
                case 3:
                    m_build.m_phaseCnt = 0; // �t�F�[�Y���Z�b�g
                    break;
            }
        }

        // ���̃t�F�[�Y�Ɉڂ鎞�ɏ�����
        if (m_build.m_nextPhaseFg == true)
        {
            m_UIManager.m_weatherText.enabled = false;      // ��\��
            m_UIManager.m_situationText.enabled = false;    // ��\��
        }
    }
}
