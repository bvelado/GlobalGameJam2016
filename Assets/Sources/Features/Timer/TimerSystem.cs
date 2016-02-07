using UnityEngine;
using Entitas;
using UnityEngine.UI;

public class TimerSystem : IExecuteSystem, ISetPool
{
    Pool _pool;

    float minutes, seconds;
    string m, s;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public void Execute()
    {
        if (_pool.timerEntity.isRunning)
        {
            _pool.timer.secondsLeft -= Time.deltaTime;
            if (_pool.timerEntity.hasTimerView)
            {
                minutes = Mathf.FloorToInt(_pool.timerEntity.timer.secondsLeft / 60);
                seconds = Mathf.FloorToInt(_pool.timerEntity.timer.secondsLeft % 60);

                m = minutes.ToString("00");
                s = (seconds == 60) ? "00" : seconds.ToString("00");
                _pool.timerEntity.timerView.view.GetComponentInChildren<Text>().text = m + ":" + s;
            }
        }
    }
}
