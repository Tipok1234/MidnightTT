using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviourPun
{
    public PrometeoCarController CarController;
    public CarModelView ModelView;


    private void OnEnable()
    {
        if (photonView.IsMine)
        {
            CarController = GetComponent<PrometeoCarController>();
            ModelView = GetComponent<CarModelView>();
        }
    }

}
