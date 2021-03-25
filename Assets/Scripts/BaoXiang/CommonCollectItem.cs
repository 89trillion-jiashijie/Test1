using System;
using CubeClash.Scripts.Assembly.Util;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CommonCollectItem : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private Text number;
    [SerializeField] public Animator _animator;

    private const int  coinNumber = 1;//初始金币

    private int haveCoinNum;//拥有金币数量
    private int theCoinNum;//本次购买的金币数量
    private int buyTimes;  //购买次数
    
    public void OnClick()
    {
        buyTimes++;
        _animator.ResetTrigger("box_open_1");
        _animator.SetTrigger("box_close_1");
        
        theCoinNum = coinNumber * buyTimes;

        theCoinNum=   theCoinNum>15?15: theCoinNum;

        for (int j = 0; j < theCoinNum; j++)
        {
            Instantiate(obj);
        }
  

        haveCoinNum += theCoinNum;
        DOTween.To(x => { number.text = UnityUtil.NumberFormat((long) x); },haveCoinNum-theCoinNum , haveCoinNum, 1.7f);
    }
}