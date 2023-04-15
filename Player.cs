using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    
    //총알 발사
    private Transform spPoint;
    public GameObject bulletPrefab;
    public float bulletCollTime=0.23f;
    private float bulTime=0.0f;
    //점수 UI
    public Text ScoreText;
    private int ScorePoint = 0;
    //HP
    public float PlayerHP = 100.0f;
    public Image Hpbar;
    void Start()

    
    {
        spPoint = GameObject.Find("spPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        #region 플레이어 이동
        if(Input.GetKey(KeyCode.A))
        {
            if(Get_Pos().x>-8.6f)
            {
                Move_Pos(Vector3.left*moveSpeed*Time.deltaTime);
            }
            
        }
        if(Input.GetKey(KeyCode.D))
        {
            if(Get_Pos().x<8.6f)
            {
                Move_Pos(Vector3.right*moveSpeed*Time.deltaTime);
            }
        }
        if(Input.GetKey(KeyCode.W))
        {
            if(Get_Pos().y<4.5f)
            {
                Move_Pos(Vector3.up*moveSpeed*Time.deltaTime);
            }
        }
        if(Input.GetKey(KeyCode.S))
        {
            if(Get_Pos().y>-4.5f)
            {
                Move_Pos(Vector3.down*moveSpeed*Time.deltaTime);
            }
        }
        #endregion
        #region 플레이어 회전
        Vector3 mPosition = Input.mousePosition;
        Vector3 oPosition = transform.position;
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;
        float rotateDegree = Mathf.Atan2(dy,dx)*Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f,0f,rotateDegree);
        #endregion
        #region 총알 발사
        bulTime += Time.deltaTime;
        if (bulTime > bulletCollTime)
        {
            if(Input.GetMouseButton(0))
            {
                Instantiate(bulletPrefab,spPoint.position,spPoint.rotation);
                bulTime = 0.0f;
            }
        }
        #endregion

    }
    public void ScoreUP()
    {
        ScorePoint +=100;
        ScoreText.text = ScorePoint.ToString();
    }
    public void PlayerHPMinus()
    {
        PlayerHP-=10.0f;
        if (PlayerHP < 1)
        {
            SceneManager.LoadScene("EndScene");
        }
        Hpbar.fillAmount = PlayerHP/100.0f;
    }
    public void HpUp()
    {
        if(PlayerHP >= 100.0f) return;
        PlayerHP +=10;
        Hpbar.fillAmount = PlayerHP/100.0f;
    }
    private void Move_Pos(Vector3 move){this.transform.position += move;}
    private Vector3 Get_Pos(){return this.transform.position;}
}
