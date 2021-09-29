using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmScript : MonoBehaviour
{
    [SerializeField] float rythm = 0.8f;    //リズム
    [SerializeField] float interval = 0.3f;     //譜面の猶予時間
    [SerializeField] SpriteRenderer player;
    //[SerializeField] ScoreManager scoreMn;

    float count;

    bool isShot1 = false;
    bool isShot2 = false;

    [SerializeField] MoveControler mc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        if (count <= interval / 2 || count >= rythm - interval / 2)
        {
            player.color = new Color(1, 0, 0);
        }
        else
        {
            player.color = new Color(0, 0, 0);
        }

    }

    /// <summary>
    /// クリックで射撃する処理
    /// </summary>
    void Fire()
    {
        //Debug.Log(count);
        count += Time.deltaTime;
        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            //リズムのインターバルの間だけ射撃できる
            if (count <= interval / 2 && isShot1 == false && isShot2 == false)
            {
                Debug.Log("move");
                mc.Move();
                isShot1 = true;

            }
            else if (count >= rythm - interval / 2 && isShot2 == false)
            {
                Debug.Log("move");
                mc.Move();
                isShot2 = true;
            }
            else
            {
                Debug.Log("miss");
            }
        }
        //リズムごとにカウントをリセットする
        if (count >= rythm)
        {
            count = 0f;
        }
        else if (count >= interval / 2)
        {
            isShot1 = false;
            isShot2 = false;
        }
    }
}
