using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;

    // JohnLemonがトリガーを引いた場合に表示される新しい画像用の別のCanvasGroupとAudio
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;

    // JohnLemonが出口に到達したかどうか
    bool m_IsPlayerAtExit;
    // JohnLemonがキャッチされたかどうか
    bool m_IsPlayerCaught;
    
    float m_Timer;
    bool m_HasAudioPlayed;

    void OnTriggerEnter(Collider other)
    {
        // プレイヤーが出口のトリガーを引いたら
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    // ゲームを終了する方法は2つ
    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            // m_IsPlayerAtExitがtrueの場合、exitBackgroundImageCanvasGroupをフェードイン
            // リスタートはせず終了
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            // m_IsPlayerCaughtがtrueの場合、caughtBackgroundImageCanvasGroupをフェードイン
            // リスタートをしてゲーム再開
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {        
        if (!m_HasAudioPlayed)
        {
            // Playメソッド呼び出し
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            // シーンをリロード
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}