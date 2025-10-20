using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVedioOn : MonoBehaviour
{
    RawImage rawimage;
    VideoPlayer vedioPlay;

    // Start is called before the first frame update
    void Start()
    {
        rawimage = GetComponent<RawImage>();
        vedioPlay = GetComponent<VideoPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(vedioPlay.texture == null)
        {
            return;
        }
        rawimage.texture = vedioPlay.texture;
    }

    public void VedioController()
    {
        if(vedioPlay.isPlaying)
        {
            vedioPlay.Pause();
        }
        else
        {
            vedioPlay.Play();
        }
    }
}
