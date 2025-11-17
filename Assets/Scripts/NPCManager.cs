using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : MonoBehaviour
{
    public GameObject npcBasePrefab;    // NPCのベース（動き担当）プレハブ
    public int npcCount = 5;              // 生成数
    public GameObject[] avatarPrefabs;  // アバタープレハブ一覧

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < npcCount; i++)
        {
            CreateNPC();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateNPC()
    {
        GameObject npc = Instantiate(npcBasePrefab);

        // ランダムな配置
        npc.transform.position = new Vector3(
            Random.Range(-10f, 10f),
            Random.Range(-5f, 5f),
            0
        );

        // アバタープレハブをランダムに選ぶ
        GameObject avatarPrefab = avatarPrefabs[Random.Range(0, avatarPrefabs.Length)];

        // アバタープレハブを生成して NPC の子オブジェクトにする
        GameObject avatar = Instantiate(avatarPrefab, npc.transform);

        // 位置調整
        avatar.transform.localPosition = Vector3.zero;
    }
}
