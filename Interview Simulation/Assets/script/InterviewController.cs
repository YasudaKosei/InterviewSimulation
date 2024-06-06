using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterviewController : MonoBehaviour
{
    public Text resultText;  // ���ʂ�\������e�L�X�g�R���|�[�l���g�̎Q��

    private GameManager gameManager;  // GameManager�̎Q��

    void Start()
    {
        gameManager = GameManager.Instance;  // �V���O���g���C���X�^���X����GameManager���擾
    }

    public void CheckInterviewResult()
    {
        if (gameManager.academicStatus <= 300)
        {
            resultText.text = "�s���i";
        }
        else
        {
            if (Random.value < 0.2)  // 20%�̊m���ŕs���i
            {
                resultText.text = "�s���i";
            }
            else  // 80%�̊m���ō��i
            {
                resultText.text = "���߂łƂ��������܂��B���̑I�l�ɂ��i�݂�������";
            }
        }
    }
}
