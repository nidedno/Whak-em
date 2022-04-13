
using UnityEngine;
using UnityEngine.EventSystems;
public class Hole : MonoBehaviour
{
    
    [SerializeField]private Transform spawn;
    
    private Unit unitInHole;
    [SerializeField] private float _lifeTime = 2f;
    [SerializeField] private float _animSpeed = 1f;

    public bool isBusy(){
        return !(unitInHole == null);
    }

    public void SpawnUnit(Unit _unit)
    {   
        if(isBusy()) return;

        unitInHole = Instantiate(_unit,spawn.position,spawn.rotation);
        unitInHole.Spawn(_animSpeed);
        Invoke("RemoveUnit",_lifeTime);
    }

    public void RemoveUnit()
    {
        if(unitInHole == null) return;
        
        unitInHole.Back(_animSpeed);
    }

    public void SetLifeTime(float lifeTime)
    {
        _lifeTime = lifeTime;
    }

    public void SetAnimSpeed(float animSpeed)
    {
        _animSpeed = animSpeed;
    }



   


}
