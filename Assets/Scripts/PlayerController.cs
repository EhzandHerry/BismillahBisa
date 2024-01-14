using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip moveSound; // Sound effect saat player bergerak
    private AudioSource audioSource;

    private Rigidbody playerRb;
    private bool onGround = true;
    public bool gameOver = false;

    private float speed = 20.0f;
    private float boundary = 3.0f;
    private bool isMoving = false;
    private Vector3 targetPosition;
    // Start is called before the first frame update

    // Ukuran karakter normal
    private Vector3 originalScale;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= 1.0f;

        originalScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        //moveplayer
        if (Input.GetKey(KeyCode.UpArrow) && onGround)
        {
            playerRb.AddForce(Vector3.up * 20, ForceMode.Impulse);
            PlayMoveSound();
            onGround = false;

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving)
        {
            targetPosition = new Vector3(transform.position.x - 3.0f, transform.position.y, transform.position.z);
            StartCoroutine(MovePlayer(targetPosition));
            PlayMoveSound();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !isMoving)
        {
            targetPosition = new Vector3(transform.position.x + 3.0f, transform.position.y, transform.position.z);
            StartCoroutine(MovePlayer(targetPosition));
            PlayMoveSound();
        }

        IEnumerator MovePlayer(Vector3 target)
        {
            isMoving = true;
            float elapsedTime = 0f;
            Vector3 startingPos = transform.position;

            // Bergerak secara bertahap menggunakan Lerp
            while (elapsedTime < 1f)
            {
                transform.position = Vector3.Lerp(startingPos, target, elapsedTime);
                elapsedTime += Time.deltaTime * speed;
                yield return null;
            }

            // Pastikan posisi tepat pada target
            transform.position = target;
            isMoving = false;
        }


        // Batasan gerakan
        if (transform.position.x > boundary)
            transform.position = new Vector3(boundary, 0.94f, 0.0f);

        if (transform.position.x < -boundary)
            transform.position = new Vector3(-boundary, 0.94f, 0.0f);

        // Periksa input untuk merubah ukuran karakter
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(ChangeSizeTemporarily(1.0f, 1.0f)); // Ganti angka sesuai kebutuhan
            PlayMoveSound();
        }

        IEnumerator ChangeSizeTemporarily(float newSizeX, float newSizeY)
        {
            // Ganti ukuran karakter
            transform.localScale = new Vector3(newSizeX, newSizeY, transform.localScale.z);

            // Tunggu selama beberapa detik
            yield return new WaitForSeconds(1.7f); // Ganti angka sesuai kebutuhan

            // Kembalikan ukuran karakter ke ukuran semula
            transform.localScale = originalScale;
        }
    }
    void PlayMoveSound()
    {
        if (moveSound != null && audioSource != null)
        {
            audioSource.clip = moveSound;
            audioSource.Play();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacles"))
        {
            gameOver = true;
        }

    }
}