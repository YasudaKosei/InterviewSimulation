using UnityEngine;
using UnityEngine.UI;

public class InternshipApplication : MonoBehaviour
{
    // UI�Őݒ肷��K�v�̂���t�B�[���h
    public GameManager gameManager; // GameManager�X�N���v�g�ւ̎Q��
    public GameObject errorPanel; // �����𖞂����Ȃ��Ƃ��ɕ\������G���[�p�l��
    public Canvas internshipCanvas; // �C���^�[���V�b�v�L�����o�X�ւ̎Q��

    // �{�^���������ꂽ�Ƃ��ɌĂяo����郁�\�b�h
    public void OnApplyButtonClick()
    {
        // �Œ�X�e�[�^�X�𖞂����Ă��邩�`�F�b�N
        if (CanApplyToInternship())
        {
            // �����𖞂����Ă���΃C���^�[���V�b�v�L�����o�X�Ɉړ�
            internshipCanvas.enabled = true;
        }
        else
        {
            // �����𖞂����Ȃ���΃G���[�p�l����\��
            errorPanel.SetActive(true);
        }
    }

    // �v���C���[���C���^�[���V�b�v�ւ̉�������𖞂����Ă��邩���`�F�b�N���郁�\�b�h
    private bool CanApplyToInternship()
    {
        // �����Ɋe��Ƃ̍Œ�X�e�[�^�X�ƃv���C���[�̃X�e�[�^�X���r���郍�W�b�N��ǉ�
        // �ȉ��̓_�~�[�̏����`�F�b�N�ł�
        if (gameManager.academicStatus >= 50 &&
            gameManager.communicationStatus >= 30 &&
            gameManager.cooperationStatus >= 20 &&
            gameManager.responsibilityStatus >= 40 &&
            gameManager.proactivityStatus >= 30 &&
            gameManager.jobHuntingExperienceStatus >= 20)
        {
            return true;
        }
        return false;
    }

    // �G���[�p�l������郁�\�b�h
    public void CloseErrorPanel()
    {
        errorPanel.SetActive(false);
    }

    void Start()
    {
        // �Q�[���J�n���ɃG���[�p�l���ƃC���^�[���V�b�v�L�����o�X���\���ɂ���
        errorPanel.SetActive(false);
        internshipCanvas.enabled = false;
    }
}
