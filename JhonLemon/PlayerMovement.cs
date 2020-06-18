using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* ユーザー入力を受け取り、それをキャラクターの動きに変換する */
public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;                // 回転速度

    Animator m_Animator;                         // Animatorコンポーネントへの参照を取得
    Rigidbody m_Rigidbody;                       // Rigidbodyコンポーネントへの参照を取得
    AudioSource m_AudioSource;                   // Audioコンポーネントへの参照を取得
    Vector3 m_Movement;                          // 移動ベクトル
    Quaternion m_Rotation = Quaternion.identity; // 四元数:回転を格納

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }


    // Updateはフレームごとに呼び出される
    // FixedUpdateは物理システムが発生した衝突やその他の相互作用を解決する前に呼び出される
    void FixedUpdate()
    {
        // キーボードの特定のキーの値を確認する
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        // 水平入力があるかどうか.ゼロ以外の場合メソッドはtrueを返す
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        // 垂直入力があるかどうか.ゼロ以外の場合メソッドはtrueを返す
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        // Axesを単一のブール値に結合
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        m_Animator.SetBool("IsWalking", isWalking);

        // 歩いていれば
        if (isWalking)
        {
            // 音を鳴らす
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        // 1秒あたりの変更を処理
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        // 指定されたパラメーターの方向を向いた回転を作成
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    // ルートモーション:移動と回転を別々に適用
    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
