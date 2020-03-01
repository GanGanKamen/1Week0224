using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private UnityEngine.UI.Button button;
    [SerializeField] private UnityEngine.UI.Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        button.onClick.AddListener(() => BatckToTitle());
        var sender = GameObject.FindGameObjectWithTag("ScoreSender").GetComponent<ScoreSender>();
        scoretext.text = "Your Score"+"\n" + sender.score.ToString();
        //Destroy(sender.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BatckToTitle()
    {
        audioSource.PlayOneShot(audioSource.clip);
        Fader.FadeInBlack(2f, "Title");
    }
}
