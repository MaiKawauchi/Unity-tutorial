using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    // Textコンポーネントへの参照
    public UnityEngine.UI.Text scoreLabel;
    public GameObject winnerLabelObject;

    public void Update()
    {
        // すべての障害物 (Item) の総数
        int count = GameObject.FindGameObjectsWithTag("Item").Length;

        // 取得したItem数をtextに代入
        scoreLabel.text = count.ToString();

        // すべての障害物 (Item) に衝突した場合
        if (count == 0)
        {
            // オブジェクトをアクティブにする
            winnerLabelObject.SetActive(true);
        }
    }
}
