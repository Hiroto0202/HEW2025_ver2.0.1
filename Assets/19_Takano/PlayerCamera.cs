using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform m_target; // �v���C���[���w��
    public float m_smoothSpeed = 0.125f; // �J�����̒Ǐ]���x
    public Vector3 m_offset; // �J�����̈ʒu�����p

    void LateUpdate()//�t���[���̍Ō�ɏ���
    {
        if (m_target != null)
        {
            //�v���C���[�̍��W���猩�₷���ʒu�ɕύX
            Vector3 m_desiredPosition = m_target.position + m_offset;
            //���炩�ɃJ�������ړ�
            Vector3 m_smoothedPosition = Vector3.Lerp(transform.position, m_desiredPosition, m_smoothSpeed);
            //�J�����ʒu���ړ�
            transform.position = m_smoothedPosition;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_target.position);

    }
}
