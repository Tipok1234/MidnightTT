using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "DetailsConfig", menuName = "ScriptableObjects/DetailsConfig")]
public class DetailsConfig : ScriptableObject
{
    public List<Detail> details = new List<Detail>();


    public Detail GetDetail(string key)
    {
        return details.FirstOrDefault(d => d != null && d.key == key);
    }


    [Serializable]
    public class Detail
    {
        public string key;
        public int price;
        public Sprite detailSprite;

        public Material material;
        public PlayerController car;
    }
}
