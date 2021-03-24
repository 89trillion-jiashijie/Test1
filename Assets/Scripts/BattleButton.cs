using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Scripts.ArenaRank;
using UnityEngine;
using UnityEngine.UI;

public class BattleButton : MonoBehaviour
{
    [SerializeField] private GameObject show;
    [SerializeField] public GameObject close;
    [SerializeField] private RankItem obj;
    [SerializeField] private Transform parent;
    [SerializeField] private Text countDownText;
    [SerializeField] private GameObject bottom;

    [SerializeField] private RankListAdapter _rankListAdapter;

    public int sumTime = 1600;

    private void Start()
    {
        StartCoroutine("CountDown");
    }

    #region 计时器
    IEnumerator CountDown()
    {
        while (sumTime >= 0)
        {
            sumTime--;
            countDownText.text = "Time:" + TimeLeftFormat(sumTime);
            if (sumTime == 0)
            {
                yield break;
            }
            else if (sumTime > 0)
            {
                yield return new WaitForSeconds(1);
            }
        }
    }
    
    public static string TimeLeftFormat(int seconds)
    {
        int days = seconds / 60 / 60 / 24;
        int hrs = seconds / 60 / 60 % 24;
        int min = seconds / 60 % 60;
        int sec = seconds % 60;

        if (days > 0)
        {
            if (hrs > 0)
            {
                return $"{days:0}d {hrs:0}h";
            }

            return $"{days:0}d";
        }
        else if (hrs > 0)
        {
            if (min > 0)
            {
                return $"{hrs:0}h {min:0}m";
            }

            return $"{hrs:0}h";
        }
        else if (min > 0)
        {
            if (sec > 0)
            {
                return $"{min:0}m {sec:0}s";
            }

            return $"{min:0}m";
        }
        else
        {
            return $"{sec:0}s";
        }
    }
    
    #endregion
    
   
    public void ShowList()
    {
        show.gameObject.SetActive(false);
        close.gameObject.SetActive(true);
        
        InitData();
    }
    
    public void CloseList()
    {
        parent.gameObject.SetActive(false);
        show.gameObject.SetActive(true);
        close.gameObject.SetActive(false);
        bottom.gameObject.SetActive(false);
    }

    List<PlayerDataInfo> rankItemData=new List<PlayerDataInfo>();
    private void AddTempData()
    {
        
        rankItemData.Add(JsonConvert.DeserializeObject<PlayerDataInfo>("{\"uid\":3716954261, \"nickName\":\"Player5278\",\"avatar\":\"14\",\"trophy\":\"6789\",\"countDownTime\":\"100\",\"rank\":\"1\"}"));
        rankItemData.Add(JsonConvert.DeserializeObject<PlayerDataInfo>("{\"uid\":3716954261, \"nickName\":\"Player5278\",\"avatar\":\"14\",\"trophy\":\"6789\",\"countDownTime\":\"100\",\"rank\":\"1\"}"));
        rankItemData.Add(JsonConvert.DeserializeObject<PlayerDataInfo>("{\"uid\":3716954261, \"nickName\":\"Player5278\",\"avatar\":\"14\",\"trophy\":\"6789\",\"countDownTime\":\"100\",\"rank\":\"1\"}"));
        rankItemData.Add(JsonConvert.DeserializeObject<PlayerDataInfo>("{\"uid\":3716954261, \"nickName\":\"Player5278\",\"avatar\":\"14\",\"trophy\":\"6789\",\"countDownTime\":\"100\",\"rank\":\"1\"}"));
        rankItemData.Add(JsonConvert.DeserializeObject<PlayerDataInfo>("{\"uid\":3716954261, \"nickName\":\"Player5278\",\"avatar\":\"14\",\"trophy\":\"6789\",\"countDownTime\":\"100\",\"rank\":\"1\"}"));
        rankItemData.Add(JsonConvert.DeserializeObject<PlayerDataInfo>("{\"uid\":3716954261, \"nickName\":\"Player5278\",\"avatar\":\"14\",\"trophy\":\"6789\",\"countDownTime\":\"100\",\"rank\":\"1\"}"));
        rankItemData.Add(JsonConvert.DeserializeObject<PlayerDataInfo>("{\"uid\":3716954261, \"nickName\":\"Player5278\",\"avatar\":\"14\",\"trophy\":\"6789\",\"countDownTime\":\"100\",\"rank\":\"1\"}"));
        rankItemData.Add(JsonConvert.DeserializeObject<PlayerDataInfo>("{\"uid\":3716954261, \"nickName\":\"Player5278\",\"avatar\":\"14\",\"trophy\":\"6789\",\"countDownTime\":\"100\",\"rank\":\"1\"}"));
        rankItemData.Add(JsonConvert.DeserializeObject<PlayerDataInfo>("{\"uid\":3716954261, \"nickName\":\"Player\",\"avatar\":\"14\",\"trophy\":\"6789\",\"countDownTime\":\"100\",\"rank\":\"1\"}"));
        rankItemData.Add(JsonConvert.DeserializeObject<PlayerDataInfo>("{\"uid\":3716954261, \"nickName\":\"Player\",\"avatar\":\"14\",\"trophy\":\"6789\",\"countDownTime\":\"100\",\"rank\":\"1\"}"));

    }
    
    public void InitData()
    {
        AddTempData();
        _rankListAdapter.SetItems(rankItemData);
    }
    
    public class PlayerDataInfo
    {
        public string uid { get; set; }
        public string Nickname { get; set; }
        public string Avatar { get; set; }
        public string Trophy { get; set; }
        public float countDownTime { get; set; }
        public int rank { get; set; }
    }
}
