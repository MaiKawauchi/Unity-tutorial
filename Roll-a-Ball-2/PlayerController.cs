using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    // public変数を作成するとその変数は編集可能なプロパティとして
    // インスペクターに表示され、全ての変更をエディタで行うことができる
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    // スクリプトがアクティブになる最初のフレームで呼び出される
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        // テキストに設定する値が必要
        SetCountText();
        winText.text = "";
    }

    //物理演算処理
    void FixedUpdate()
    {
        // 水平軸
        float moveHorizontal = Input.GetAxis("Horizontal");
        // 垂直軸
        float moveVertical = Input.GetAxis("Vertical");

        // ボールに加える力の方向を生成する
        // x -> moveHorizonal, z -> moveVertical
        Vector3 movement = new Vector3(moveHorizontal,0.0f, moveVertical);

        // アタッチされたRigidbodyコンポーネントに
        // rbという名前の変数を介してアクセスする
        rb.AddForce(movement * speed);
    }

    // PlayerゲームオブジェクトがTriggerになっているColliderに
    // 接触した瞬間に呼ばれる
    // 接触したTriggerへの参照が引数として渡される
    // この参照により接触したColliderを取得できる
    void OnTriggerEnter(Collider other)
    {
        // tagの値からゲームオブジェクトが何か特定
        // タグの値を効率よく比較
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // ゲームオブジェクトをアクティブ化/非アクティブにする
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win !";
        }
    }
}