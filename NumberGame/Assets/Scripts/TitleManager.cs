using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    [SerializeField] UnityEngine.UI.Button gameStartButton;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        bgm.loop = true;
        bgm.Play();
        audioSource = GetComponent<AudioSource>();
        gameStartButton.onClick.AddListener(() => GameStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameStart()
    {
        audioSource.PlayOneShot(audioSource.clip);
        Fader.FadeIn(2f, "Main");
    }
}
