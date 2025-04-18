using UnityEngine;
using System.Collections;

public class CenterRotate : MonoBehaviour
{
    [Tooltip("Rotation speed in degrees per second.")]
    public float rotationSpeed = 45f;

    [Header("Sound Settings")]
    public AudioClip collectSound;
    [Range(0f, 1f)] public float volume = 1f; // 🎚 可调节音量

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectibleManager manager = FindObjectOfType<CollectibleManager>();
            if (manager != null)
            {
                manager.Collect();
            }

            // 播放音效并销毁
            StartCoroutine(PlaySoundAndDestroy());
        }
    }

    private IEnumerator PlaySoundAndDestroy()
    {
        if (collectSound != null)
        {
            // 创建临时音源
            GameObject soundObj = new GameObject("TempAudio");
            soundObj.transform.position = transform.position;
            AudioSource audioSource = soundObj.AddComponent<AudioSource>();
            audioSource.clip = collectSound;
            audioSource.volume = volume;
            audioSource.Play();

            // 等待播放完毕再销毁音效对象
            Destroy(soundObj, collectSound.length);
        }

        // 销毁收集物
        Destroy(gameObject);
        yield return null;
    }
}
