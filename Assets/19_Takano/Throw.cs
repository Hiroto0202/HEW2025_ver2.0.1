using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.InputSystem;

public class Throw : MonoBehaviour
{

    public float m_fMoveSpeed = 20.0f;//�e�̃X�s�[�h
    public GameObject m_BulletObj;//�e�̃I�u�W�F�N�g
    [SerializeField] private float m_time = 0;//���x
    public InputAction m_aim;//�ǂ̃X�e�B�b�N�̓��͂ɂ��邩�̕ϐ�
    private Gamepad m_gamepad;//�L�[���͌��m
    public float m_deceleration = 0.98f; // �e�̌������i�����\�j

    void Start()
    {
        m_aim.Enable(); // InputAction ��L����
    }

    // Update is called once per frame
    void Update()
    {
        Key();//�L�[���͌��m
        Vector2 m_moveInput = m_aim.ReadValue<Vector2>();// move����E�X�e�B�b�N�̓��͂��擾
        Debug.Log("Right Stick Input: " + m_moveInput);

        if (m_gamepad.leftTrigger.wasPressedThisFrame)
        {
            Shoot(m_moveInput);
        }

    }
    //�e���˂̊֐�
    private void Shoot(Vector2 aimDirection)
    {
        Debug.Log("�e����");

        //if (time > 2.0f)
        {
            //****�e�̃C���X�^���X����****
            GameObject m_cloneObj;                                                       //�N���[���̕ϐ�
            m_cloneObj = Instantiate(m_BulletObj, transform.position, Quaternion.identity);//����
            Rigidbody2D rb;                                                            //RigidBody�擾
            if (m_cloneObj != null)
            {
                Vector2 shootDirection = aimDirection.normalized;                          //�e�̌������v�Z���Đݒ�
                rb = m_cloneObj.GetComponent<Rigidbody2D>();                                 //���W���擾����
                rb.AddForce(shootDirection * m_fMoveSpeed, ForceMode2D.Impulse);             //�͂�������
                                                                                           // �e�̑��x�����X�Ɍ���������
            }
            m_time = 0.0f;
        }


    }

    void Key()
    {
        // �ڑ����ꂽ�Q�[���p�b�h���擾
        m_gamepad = Gamepad.current;
        if (m_gamepad == null)
        {
            Debug.Log("�Q�[���p�b�h���ڑ�����Ă��܂���");
            return;
        }

        // �Q�[���p�b�h�̊e�{�^�����`�F�b�N���A������Ă���ꍇ�Ƀ��O�o��
        if (m_gamepad.buttonSouth.wasPressedThisFrame) Debug.Log("A�{�^����������܂���");
        if (m_gamepad.buttonEast.wasPressedThisFrame) Debug.Log("B�{�^����������܂���");
        if (m_gamepad.buttonWest.wasPressedThisFrame) Debug.Log("X�{�^����������܂���");
        if (m_gamepad.buttonNorth.wasPressedThisFrame) Debug.Log("Y�{�^����������܂���");

        if (m_gamepad.leftShoulder.wasPressedThisFrame) Debug.Log("�����{�^����������܂���");
        if (m_gamepad.rightShoulder.wasPressedThisFrame) Debug.Log("�E���{�^����������܂���");

        if (m_gamepad.leftTrigger.wasPressedThisFrame) Debug.Log("���g���K�[��������܂���");
        if (m_gamepad.rightTrigger.wasPressedThisFrame) Debug.Log("�E�g���K�[��������܂���");

        if (m_gamepad.startButton.wasPressedThisFrame) Debug.Log("�X�^�[�g�{�^����������܂���");
        if (m_gamepad.selectButton.wasPressedThisFrame) Debug.Log("�Z���N�g�{�^����������܂���");

        if (m_gamepad.dpad.up.wasPressedThisFrame) Debug.Log("D-Pad �オ������܂���");
        if (m_gamepad.dpad.down.wasPressedThisFrame) Debug.Log("D-Pad ����������܂���");
        if (m_gamepad.dpad.left.wasPressedThisFrame) Debug.Log("D-Pad ����������܂���");
        if (m_gamepad.dpad.right.wasPressedThisFrame) Debug.Log("D-Pad �E��������܂���");
    }
}
