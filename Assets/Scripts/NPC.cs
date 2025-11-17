//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed = 2f;    // NPCが移動する速度
    public float changeTargetInterval = 3f;  // 何秒ごとに新しい目的地に切り替えるか
    private Vector3 targetPos;  // 現在の目的地
    private float timer = 0f;   // 時間計測

    // Start is called before the first frame update
    void Start()
    {
        SetNewTarget(); // 最初の目的地を決める
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;    // 経過時間を加算

        // 一定時間経過したら新しい目的地へ
        if (timer > changeTargetInterval)
        {
            timer = 0f;
            SetNewTarget();
        }

        // 目的地に向かって移動する
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    // 新しい徘徊ポイントをランダムで設定する
    void SetNewTarget()
    {
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-5f, 5f);

        targetPos = new Vector3(x, y, transform.position.z);
    }
}
