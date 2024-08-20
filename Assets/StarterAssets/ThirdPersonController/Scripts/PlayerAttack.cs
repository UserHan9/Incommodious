using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;


public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    // public Rigidbody rb;
    public int combo;
    public AudioClip attack1;
    public AudioClip attack2;
    public AudioClip attack3;
    public bool serang;
    public float comboResetTime = 1.0f; // Waktu tunggu untuk reset combo
    private float lastAttackTime; // Waktu serangan terakhir
    private StarterAssets.StarterAssetsInputs _input;

    private CharacterController controller;
    public Collider Weapon;

    public ThirdPersonController player;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _input = GetComponent<StarterAssets.StarterAssetsInputs>();
        combo = 0; // Mulai dari combo 0
    }

    // Update is called once per frame
    void Update()
    {
        Combos();
        ResetComboWithTime();
    }

    public void StartCombo()
    {
        serang = false;
        if (combo < 3)
        {
            combo++;

        }
    }

    public void FinishCombo()
    {
        serang = false;
        combo = 0; // Reset combo setelah stage terakhir

        // Pastikan semua trigger di-reset setelah combo selesai
        animator.ResetTrigger("1");
        animator.ResetTrigger("2");
        animator.ResetTrigger("3");
    }

    private void Combos()
    {
        if (_input.attack1 && !serang)
        {
            serang = true;
            lastAttackTime = Time.time;

            // Increment combo stage up to 3
            if (combo < 3)
            {
                combo++;
            }

            player._speed = 1.0f;
            player.MoveSpeed = 1.0f;

            animator.SetTrigger("" + combo);

            // Coroutine untuk menunggu sebelum combo berikutnya
            StartCoroutine(PerformAttack());
        }
    }

    IEnumerator PerformAttack()
    {
        // Menunggu sampai animasi saat ini selesai
        yield return new WaitForSeconds(0.1f);

        _input.attack1 = false;

        // Jika combo telah mencapai tahap ketiga
        if (combo == 3)
        {
            FinishCombo();
        }
        else
        {
            serang = false; // Reset serangan agar bisa menerima input lagi
            player._speed = 3.5f;
            player.MoveSpeed = 3.5f;
        }
    }

    private void ResetComboWithTime()
    {
        if (Time.time - lastAttackTime > comboResetTime && combo > 0)
        {
            combo = 0; // Reset combo setelah waktu tertentu
            serang = false;
        }
    }

    private void onAttack1(AnimationEvent animationEvent)
    {
        ThirdPersonController player = this.GetComponent<ThirdPersonController>();
        controller = player._controller;
        AudioSource.PlayClipAtPoint(attack1, transform.TransformPoint(controller.center));
    }
    private void onAttack2(AnimationEvent animationEvent)
    {
        ThirdPersonController player = this.GetComponent<ThirdPersonController>();
        controller = player._controller;
        AudioSource.PlayClipAtPoint(attack2, transform.TransformPoint(controller.center));
        
    }
    private void onAttack3(AnimationEvent animationEvent)
    {
        ThirdPersonController player = this.GetComponent<ThirdPersonController>();
        controller = player._controller;
        AudioSource.PlayClipAtPoint(attack3, transform.TransformPoint(controller.center));
    }

}
