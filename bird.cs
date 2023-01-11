using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bird : MonoBehaviour
{
    private bool isClick = false;//鼠标是否点击
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
    private void OnMouseDown()//鼠标按下
    {
        isClick = true;
        rg.isKinematic=true;
    }
    private void OnMouseUp()//鼠标抬起
    {
        isClick = false;
        rg.isKinematic=false;
        Invoke("spenable", 0.1f);
   
    }

    void Update()
    {
        if(isClick)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);//小鸟位置随按下鼠标移动
            transform.position += new Vector3(0, 0, 10);
            if (Vector3.Distance(transform.position, rightpos.position) > maxdis)//位置限制 
            {
                Vector3 pos = (transform.position - rightpos.position).normalized;//单位化向量
                pos *= maxdis;//最大长度向量
                transform.position = pos + rightpos.position;

            }
            line();
        }
    }
    void spenable()
    {
        sp.enabled = false;
    }
    void line()//划线，两点确定一条直线
    {
        right.SetPosition(0,rightpos.position);
        right.SetPosition(1,transform.position);

        left.SetPosition(0,leftpos.position);
        left.SetPosition(1,transform.position);
    }
}
