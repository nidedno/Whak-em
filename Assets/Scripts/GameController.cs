using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] HoleManager _holeManager;

    [SerializeField] AnimationCurve roundCurve;
    [SerializeField] float oneRoundTime = 45f;

    [Header("Other ")]
    [SerializeField] Slider slider;
    [SerializeField] Image fill;
    
    public static GameController Instance;

    int currentRound = 1;
    float roundTime = 0.0f;
    bool relaxTime = false;
    // start values of units //
    float _animSpeed;
    float _lifeTime;
    float _spawnRate;
    // значения для раундов
    float _cAnimSpeed;
    float _cLifeTime;
    float _cSpawnRate;

    // end of values //

    bool gameStarted = false;


    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        // начальные значение жизни врагов
        _animSpeed = _holeManager.GetAnimSpeed(); 
        _lifeTime = _holeManager.GetLifeTime();
        _spawnRate = _holeManager.GetSpawnRate();

        _cAnimSpeed = _animSpeed;
        _cLifeTime = _lifeTime;
        _cSpawnRate = _spawnRate;
        
    
    }

    void Update(){
        if(!gameStarted) return;
        if(relaxTime) return; // состояние, при котором наступает отдых от раунда

        
        {
            roundTime += Time.deltaTime/oneRoundTime; // увеличиваем время раунда

            SetRoundBarValue(roundTime); // отображаем прогресс раунда
        
            float multicast = currentRound * roundCurve.Evaluate(roundTime) * 0.3f; // коэф усиления начальных значений
            // вычисляем значения
            _cAnimSpeed += multicast * 0.005f * 0.01f;
            _cLifeTime -= multicast * 0.025f * 0.01f;
            _cSpawnRate -= multicast * 0.03f* 0.01f;

            // обновляем значения  
            _holeManager.SetAnimSpeed(_cAnimSpeed ); // коэф скорости изменяется быстрее чем время жизни
            _holeManager.SetLifeTime(_cLifeTime );
            _holeManager.SetSpawnRate( _cSpawnRate );
            

        }
        // проверка конца раунда
        if(roundTime*oneRoundTime >= oneRoundTime){
            Debug.Log("ROUND ENDED");
            currentRound += 1;
            roundTime = 0f;
            SetRoundBarValue(0f); // обнуляем отображение прогресса раунда
        }

        
    }

    
    public void StartGame()
    {
        _holeManager.GameStatus(true);
        gameStarted = true;
    }

    public void PauseGame()
    {

    }

    private IEnumerator RoundStart(int roundCount)
    {

        yield return null; // here relax time

        // and start again
    }

    void SetRoundBarValue(float val)
    {
        slider.value = Mathf.Lerp(slider.value,val,0.1f);
    }
}
