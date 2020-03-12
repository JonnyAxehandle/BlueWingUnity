using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class LaserShooter : MonoBehaviour
{
    [SerializeField] private FiredShot LaserShotPrefab;
    [SerializeField] private float ShotSpeed = 10;

    [SerializeField] private int shotsPerBurst = 3;
    [SerializeField] private float timeBetweenShots = 0.5f;
    [SerializeField] private float timeBetweenBursts = 1;

    private PlayerInput playerInput;

    // TODO: Find a way to remove these stateful properties
    private Vector2 lastAngle;
    private float BurstCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Vector2? aimAngle = playerInput.GetAimAngle();
        if (aimAngle != null)
        {
            lastAngle = aimAngle ?? Vector2.zero;
            Fire();
        }
        DoCooldown();
    }

    private void DoCooldown()
    {
        if (BurstCooldown < 0)
        {
            BurstCooldown = 0;
        }

        if (BurstCooldown == 0)
        {
            return;
        }

        BurstCooldown -= Time.deltaTime;
    }

    private void Fire()
    {
        if (BurstCooldown > 0) return;
        StartCoroutine(FireBurst());
        BurstCooldown = (timeBetweenShots * shotsPerBurst) + timeBetweenBursts;
    }

    private IEnumerator FireBurst()
    {
        for (int i = 0; i < shotsPerBurst; i++)
        {
            FiredShot shot = Instantiate(LaserShotPrefab);
            shot.transform.SetPositionAndRotation(transform.position, transform.rotation);
            shot.Fire(ShotSpeed, lastAngle);
            yield return new WaitForSeconds(timeBetweenShots);
        }
        yield return null;
    }
}
