using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngosickAppearance : MonoBehaviour
{
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private AudioClip[] audios;
    [SerializeField]
    private AudioSource audioComp;
    public void Disappearance()
    {
        door.SetActive(false);
    }

    public void Appearance()
    {
        transform.gameObject.SetActive(true);
    }

    public void DoorAppearance()
    {
        door.SetActive(true);
    }

    public void PlayAudio(int audioInd)
    {
        audioComp.clip = audios[audioInd];
        audioComp.Play();

    }
}
