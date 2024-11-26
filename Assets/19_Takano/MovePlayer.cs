using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public float speed = 5.0f;//�v���C���[�̑��x
    Vector2 playerMoveVec;//�v���C���[�̐i�ތ���
    Rigidbody2D player_rb;//�v���C���[�̕������Z�̃R���|�[�l���g


    void Start()
    {
        //RigitBody���擾
        player_rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //�X�e�B�b�N�̓ǂݍ���
        playerMoveVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //���X�e�B�b�N�̓������v�Z
        player_rb.velocity = playerMoveVec * speed;
    }
}
