

using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    // Transform のコンポーネントを持つオブジェクトを登録するため Transform の変数を定義
    public Transform target;  // ターゲットへの参照
    private Vector3 offset;   // 相対座標

    void Start()
    {
        // offsetへ相対距離を取得
        offset = GetComponent<Transform>().position - target.position;
    }

    void Update()
    {
        // 自分の座標に target の座標に相対座標を足した値を設定する
        GetComponent<Transform>().position = target.position + offset;
    }
}