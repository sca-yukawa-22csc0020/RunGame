using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float jumpForce;
    public float gravityModifiner;
    public bool isOnGround=true;//�n�ʂɂ���
    public bool gameOver=false;//�ŏ��̓Q�[���I�[�o�[�ł͂Ȃ�
    private Animator playerAnim;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        //rb.AddForce(Vector3.up*1000);
        Physics.gravity*= gravityModifiner;
        playerAnim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround=false;//�n�ʂ��痣�ꂽ�I
            playerAnim.SetTrigger("Jump_trig");
            //�W�����v�g���K�[��ݒ聨�W�����v����A�j���Đ�
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //�v���C���[���Ԃ��������肪ground�Ȃ�A�A
        if (collision.gameObject.CompareTag("Ground")) { 
            //�n�ʂɂ��邱�Ƃɂ���
        isOnGround=true;
        }

        //�v���C���[���Ԃ��������肪obstacle�Ȃ�A�A
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver=true;//�Q�[���I�[�o�[�ɂ���
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
        }
    }
}
