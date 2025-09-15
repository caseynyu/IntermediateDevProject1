using System.Collections;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerActivateNumber;
    public int sceneNumber;
    public float dialogueNumber = 1;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player7;
    public GameObject dialogue1;
    public GameObject dialogue2;
    public GameObject dialogue3;
    public GameObject dialogue4;
    public GameObject dialogue5;
    public GameObject dialogue6;
    public GameObject dialogue7;
    public GameObject dialogue8;
    public GameObject dialogue9;
    public GameObject dialogue10;
    public GameObject dialogue11;
    public GameObject dialogue12;
    public GameObject dialogue13;
    public GameObject dialogue14;
    public GameObject dialogue2quickfiller;
    public GameObject dialogue2quickleave;
    public GameObject dialogue2quickpay;
    public GameObject dialogue8leave;
    public GameObject dialogue10talk;
    public GameObject dialogue11leave;
    public GameObject bRoomPeople;
    public GameObject bRoomDoor;
    public GameObject bRoomPlayer;
    public AudioClip storeDoor;
    public AudioClip storeBuy;
    public AudioClip eating;
    public AudioClip toiletFlush;
    public AudioClip speaking;
    public AudioClip stomachSound;
    public AudioClip schoolBell;
    public AudioClip streetAmbience;
    public AudioClip schoolAmbience;
    public AudioClip poopSound;
    public AudioClip sink;
    public AudioSource effectAudioSource;
    public AudioSource ambienceAudioSource;
    public AudioSource talkingAudioSource;
    public bool spaceUp = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hide(dialogue1);
        Hide(dialogue2);
        Hide(dialogue3);
        Hide(dialogue4);
        Hide(dialogue5);
        Hide(dialogue6);
        Hide(dialogue7);
        Hide(dialogue8);
        Hide(dialogue9);
        Hide(dialogue10);
        Hide(dialogue11);
        Hide(dialogue12);
        Hide(dialogue13);
        Hide(dialogue14);
        Hide(dialogue2quickfiller);
        Hide(dialogue2quickleave);
        Hide(dialogue2quickpay);
        Hide(dialogue8leave);
        Hide(dialogue10talk);
        Hide(dialogue11leave);
        bRoomPeople.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        bRoomDoor.GetComponent<SpriteRenderer>().enabled = false;
        bRoomPlayer.GetComponentInChildren<SpriteRenderer>().enabled = false;

        Show(dialogue1);
        dialogueNumber = 1;
        playerActivateNumber = 0;
        sceneNumber = 1;
        ambienceAudioSource.loop = true;
        ambienceAudioSource.clip = streetAmbience;
        ambienceAudioSource.Play();
        effectAudioSource.loop = false;
        talkingAudioSource.clip = speaking;
        talkingAudioSource.loop = true;
    }
    void Hide(GameObject gameObject)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    void Show(GameObject gameObject)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && spaceUp == true)
        {
            spaceUp = false;
            switch (dialogueNumber)
            {
                case 1:
                    Hide(dialogue1);
                    Show(dialogue2);
                    dialogueNumber = 2;
                    break;
                case 2:
                    playerActivateNumber = 1;
                    Hide(dialogue2);
                    dialogueNumber = 2.5f;
                    break;
                case 2.75f:
                    playerActivateNumber = 3;
                    Hide(dialogue2quickfiller);
                    dialogueNumber = 2.5f;
                    break;
                case 2.9f:
                    playerActivateNumber = 3;
                    Hide(dialogue2quickleave);
                    dialogueNumber = 2.5f;
                    break;
                case 3:
                    playerActivateNumber = 3;
                    Hide(dialogue3);
                    dialogueNumber = 3.5f;
                    break;
                case 3.9f:
                    playerActivateNumber = 3;
                    Hide(dialogue2quickpay);
                    dialogueNumber = 3.5f;
                    break;
                case 4:
                    playerActivateNumber = 3;
                    Hide(dialogue4);
                    dialogueNumber = 4.5f;
                    break;
                case 5:
                    sceneNumber = 5;
                    Hide(dialogue5);
                    dialogueNumber = 5.5f;
                    ambienceAudioSource.Stop();
                    break;
                case 5.5f:
                    ambienceAudioSource.clip = schoolAmbience;
                    ambienceAudioSource.Play();
                    effectAudioSource.PlayOneShot(stomachSound);
                    sceneNumber = 6;
                    Show(dialogue6);
                    dialogueNumber = 6;
                    break;
                case 6:
                    Hide(dialogue6);
                    Show(dialogue7);
                    dialogueNumber = 7;
                    break;
                case 7:
                    Hide(dialogue7);
                    Show(dialogue8);
                    //ambienceAudioSource.Pause();
                    dialogueNumber = 8;
                    sceneNumber = 7;
                    break;
                case 8:
                    Hide(dialogue8);
                    playerActivateNumber = 7;
                    dialogueNumber = 8.5f;
                    break;
                case 8.75f:
                    Hide(dialogue8leave);
                    playerActivateNumber = 7;
                    dialogueNumber = 8.5f;
                    break;
                case 9:
                    Hide(dialogue9);
                    dialogueNumber = 9.5f;
                    StartCoroutine(BathroomCoroutine());
                    break;
                case 11:
                    //bRoomDoor.GetComponent<SpriteRenderer>().enabled = false;
                    player7.GetComponentInChildren<SpriteRenderer>().enabled = true;
                    bRoomPlayer.GetComponentInChildren<SpriteRenderer>().enabled = false;
                    Hide(dialogue11);
                    dialogueNumber = 11.5f;
                    playerActivateNumber = 7;
                    player7.transform.position = new UnityEngine.Vector3(10, -17.97f, -0.086827f);
                    break;
                case 11.75f:
                    Hide(dialogue11leave);
                    playerActivateNumber = 7;
                    dialogueNumber = 11.5f;
                    break;
                case 13:
                    Show(dialogue14);
                    dialogueNumber = 14;
                    break;


            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            spaceUp = true;
        }
    }
    public void TransitionTrigger(GameObject player)
    {
        if (player == player1)
        {
            sceneNumber = 2;
            playerActivateNumber = 2;
        }
        if (player == player2)
        {
            sceneNumber = 3;
            playerActivateNumber = 3;
            effectAudioSource.PlayOneShot(storeDoor);
            //ambienceAudioSource.Pause();
        }
        if (player == player3 && dialogueNumber == 2.5f)
        {
            dialogueNumber = 2.9f;
            playerActivateNumber = 0;
            Show(dialogue2quickleave);
        }
        if (player == player3 && dialogueNumber == 3.5f)
        {
            dialogueNumber = 3.9f;
            playerActivateNumber = 0;
            Show(dialogue2quickpay);
        }
        if (player == player3 && dialogueNumber == 4.5f)
        {
            sceneNumber = 4;
            playerActivateNumber = 0;
            dialogueNumber = 5;
            Show(dialogue5);
            //ambienceAudioSource.Play();
            StartCoroutine(DelayedEatingSound());
        }
        if (player == player7 && dialogueNumber == 8.5f)
        {
            playerActivateNumber = 0;
            dialogueNumber = 8.75f;
            Show(dialogue8leave);

        }
        if (player == player7 && dialogueNumber == 11.5f)
        {
            playerActivateNumber = 0;
            dialogueNumber = 11.75f;
            Show(dialogue11leave);
        }
        if (player == player7 && dialogueNumber == 12)
        {
            playerActivateNumber = 0;
            dialogueNumber = 13;
            Show(dialogue13);
            sceneNumber = 8;
        }
    }
    public void Interact(GameObject interactedObject)
    {
        spaceUp = false;
        switch (interactedObject.name)
        {
            case "Quick Check Employee":
                if (dialogueNumber == 2.5f)
                {
                    dialogueNumber = 2.75f;
                    playerActivateNumber = 0;
                    Show(dialogue2quickfiller);
                }
                if (dialogueNumber == 3.5f)
                {
                    dialogueNumber = 4f;
                    playerActivateNumber = 0;
                    Show(dialogue4);
                    effectAudioSource.PlayOneShot(storeBuy);
                }
                if (dialogueNumber == 4.5f)
                {
                    playerActivateNumber = 3;
                }
                break;
            case "Takis Bag":
                interactedObject.gameObject.SetActive(false);
                dialogueNumber = 3;
                playerActivateNumber = 0;
                Show(dialogue3);
                break;
            case "BDoor Interact":
                if (dialogueNumber == 8.5f)
                {
                    playerActivateNumber = 0;
                    player7.GetComponentInChildren<SpriteRenderer>().enabled = false;
                    dialogueNumber = 9;
                    Show(dialogue9);
                }
                break;
            case "Sink":
                if (dialogueNumber == 11.5f)
                {
                    //play sound
                    effectAudioSource.PlayOneShot(sink);
                    dialogueNumber = 12;

                }
                break;
        }
    }
    IEnumerator BathroomCoroutine()
    {
        yield return new WaitForSeconds(2);
        //play sound effect;
        effectAudioSource.PlayOneShot(poopSound);
        //Debug.Log("sound effect");
        yield return new WaitForSeconds(7);
        //however long sound effect is ^
        bRoomPeople.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
        Show(dialogue10talk);
        talkingAudioSource.Play();
        yield return new WaitForSeconds(1f);
        Show(dialogue10);
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        Hide(dialogue10);
        yield return new WaitForSeconds(5);
        //play school bell ringing sound effect and wait for it
        effectAudioSource.PlayOneShot(schoolBell);
        yield return new WaitForSeconds(2);
        Hide(dialogue10talk);
        talkingAudioSource.Stop();
        yield return new WaitForSeconds(2);
        bRoomPeople.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1);
        Show(dialogue12);
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        effectAudioSource.PlayOneShot(toiletFlush);
        Hide(dialogue12);
        Show(dialogue11);
        bRoomDoor.GetComponent<SpriteRenderer>().enabled = true;
        bRoomPlayer.GetComponentInChildren<SpriteRenderer>().enabled = true;
        dialogueNumber = 11;

    }
    IEnumerator DelayedEatingSound()
    {
        yield return new WaitForSeconds(.75f);
        effectAudioSource.PlayOneShot(eating);
    }
}
// need sound effects for toilet, eating takis, washing hands, money?
