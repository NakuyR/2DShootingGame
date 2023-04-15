using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float stage011Time= 0.0f;
    private float stage02Time= 0.0f;
    private float ItemTime = 0.0f;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject Item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stage011Time += Time.deltaTime;
        stage02Time += Time.deltaTime;
        ItemTime += Time.deltaTime;

        if(stage011Time>1.5f)
        {
            Instantiate(enemy1,
            new Vector3(
                Random.Range(-10,10),
                Random.Range(-10,10),0),
                Quaternion.identity);
            stage011Time=0.0f;

        }
        if(stage02Time>10.0f)
        {
            Instantiate(enemy2,
            new Vector3(
                Random.Range(-10,10),
                Random.Range(-10,10),0),
                Quaternion.identity);
            stage02Time=8.5f;

        }
        if(ItemTime>5.0f)
        {
            Instantiate(Item,
            new Vector3(
                Random.Range(-10,10),
                Random.Range(-10,10),0),
                Quaternion.identity);
            ItemTime=0.0f;
        }

    }
}
