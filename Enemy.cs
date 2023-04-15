using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemyHP = 20.0f;
    private float speed = 0.2f;
    Transform playerTr;
    Player player;
    public GameObject child;
    private PlayerChild tempchild;
    public GameObject deadEffect;
    CameraShake camera;
    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
        child = GameObject.FindWithTag("PlayerChild");
        tempchild =child.GetComponent<PlayerChild>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,playerTr.position,Time.deltaTime*speed);
        transform.Rotate(Vector3.forward*speed*200.0f*Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Bullet")
        {
            Debug.Log("EnemyHP:"+EnemyHP);
            EnemyHP -=1f;
        }
        if(EnemyHP<0.0f)
        {
            Debug.Log("사망");
            Instantiate(deadEffect,transform.position,Quaternion.identity);
            camera.VibrateForTime(0.05f);
            player.ScoreUP();
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag=="Player")
        {
            if(tempchild.increaseCount > 0 ){
                tempchild.HitEnemy();
                Debug.Log("플레이어와 충돌, 아이템 효과 삭제");
                Instantiate(deadEffect,transform.position,Quaternion.identity);
                camera.VibrateForTime(0.05f);
                Destroy(this.gameObject);
            }
            else{
                player.PlayerHPMinus();
                Debug.Log("플레이어와 충돌");
                Instantiate(deadEffect,transform.position,Quaternion.identity);
                camera.VibrateForTime(0.05f);   
                Destroy(this.gameObject);
            }
        }
    }
}
