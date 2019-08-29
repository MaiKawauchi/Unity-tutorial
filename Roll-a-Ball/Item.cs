using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    // 判定のみのTriggerとの接触判定. 接触時に呼ばれるコールバック
    void OnTriggerEnter(Collider hit)
    {
        // 接触対象が Player タグの場合
        if (hit.CompareTag("Player"))
        {
            // このコンポーネントを持つGameObjectを破棄
            Destroy(gameObject);
        }
    }
}