using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    // speedを制御する
    public float speed = 10;


    //物理演算でキャラクターが動く度に呼ばれる処理
    void FixedUpdate()
    {

        // 入力をxとzに代入
        float x = Input.GetAxis("Horizonal");
        float z = Input.GetAxis("Vertical");

        // 物理演算機能の追加
        // 同一のGameObjectが持つRigidbodyコンポーネントを取得
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        // rigidbodyのx軸（横）とz軸（奥）にオブジェクトに力を加える
        rigidbody.AddForce(x, 0, z);
    }

    //{から}内に記述した処理を毎フレーム更新時に呼び出し
    void Update()
    {

    }
}