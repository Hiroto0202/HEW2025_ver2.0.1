using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowDust : MonoBehaviour
{
    public float fMoveSpeed = 20.0f;//�e�̃X�s�[�h
    public GameObject BulletObj;//�e�̃I�u�W�F�N�g
    [SerializeField] private float time = 0;//���x
    public InputAction m_aim;//�ǂ̃X�e�B�b�N�̓��͂ɂ��邩�̕ϐ�
    private Gamepad gamepad;//�L�[���͌��m

    void Start()
    {
        m_aim.Enable(); // InputAction ��L����
    }

    // Update is called once per frame
    void Update()
    {
        Key();//�L�[���͌��m
        Vector2 moveInput = m_aim.ReadValue<Vector2>();// move����E�X�e�B�b�N�̓��͂��擾
        Debug.Log("Right Stick Input: " + moveInput);

        if (gamepad.leftTrigger.wasPressedThisFrame)
        {
            Shoot(moveInput);
        }

    }
    //�e���˂̊֐�
    private void Shoot(Vector2 aimDirection)
    {
        Debug.Log("�e����");

        //if (time > 2.0f)
        {
            //****�e�̃C���X�^���X����****
            GameObject cloneObj;                                                       //�N���[���̕ϐ�
            cloneObj = Instantiate(BulletObj, transform.position, Quaternion.identity);//����
            Rigidbody2D rb;                                                            //RigidBody�擾
            Vector2 shootDirection = aimDirection.normalized;                          //�e�̌������v�Z���Đݒ�
            rb = cloneObj.GetComponent<Rigidbody2D>();                                 //���W���擾����
            rb.AddForce(shootDirection * fMoveSpeed, ForceMode2D.Impulse);             //�͂�������
            time = 0.0f;
        }


    }

    void Key()
    {
        // �ڑ����ꂽ�Q�[���p�b�h���擾
        gamepad = Gamepad.current;
        if (gamepad == null)
        {
            Debug.Log("�Q�[���p�b�h���ڑ�����Ă��܂���");
            return;
        }

        // �Q�[���p�b�h�̊e�{�^�����`�F�b�N���A������Ă���ꍇ�Ƀ��O�o��
        if (gamepad.buttonSouth.wasPressedThisFrame) Debug.Log("A�{�^����������܂���");
        if (gamepad.buttonEast.wasPressedThisFrame) Debug.Log("B�{�^����������܂���");
        if (gamepad.buttonWest.wasPressedThisFrame) Debug.Log("X�{�^����������܂���");
        if (gamepad.buttonNorth.wasPressedThisFrame) Debug.Log("Y�{�^����������܂���");

        if (gamepad.leftShoulder.wasPressedThisFrame) Debug.Log("�����{�^����������܂���");
        if (gamepad.rightShoulder.wasPressedThisFrame) Debug.Log("�E���{�^����������܂���");

        if (gamepad.leftTrigger.wasPressedThisFrame) Debug.Log("���g���K�[��������܂���");
        if (gamepad.rightTrigger.wasPressedThisFrame) Debug.Log("�E�g���K�[��������܂���");

        if (gamepad.startButton.wasPressedThisFrame) Debug.Log("�X�^�[�g�{�^����������܂���");
        if (gamepad.selectButton.wasPressedThisFrame) Debug.Log("�Z���N�g�{�^����������܂���");

        if (gamepad.dpad.up.wasPressedThisFrame) Debug.Log("D-Pad �オ������܂���");
        if (gamepad.dpad.down.wasPressedThisFrame) Debug.Log("D-Pad ����������܂���");
        if (gamepad.dpad.left.wasPressedThisFrame) Debug.Log("D-Pad ����������܂���");
        if (gamepad.dpad.right.wasPressedThisFrame) Debug.Log("D-Pad �E��������܂���");
    }
}
