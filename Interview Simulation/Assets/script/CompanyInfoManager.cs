using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CompanyInfo
{
    public string companyName;
    public int academic; // �w�̓X�e�[�^�X
    public int communication; // �R�~���j�P�[�V�����\�̓X�e�[�^�X
    public int cooperation; // �����X�e�[�^�X
    public int responsibility; // �ӔC���X�e�[�^�X
    public int proactivity; // �ϋɐ��X�e�[�^�X
    public int jobHunting; // �A���o���X�e�[�^�X
}

public class CompanyInfoManager : MonoBehaviour
{
    public CompanyInfo[] companies; // ��Ə��̔z��
    public Text[] companyTexts; // �e��Ə���\������Text�R���|�[�l���g�̔z��
    public Text[] newCompanyTexts; // �V�����e�L�X�g�z��

    public int slectcomp; //���ݑI�𒆂̉�Дԍ�

    [SerializeField, Header("�Q�[���}�l�[�W���[")]
    GameManager gameManager;

    [SerializeField, Header("ES�ʉ߃L�����o�X")]
    private GameObject ESpassCanvas;

    void Start()
    {
        if (companies.Length != companyTexts.Length || companies.Length != newCompanyTexts.Length)
        {
            Debug.LogError("��Џ��ƃe�L�X�g�̐�����v���܂���B");
            return;
        }

        for (int i = 0; i < companies.Length; i++)
        {
            companyTexts[i].text = $"{companies[i].companyName}\n" +
                                   $"�w�̓X�e�[�^�X: {companies[i].academic}\n" +
                                   $"�R�~����: {companies[i].communication}\n" +
                                   $"�����X�e�[�^�X: {companies[i].cooperation}\n" +
                                   $"�ӔC���X�e�[�^�X: {companies[i].responsibility}\n" +
                                   $"�ϋɐ��X�e�[�^�X: {companies[i].proactivity}\n" +
                                   $"�A���o���X�e�[�^�X: {companies[i].jobHunting}";

            newCompanyTexts[i].text = $"{companies[i].companyName}\n" +
                                   $"�w�̓X�e�[�^�X: {companies[i].academic}\n" +
                                   $"�R�~����: {companies[i].communication}\n" +
                                   $"�����X�e�[�^�X: {companies[i].cooperation}\n" +
                                   $"�ӔC���X�e�[�^�X: {companies[i].responsibility}\n" +
                                   $"�ϋɐ��X�e�[�^�X: {companies[i].proactivity}\n" +
                                   $"�A���o���X�e�[�^�X: {companies[i].jobHunting}";
        }
    }

    public void SelectCompany(int CompanyNum)
    {
        slectcomp = CompanyNum;
    }

    public void GoIntern()
    {
        if (!(companies[slectcomp].academic <= gameManager.academicStatus))
        {
            Debug.Log("�w�̓X�e�[�^�X�𖞂����Ă��Ȃ��̂ŃC���^�[���ɎQ���ł��܂���");
            return;
        }
        if (!(companies[slectcomp].communication <= gameManager.communicationStatus))
        {
            Debug.Log("�R�~���͂𖞂����Ă��Ȃ��̂ŃC���^�[���ɎQ���ł��܂���");
            return;
        }
        if (!(companies[slectcomp].cooperation <= gameManager.cooperationStatus))
        {
            Debug.Log("�����X�e�[�^�X�𖞂����Ă��Ȃ��̂ŃC���^�[���ɎQ���ł��܂���");
            return;
        }
        if (!(companies[slectcomp].responsibility <= gameManager.responsibilityStatus))
        {
            Debug.Log("�ӔC���X�e�[�^�X�𖞂����Ă��Ȃ��̂ŃC���^�[���ɎQ���ł��܂���");
            return;
        }
        if (!(companies[slectcomp].proactivity <= gameManager.proactivityStatus))
        {
            Debug.Log("�ϋɐ��X�e�[�^�X�𖞂����Ă��Ȃ��̂ŃC���^�[���ɎQ���ł��܂���");
            return;
        }
        if (!(companies[slectcomp].jobHunting <= gameManager.jobHuntingExperienceStatus))
        {
            Debug.Log("�A���o���X�e�[�^�X�𖞂����Ă��Ȃ��̂ŃC���^�[���ɎQ���ł��܂���");
            return;
        }

        //�C���^�[���ɍs������
        Debug.Log("�C���^�[���ɎQ���ł��܂�");
        ESpassCanvas.SetActive(true);
    }
}