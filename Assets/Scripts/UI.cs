using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Image HPBarre;
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] GameObject deathTxt;
    [SerializeField] Player player;

    private void Update()
    {
        if (player)
        {
            FillHPBarre();
            DisplayScore();

            gameObject.SetActive(true);
            deathTxt.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
            deathTxt.SetActive(true);

        }

    }

    void FillHPBarre()
    {
        HPBarre.fillAmount = player.currentHP / player.maxHp;
    }

    void DisplayScore()
    {
        scoreTxt.text = player.score.ToString();
    }
}
