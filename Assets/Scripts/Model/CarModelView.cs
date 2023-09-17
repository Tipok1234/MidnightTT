using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarModelView : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;

    private void Start()
    {
        var lastKey = PlayerPrefs.GetString(DetailModelView.lastDetailBuyKey);
        var lastDetail = GameManager.Instance.Config.GetDetail(lastKey);

        if (lastDetail != null)
            GameManager.Instance.Car.ModelView.SetColor(lastDetail.material);
    }

    public void SetColor(Material material)
    {
        mesh.materials[0].color = material.color;
    }
}
