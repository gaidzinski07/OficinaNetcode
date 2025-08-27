using UnityEngine;
using Unity.Netcode;
using Tanks.Complete;

public class TankNetworkMove : NetworkBehaviour
{
    [SerializeField] private TankMovement tankMovement;
    [SerializeField] private TankShooting tankShooting;
    [SerializeField] private TankHealth tankHealth;

    public void Awake()
    {
        tankMovement.enabled = true;
        tankShooting.enabled = false;
        tankHealth.enabled = false;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (IsOwner)
        {
            tankShooting.enabled = true;
        }else if (IsServer)
        {
            tankHealth.enabled = true;
        }
    }

}
