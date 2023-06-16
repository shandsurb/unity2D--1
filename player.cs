using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//注释施工，痛苦的记忆回溯
public class player : MonoBehaviour//所有unity脚本都会生成的一个基类，拥有大量公共函数，建议查询unity手册
{
    public float speed;//移动速度
    Rigidbody2D rb;//英文为刚体，属于组件，添加后可对物体施加力
    bool facingRight = true;//是否面向右侧，用以检测是否反转

    bool isGrounded;//检测人物子物品是否接触地面
    public Transform groundCheck;//transform是公众转换？大概是把这个设为可以转变的形式啥的
    public float checkRadius;//跳跃检测圆的半径
    public LayerMask whatIsGround;//layermask即图层，官方手册是指定要在Physics.Raycast中要使用的层
    public float jumpForce;
    // Start is called before the first frame update
    private void Start()//游戏开始时调用
    {
        rb = GetComponent<Rigidbody2D>();//将rb变量设置为刚体，函数返回尖括号中的类型
    }

    // Update is called once per frame
    private void Update()//每一帧都会调用，仍有许多与时间相关的调用函数，可以查询手册参考
    {
        float input = Input.GetAxisRaw("Horizontal");//Horizontal是水平的，该部分旨在检测玩家输入左右键从而确定是否转身
        rb.velocity = new Vector2(input * speed, rb.velocity.y);//velocity是rigidbody的速度矢量函数，后面的y保持不变
        //vector2用于表示2D的向量和点，建议查阅手册

        if (input > 0 && facingRight == false)
        {
            Flip();
        }
        else if (input < 0 && facingRight == true)
        {
            Flip();
        }//上面两个就是简单的转向检测了

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);//应该就是重叠检测了

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }//跳跃判定函数
    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);//注意x部分的负号，下面更新面向右的状态
        facingRight = !facingRight;//将人物进行翻转的函数，vector3是三维的，这里是将transform的localscale部分进行设置（z轴有什么用？）
    }
}
