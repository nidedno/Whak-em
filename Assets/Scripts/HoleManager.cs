using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{   
    public Unit[] units;
    public Hole[] holes;
    [SerializeField] private float spawnRate = 5f;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _animSpeed;

    bool isActive = false;
    
    float spawnReload;

    void Start()
    {
        holes = FindObjectsOfType<Hole>();

        SetLifeTime(_lifeTime);
        SetAnimSpeed(_animSpeed);

        //TryCreateUnit();
        spawnReload = spawnRate;
    }

    void Update()
    {
        if(!isActive) return;

        spawnReload -= Time.deltaTime;
        if(spawnReload <= 0)
        {
            if(GetFreeHoles() == 0 ) return;
            TryCreateUnit();
            spawnReload =  spawnRate;
        }
    }



    public void TryCreateUnit()
    {   
        if(GetFreeHoles() == 0 ) return;

        
        var hole = RandomHole();
        if(hole.isBusy() == false)
        {
            var randomUnit = RandomUnit();
            hole.SpawnUnit(randomUnit);
        }
        else
        {
            TryCreateUnit();
        }
    }

    private Hole RandomHole()
    {
        return holes[Random.Range(0, holes.Length)];
    }
    private Unit RandomUnit()
    {
        return units[Random.Range(0, units.Length)];
    }

    public int GetFreeHoles()
    {
        int free = 0;
        foreach (Hole hole in holes)
        {   
            if(!hole.isBusy())
                free += 1;
        }
        return free;
    }

    public void SetAnimSpeed(float animSpeed){
        foreach (Hole hole in holes)
        {   
            hole.SetAnimSpeed(animSpeed);
        }
    }
    public void SetLifeTime(float lifeTime){
        foreach (Hole hole in holes)
        {   
            hole.SetLifeTime(lifeTime);
        }
    }
    public void SetSpawnRate(float rate)
    {
        spawnRate = rate;
    }

    public float GetLifeTime()
    {
        return _lifeTime;
    }
    
    public float GetAnimSpeed()
    {
        return _animSpeed;
    }

    public void GameStatus(bool status)
    {
        isActive = status;
    }

    public float GetSpawnRate()
    {
        return spawnRate;
    }


}
