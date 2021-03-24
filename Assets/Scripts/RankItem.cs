using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RankItem : MonoBehaviour
{
    [SerializeField] private Image[] rankHighImgs;
    [SerializeField] private Text name;
    [SerializeField] private Text powerText;

    public void SetData(BattleButton.PlayerDataInfo info)
    {
        name.text = info.Nickname;
        powerText.text = info.Trophy;
        for (int i = 0; i < rankHighImgs.Length; i++)
        {
            rankHighImgs[i].gameObject.SetActive(info.rank == i + 1);
        }
    }


}
