using UnityEngine.Events;

public static class GlobalEvents
{
    public static UnityEvent StartGame = new UnityEvent();

    public static UnityEvent PlayerEffect = new UnityEvent();
    public static UnityEvent EnemyEffect = new UnityEvent();
    public static UnityEvent UpgradeEffect = new UnityEvent();
    public static UnityEvent DefenseEffect = new UnityEvent();

    public static UnityEvent WallPlayerEffect = new UnityEvent();
    public static UnityEvent WallEnemyEffect = new UnityEvent();
}
