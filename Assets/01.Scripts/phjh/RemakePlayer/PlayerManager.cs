using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public PlayerStat stat;

    public InputReader _inputReader;

    public Camera _mainCam;
    public Rigidbody _rb;


}
