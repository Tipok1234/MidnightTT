using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "DetailsConfig", menuName = "ScriptableObjects/DetailsConfig")]
public class DetailsConfig : ScriptableObject
{
    public List<Detail> details = new List<Detail>();

    [Serializable]
    public class Detail 
    {
        public string key;
        public int price;
        public Sprite detailSprite;
    }
}
