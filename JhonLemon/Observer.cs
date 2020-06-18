using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    // プレイヤーのキャラクターを検出
    public Transform player;
    public GameEnding gameEnding;
    // キャラクターがトリガー内にあるかどうか
    bool m_IsPlayerInRange;

    // 呼び出されるたびに、JohnLemonが実際に範囲内にあることを確認
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    // JohnLemonがトリガーを離れたときを検出
    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        // プレイヤーキャラクターが実際に範囲内にいる場合にのみ、視線を確認
        if (m_IsPlayerInRange)
        {
            // レイキャスト
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            // outパラメータを使用して情報を返す
            if (Physics.Raycast(ray, out raycastHit))
            {
                // プレーヤーのキャラクターが範囲内にあることを識別し,何かがヒットしたかどうかを知る
                if (raycastHit.collider.transform == player)
                {
                    // コライダーがプレイヤーキャラクターであったかどうか
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
