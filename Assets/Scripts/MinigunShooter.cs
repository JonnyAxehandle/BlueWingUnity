using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunShooter : MonoBehaviour
{
    [SerializeField] private float timeBetweenShots = 0.5f;
    [SerializeField] private FiredShot MinigunShotPrefab;
    [SerializeField] private float ShotSpeed = 15;

    private float ShotCooldown = 0;
    private PlayerInput playerInput;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Vector2? aimAngle = playerInput.GetAimAngle();
        if (aimAngle != null)
        {
            Fire();
        }
        DoCooldown();
    }

    private void Fire()
    {
        if (ShotCooldown > 0) return;
        FiredShot shot = Instantiate(MinigunShotPrefab);
        shot.transform.SetPositionAndRotation(transform.position, transform.rotation);
        shot.Fire(ShotSpeed, Vector2.up);
        ShotCooldown = timeBetweenShots;
    }

    private void DoCooldown()
    {
        if (ShotCooldown < 0)
        {
            ShotCooldown = 0;
        }

        if (ShotCooldown == 0)
        {
            return;
        }

        ShotCooldown -= Time.deltaTime;
    }
}
