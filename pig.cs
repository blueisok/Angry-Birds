using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class pig : MonoBehaviour
{
    public float maxspeed;
    public float minspeed;
    private SpriteRenderer rend;
    public Sprite hurt;
    public GameObject boom;
    public GameObject score;

    private void Awake()
    {
        rend= GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > maxspeed)//小猪死亡
        {
            Destroy(gameObject);
            //死亡特效
            Instantiate(boom,transform.position, Quaternion.identity);
            //得分特效
            GameObject go=Instantiate(score,transform.position+new Vector3(0,0.5f,0), Quaternion.identity);
            Destroy(go,1.5f);
        }
        else if (collision.relativeVelocity.magnitude > minspeed && collision.relativeVelocity.magnitude < maxspeed)//小猪受伤
        {
            rend.sprite = hurt;
        }
    }
}
