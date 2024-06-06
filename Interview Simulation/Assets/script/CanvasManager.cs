using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // キャンバスの参照
    public GameObject mainCanvas;
    public GameObject internshipCanvas;

    // ボタンを押した時に呼び出されるメソッド
    public void ChangeToInternshipCanvas()
    {
        // メインキャンバスを非表示にする
        mainCanvas.SetActive(false);
        // インターンシップキャンバスを表示する
        internshipCanvas.SetActive(true);
    }

    // 初期化時にメインキャンバスのみ表示し、他は非表示にする
    void Start()
    {
        mainCanvas.SetActive(true);
        internshipCanvas.SetActive(false);
    }
}
