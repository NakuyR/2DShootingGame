using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChild : MonoBehaviour
{
    [SerializeField]
    private float speed = 60.0f;
    [SerializeField]
    public int childCnt = 2;
    [SerializeField]
    private GameObject child = null;
    [SerializeField]
    private float distance = 1.2f;
    public int increaseCount = 0;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void CreateChild()
    {
        increaseCount += 1;
        if(increaseCount>2)
        {
            Debug.Log("플레이어 HP 증가");
            player.HpUp();
            increaseCount = 3;
            return;
        }
        if(increaseCount <=2)
        {
            GameObject[] playerChilds = GameObject.FindGameObjectsWithTag("PlayerChildObj");
            childCnt+=playerChilds.Length;
            for(int i=0;i<playerChilds.Length;i++)
            {
                Destroy(playerChilds[i]);
            }
        }
        for(int i=0;i<childCnt;++i)
        {
            GameObject go =Instantiate(child);
            float angle = 360.0f/childCnt;
            float newY = Mathf.Sin(i*angle*Mathf.Deg2Rad);
            float newX = Mathf.Cos(i*angle*Mathf.Deg2Rad);

            newY=(newY*distance)+this.transform.position.y;
            newX=(newX*distance)+this.transform.position.x;
            go.transform.position = new Vector3(newX,newY,0.0f);
            go.transform.parent = this.transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward,speed*Time.fixedDeltaTime);
    }
    
    public void HitEnemy(){
        GameObject[] playerChilds = GameObject.FindGameObjectsWithTag("PlayerChildObj");
        for(int i=0;i<playerChilds.Length;i++)
            {
                Destroy(playerChilds[i].gameObject);
            }
        increaseCount=0;
        childCnt=2;
    }
}
