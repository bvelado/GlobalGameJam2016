using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class AddSlotView : IReactiveSystem, ISetPool
{
    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Displayed.OnEntityAdded();
        }
    }

    readonly Transform _slotPanel = GameObject.Find("MonstersPanel").transform;

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            int slotPosition = e.slotPosition.position - _pool.slotManager.minDisplayedPosition;

            GameObject gameObject = null;
            var res = Resources.Load<GameObject>("Prefabs/Slot");

            try
            {
                gameObject = GameObject.Instantiate(res);
            }
            catch (Exception)
            {
                Debug.Log("Cannot instantiate " + res);
            }

            if (gameObject != null)
            {
                gameObject.name = "Slot " + slotPosition;
                gameObject.transform.SetParent(_slotPanel, false);
                gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(e.resource.path);
                gameObject.GetComponent<RectTransform>().anchorMin = new Vector2(slotPosition * 0.25f, 0.0f);
                gameObject.GetComponent<RectTransform>().anchorMax = new Vector2(0.25f + (slotPosition * 0.25f), 1.0f);
                gameObject.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                gameObject.GetComponent<RectTransform>().offsetMax = Vector2.zero;
                gameObject.transform.localScale = Vector3.one;
                e.AddSlotView(gameObject);
            }
        }
    }
}
