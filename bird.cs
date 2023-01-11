using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bird : MonoBehaviour
{
    private bool isClick = false;//����Ƿ���
    public float maxdis;

    public LineRenderer right;
    public Transform rightpos;
    public LineRenderer left;
    public Transform leftpos;

    private SpringJoint2D sp;
    Rigidbody2D rg;


    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();

    }
    private void OnMouseDown()//��갴��
    {
        isClick = true;
        rg.isKinematic=true;
    }
    private void OnMouseUp()//���̧��
    {
        isClick = false;
        rg.isKinematic=false;
        Invoke("spenable", 0.1f);
   
    }

    void Update()
    {
        if(isClick)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);//С��λ���水������ƶ�
            transform.position += new Vector3(0, 0, 10);
            if (Vector3.Distance(transform.position, rightpos.position) > maxdis)//λ������ 
            {
                Vector3 pos = (transform.position - rightpos.position).normalized;//��λ������
                pos *= maxdis;//��󳤶�����
                transform.position = pos + rightpos.position;

            }
            line();
        }
    }
    void spenable()
    {
        sp.enabled = false;
    }
    void line()//���ߣ�����ȷ��һ��ֱ��
    {
        right.SetPosition(0,rightpos.position);
        right.SetPosition(1,transform.position);

        left.SetPosition(0,leftpos.position);
        left.SetPosition(1,transform.position);
    }
}
