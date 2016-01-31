using UnityEngine;
using Entitas;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class AddFusionViewSystem : IReactiveSystem, ISetPool
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
            return Matcher.Fusable.OnEntityAdded();
        }
    }

    readonly Transform _slotPanel = GameObject.Find("FusableMonstersPanel").transform;

    public void Execute(List<Entity> entities)
    {
        // Position :
        // 0 left
        // 1 right
        int position = 0;

        foreach(var e in entities)
        {
            if (_pool.GetEntities(Matcher.Fusable).Length < 3)
            {
                // S'il n'y a aucun fusable
                if(_pool.GetEntities(Matcher.Fusable).Length < 2)
                {
                    position = 0;
                } else
                // Si il il y en a déja un
                {
                    position = 1;
                }

                e.AddFusionPosition(position);
                e.AddFusionView(CreateGameObject(e));
                
            }
            else
            {
                e.IsFusable(false);
            }
        }
    }

    GameObject CreateGameObject(Entity e)
    {
        GameObject gameObject = null;
        var res = Resources.Load<GameObject>("Prefabs/FusionSlot");

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
            gameObject.name = "FusionSlot " + e.fusionPosition.position;
            gameObject.transform.SetParent(_slotPanel, false);
            gameObject.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(e.resource.path);
            gameObject.GetComponent<RectTransform>().anchorMin = new Vector2(e.fusionPosition.position * 0.6f, 0.0f);
            gameObject.GetComponent<RectTransform>().anchorMax = new Vector2(0.4f + (e.fusionPosition.position * 0.6f), 1.0f);
            gameObject.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            gameObject.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            gameObject.transform.localScale = (e.fusionPosition.position < 1 ) ? Vector3.one : new Vector3(-1.0f, 1.0f, 1.0f);

            gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                e.IsFusable(false);
            });
        }

        return gameObject;
    }
}
