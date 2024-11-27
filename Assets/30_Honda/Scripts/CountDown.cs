using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    public float m_countDownTime = 4;   // �J�E���g�_�E������b��
    int m_count = 0;                    // �J�E���g�_�E���\���p
    public bool m_countDownFg;          // �J�E���g�_�E�����Ă��邩�ǂ��� 
    public UIManager m_UIManager;
    Build m_build;

    // Start is called before the first frame update
    void Start()
    {
        m_build = GetComponent<Build>();
        m_countDownFg = true;
    }

    // Update is called once per frame
    void Update()
    {
        // �J�E���g�_�E�����̎�
        if(m_countDownTime > 1)
        {
            m_countDownTime -= Time.deltaTime;
            m_count = (int)m_countDownTime;
            m_UIManager.m_countDownText.text = m_count.ToString("0");
        }
        else
        {
            m_countDownFg = false;  // �J�E���g�_�E���I��
            m_UIManager.m_countDownText.enabled = false; // �e�L�X�g���\��
        }

        // ���̃t�F�[�Y�Ɉڂ鎞�ɏ�����
        if (m_build.m_nextPhaseFg == true)
        {
            m_countDownFg = true;
        }
    }
}
