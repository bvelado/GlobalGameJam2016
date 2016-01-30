using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class CreateSlotsSystem : IInitializeSystem, ISetPool
{
    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public void Initialize()
    {
        for(int i = 0; i < 4; i++)
        {
            GameObject gameObject = null;
            var res = Resources.Load<GameObject>("Prefabs/Slot");
            try
            {
                gameObject = GameObject.Instantiate(res);
            } catch(Exception) {
                Debug.Log("Cannot instantiate " + res);
            }

            if(gameObject!=null)
            {
                gameObject.transform.SetParent(GameObject.Find("MonstersPanel").transform);
                gameObject.name = "Slot " + i;
                gameObject.GetComponent<RectTransform>().anchorMin = new Vector2(i * 0.25f, 0.0f);
                gameObject.GetComponent<RectTransform>().anchorMax = new Vector2(0.25f + (i * 0.25f), 1.0f);
                gameObject.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                gameObject.GetComponent<RectTransform>().offsetMax = Vector2.zero;
                gameObject.transform.localScale = Vector3.one;
            }

            _pool.CreateEntity()
                .AddSlot(i, gameObject)
                .IsEmpty(true);
        }
    }
}
