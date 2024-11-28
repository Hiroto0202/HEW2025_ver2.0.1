using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    public UIManager m_UIManager;
    public ActMoney m_actMoney;
    CountDown m_countDown;
    public int m_money = 0; // ���ׂĂ̂���

    // Start is called before the first frame update
    void Start()
    {
        m_countDown = GetComponent<CountDown>();
        // �����̏�������\��
        m_UIManager.m_pocketText.enabled = true; 
        m_UIManager.m_pocketText.text = m_actMoney.m_pocket.ToString("$000000");
    }

    // Update is called once per frame
    void Update()
    {
        // �J�E���g�_�E���I����
        if (m_countDown.m_countDownFg == false)
        {
            // ���������e�L�X�g�ŕ\��
            m_UIManager.m_pocketText.text = m_actMoney.m_pocket.ToString("$000000");
        }
    }

    //===========================================================
    // ����������
    //===========================================================
    public void Init()
    {
        m_actMoney.m_pocket = 0;                    // ��������0�ɂ���
    }
}
