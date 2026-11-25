using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public enum GameState
    {
        AIMING, SHOOTING, BREAKING
    }
    public GameState currentGameState;

    [Header("Destroy Balls")]
    [SerializeField] private List<Peg> pegsToBreak;
    [SerializeField] private float timeBetweenPegs;

    [Space]
    [SerializeField] private AudioSource pegBreakSound;

    [Header("References")]
    [SerializeField] private ShootBall shootScript;
    public static GameHandler instance;

    private void Start()
    {
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
    }
    
    public void AddPegToList(Peg pegToAdd)
    {
        if(!pegsToBreak.Contains(pegToAdd)) pegsToBreak.Add(pegToAdd);
    }

    private IEnumerator BreakMarkedPegs()
    {
        foreach(Peg peg in pegsToBreak)
        {
            pegBreakSound.Play();
            peg.BreakPeg();
            yield return new WaitForSeconds(timeBetweenPegs);
        }

        Debug.Log("Switching Game State Again");
        SwitchGameState(0);
    }

    public void SwitchGameState(int state)
    {
        switch (state)
        {
                //aiming
            case 0:
                pegsToBreak.Clear();
                currentGameState = GameState.AIMING;
                shootScript.canShoot = true;
            break;

                //shooting
            case 1:
                currentGameState = GameState.SHOOTING;
                shootScript.canShoot = false;
            break;

                //breaking
            case 2:
                currentGameState = GameState.BREAKING;
                StartCoroutine(BreakMarkedPegs());
            break;

            default:
                currentGameState = GameState.SHOOTING;
                shootScript.canShoot = true;
            break;
        }
    }
}
