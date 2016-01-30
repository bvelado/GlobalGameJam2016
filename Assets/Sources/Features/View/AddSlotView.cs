using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class AddSlotView : IReactiveSystem
{
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Resource, Matcher.Available).OnEntityAdded();
        }
    }

    readonly Transform _viewContainer = new GameObject("SlotViews").transform;

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            GameObject gameObject = null;
            var res = Resources.Load<GameObject>("Prefabs/ImageSlot");
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
                gameObject.name = e.monster.id.ToString();
                gameObject.transform.SetParent(_viewContainer, false);
                gameObject.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(e.resource.path);
                gameObject.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                gameObject.GetComponent<RectTransform>().offsetMax = Vector2.zero;
                gameObject.transform.localScale = Vector3.one;
                e.AddSlotView(gameObject);
            }
        }
    }
}
