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
    public GameObject m_UIManager;      // UI��ێ�����I�u�W�F�N�g
    TextMeshProUGUI m_text;             // �J�E���g�_�E���̃e�L�X�g

    // Start is called before the first frame update
    void Start()
    {
        m_countDownFg = true;
        m_text = m_UIManager.GetComponent<UIManager>().m_countDownText;
    }

    // Update is called once per frame
    void Update()
    {
        // �J�E���g�_�E�����̎�
        if(m_countDownTime > 1)
        {
            m_countDownTime -= Time.deltaTime;
            m_count = (int)m_countDownTime;
            m_text.text = m_count.ToString("0");
        }
        else
        {
            m_countDownFg = false;  // �J�E���g�_�E���I��
            m_text.enabled = false; // �e�L�X�g���\��
        }
    }
}
