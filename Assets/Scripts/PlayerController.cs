using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float jumpForce;
    public float gravityModifiner;
    public bool isOnGround=true;//地面にいる
    public bool gameOver=false;//最初はゲームオーバーではない
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
            isOnGround=false;//地面から離れた！
            playerAnim.SetTrigger("Jump_trig");
            //ジャンプトリガーを設定→ジャンプするアニメ再生
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //プレイヤーがぶつかった相手がgroundなら、、
        if (collision.gameObject.CompareTag("Ground")) { 
            //地面にいることにする
        isOnGround=true;
        }

        //プレイヤーがぶつかった相手がobstacleなら、、
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver=true;//ゲームオーバーにする
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
        }
    }
}
