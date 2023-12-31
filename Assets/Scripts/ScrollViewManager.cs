using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewManager : MonoBehaviour
{
    [SerializeField] private Transform child;
    [SerializeField] private DetailModelView detailModel;
    //[SerializeField] private DetailsConfig config;


    public void SetupScrollShopDetail()
    {
        for (int i = 0; i < GameManager.Instance.Config.details.Count; i++)
        {
            var newDetail = Instantiate(detailModel, child);
            newDetail.SetupDetail(GameManager.Instance.Config.details[i]);
        }
    }
}
