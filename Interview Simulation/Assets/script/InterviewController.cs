using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterviewController : MonoBehaviour
{
    public Text resultText;  // 結果を表示するテキストコンポーネントの参照

    private GameManager gameManager;  // GameManagerの参照

    void Start()
    {
        gameManager = GameManager.Instance;  // シングルトンインスタンスからGameManagerを取得
    }

    public void CheckInterviewResult()
    {
        if (gameManager.academicStatus <= 300)
        {
            resultText.text = "不合格";
        }
        else
        {
            if (Random.value < 0.2)  // 20%の確率で不合格
            {
                resultText.text = "不合格";
            }
            else  // 80%の確率で合格
            {
                resultText.text = "おめでとうございます。次の選考にお進みください";
            }
        }
    }
}
