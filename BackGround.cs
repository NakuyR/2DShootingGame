using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float YscrollSpeed = 1.0f;
    public float XscrollSpeed = 2.0f;
    Material back;

    // Start is called before the first frame update
    void Start()
    {
        back = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float newOffsetY = back.mainTextureOffset.y + YscrollSpeed * Time.deltaTime;
        float newOffsetX = back.mainTextureOffset.x + YscrollSpeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(newOffsetX,newOffsetY);
        back.mainTextureOffset = newOffset;
    }
}
