using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class LaserShooter : MonoBehaviour , IWeaponInputTarget
{
    [SerializeField] private FiredShot LaserShotPrefab;
    [SerializeField] private float ShotSpeed = 10;

    [SerializeField] private int shotsPerBurst = 3;
    [SerializeField] private float timeBetweenShots = 0.5f;
    [SerializeField] private float timeBetweenBursts = 1;

    // TODO: Find a way to remove these stateful properties
    private Vector2 aimDirection;
    private bool InCooldown = false;

    public void Aim(Vector2 aimDirection)
    {
        this.aimDirection = Vector2Utils.ClampMagnitude(aimDirection, 1, 1);
    }

    public void Fire()
    {
        if (!InCooldown)
        {
            StartCoroutine(FireBurst());
        }
    }

    private IEnumerator FireBurst()
    {
        InCooldown = true;
        for (int i = 0; i < shotsPerBurst; i++)
        {
            FiredShot shot = Instantiate(LaserShotPrefab);
            shot.transform.SetPositionAndRotation(transform.position, transform.rotation);
            shot.Fire(ShotSpeed, aimDirection);
            yield return new WaitForSeconds(timeBetweenShots);
        }
        StartCoroutine(Cooldown());
        yield return null;
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(timeBetweenBursts);
        InCooldown = false;
        yield return null;
    }
}
