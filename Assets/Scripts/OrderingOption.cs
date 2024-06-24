using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderingOption : MonoBehaviour
{
    public GameObject OptionMenu, AscendingOrder, DescendingOrder;

    public void ShowAscendingOrder()
    {
        OptionMenu.SetActive(false);
        AscendingOrder.SetActive(true);
    }

    public void ShowDescendingOrder()
    {
        OptionMenu.SetActive(false);
        DescendingOrder.SetActive(true);
    }


}
