using System.Data;
using UnityEngine;


public partial class Rocket : MonoBehaviour
{
    [SerializeField] GameObject ShootBtn;

    private Rigidbody2D _rb2d;
    private float fuel = 100f;
    private float MaxFuel = 100f;
    
    private readonly float SPEED = 5f;
    private readonly float FUELPERSHOOT = 10f;

    RocketDashboard recordUI;
    RocketEnergySystem fuelUI;
    RocketAnimationContrller animationContrller;

    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        
        recordUI = GetComponent<RocketDashboard>();
        fuelUI= GetComponent<RocketEnergySystem>();
        animationContrller=GetComponent<RocketAnimationContrller>();
    }

    private void Update()
    {
        if (fuel < MaxFuel)
        {
            fuel += 0.1f;
            if (fuel > MaxFuel) fuel = MaxFuel;
        }
        recordUI.UpdateStatUIPosition();
        fuelUI.UpdateSlider(fuel);
    }


    public void Shoot()
    {
        if(fuel > FUELPERSHOOT)
        {
            fuel -= FUELPERSHOOT;
            _rb2d.AddForce(Vector2.up * SPEED, ForceMode2D.Impulse);
        }
    }

    public void GameOver()
    {
        animationContrller.DestroyAnimation();
        recordUI.recording();
        fuel = 0f;
    }

    public void ContactGround(bool isLaunched)
    {
        if (isLaunched)
        {
            GameOver();
            ShootBtn.SetActive(false);
            this.enabled = false;
        }
        else if(!isLaunched)
        {
            ShootBtn.SetActive(true);
            this.enabled = true;
        }

    }

}
