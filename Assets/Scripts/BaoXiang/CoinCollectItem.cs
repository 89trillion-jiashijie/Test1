using CubeClash.Scripts.Assembly.Util;
using DG.Tweening;
using UnityEngine;

public class CoinCollectItem : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer render;

    private Sequence mainTween;
    protected float fps = 30;

    protected virtual float targetScale => 1f;

    Vector3 from = new Vector3(0,0,0);
    Vector3 to = new Vector3(0, 8, 90);
    int index = 15;
    
    private void Start()
    {
        Do( from,to,index);
    }

    public void Do(Vector3 from, Vector3 to, int index)
    {
        float interval = 0.1f;
        Transform ownTransform = transform;

        Vector3 offset = Random.insideUnitCircle * 0.1f;
        ownTransform.position = from + offset;
        ownTransform.localScale = Vector3.zero;

        GetShiftingPos(out var shiftingPos);
        Vector3 end = ownTransform.position + shiftingPos;


        render.SetAlpha(0);

        mainTween = DOTween.Sequence();
        if (index >= 3)
        {
            mainTween.AppendInterval(index / 3 * interval);
        }
        else
        {
            mainTween.AppendInterval(index * interval);
        }
        mainTween.Append(render.DOFade(1f, ShowDuration));
        mainTween.Join(ownTransform.DOLocalMove(end, ShowDuration));
        mainTween.Join(ownTransform.DOScale(targetScale, ShowDuration));
        mainTween.AppendInterval(StayDuration);
        mainTween.Append(ownTransform.DOMove(to, FlyDuration).SetEase(Ease.InSine));
        mainTween.Join(ownTransform.DORotate(new Vector3(0, 360, 0), 0.2f, RotateMode.WorldAxisAdd));

    }

    private void GetShiftingPos(out Vector3 shiftingPos)
    {
        int randomX = Random.Range(1, 3);
        int randomY = Random.Range(1, 3);
        float shiftingX = randomX == 1 ? Random.Range(-0.2f, -1.2f) : Random.Range(0.2f, 1.2f);
        float shiftingY = randomY == 1 ? Random.Range(-0.1f, -0.5f) : Random.Range(0.1f, 0.5f);
    
        shiftingPos = new Vector3(shiftingX, shiftingY, 0);
    }

    protected virtual float ShowDuration => 12 / fps;
    protected virtual float StayDuration => 6 / fps;
    protected virtual float FlyDuration => 18 / fps;

}
