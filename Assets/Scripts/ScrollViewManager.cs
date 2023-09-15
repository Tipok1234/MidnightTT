using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewManager : MonoBehaviour
{
    [SerializeField] private Transform child;

    [SerializeField] private DetailModelView detailModel;

    public void SetupScrollShopDetail()
    {
        for (int i = 0; i < 10; i++)
        {
            var newDetail = Instantiate(detailModel, child);

            newDetail.SetupDetail(i);
        }
    }
}
