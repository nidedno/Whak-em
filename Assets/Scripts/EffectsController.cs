using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EffectsController : MonoBehaviour
{
    [SerializeField] Effect[] effects;

    public static EffectsController Instance;

    void Start()
    {
        if(Instance == null){
            Instance = this;
        }
    }

    public void CreateEffect(string name,Vector3 position)
    {
        Effect eff = Array.Find(effects, effect => effect.name == name);
        float lifeTime = eff.lifeTime;
        if(eff != null)
        {
            var effect = Instantiate(eff.effectPrefab,position,transform.rotation);
            Destroy(effect,lifeTime);
        }else
        {
            Debug.LogWarning("effect " + name + " don't exists");
        }
    }




}
