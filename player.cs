using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ע��ʩ����ʹ��ļ������
public class player : MonoBehaviour//����unity�ű��������ɵ�һ�����࣬ӵ�д������������������ѯunity�ֲ�
{
    public float speed;//�ƶ��ٶ�
    Rigidbody2D rb;//Ӣ��Ϊ���壬�����������Ӻ�ɶ�����ʩ����
    bool facingRight = true;//�Ƿ������Ҳ࣬���Լ���Ƿ�ת

    bool isGrounded;//�����������Ʒ�Ƿ�Ӵ�����
    public Transform groundCheck;//transform�ǹ���ת��������ǰ������Ϊ����ת�����ʽɶ��
    public float checkRadius;//��Ծ���Բ�İ뾶
    public LayerMask whatIsGround;//layermask��ͼ�㣬�ٷ��ֲ���ָ��Ҫ��Physics.Raycast��Ҫʹ�õĲ�
    public float jumpForce;
    // Start is called before the first frame update
    private void Start()//��Ϸ��ʼʱ����
    {
        rb = GetComponent<Rigidbody2D>();//��rb��������Ϊ���壬�������ؼ������е�����
    }

    // Update is called once per frame
    private void Update()//ÿһ֡������ã����������ʱ����صĵ��ú��������Բ�ѯ�ֲ�ο�
    {
        float input = Input.GetAxisRaw("Horizontal");//Horizontal��ˮƽ�ģ��ò���ּ�ڼ������������Ҽ��Ӷ�ȷ���Ƿ�ת��
        rb.velocity = new Vector2(input * speed, rb.velocity.y);//velocity��rigidbody���ٶ�ʸ�������������y���ֲ���
        //vector2���ڱ�ʾ2D�������͵㣬��������ֲ�

        if (input > 0 && facingRight == false)
        {
            Flip();
        }
        else if (input < 0 && facingRight == true)
        {
            Flip();
        }//�����������Ǽ򵥵�ת������

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);//Ӧ�þ����ص������

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }//��Ծ�ж�����
    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);//ע��x���ֵĸ��ţ�������������ҵ�״̬
        facingRight = !facingRight;//��������з�ת�ĺ�����vector3����ά�ģ������ǽ�transform��localscale���ֽ������ã�z����ʲô�ã���
    }
}
