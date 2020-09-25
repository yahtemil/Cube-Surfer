using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class GoldUI : MonoBehaviour
{
    Transform panel;
    Sequence goldAnimation;
    TextMeshProUGUI goldText;

    // Start is called before the first frame update
    void Start()
    {
        AnimationControl();
    }

    public void AnimationControl()
    {
        panel = GameObject.FindGameObjectWithTag("GoldPanel").transform;
        goldText = GameObject.FindGameObjectWithTag("GoldText").GetComponent<TextMeshProUGUI>();
        goldAnimation = DOTween.Sequence();

        goldAnimation.Append(transform.DOMove(panel.position, 2)
            .SetEase(Ease.OutBounce))
            .OnComplete(GoldPlus);
    }

    public void GoldPlus()
    {
        int sayi;
        sayi = int.Parse(goldText.text);
        sayi += 1;
        goldText.text = sayi.ToString();
        PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold",0)+1);
        Destroy(gameObject);
    }
}
