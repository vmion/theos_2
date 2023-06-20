using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public enum State
    {
        IDLE,
        WALK,
        ATTACK1, 
        ATTACK2,        
        HIT
    }
    public State state;

    private void Start()
    {        
        ChangeState(State.IDLE);
    }

    private void Update()
    {
        switch (state)
        {
            case State.IDLE:
                Idle();
                break;
            case State.WALK:
                Walk();
                break;
            case State.ATTACK1:
                Attack1();
                break;
            case State.ATTACK2:
                Attack2();
                break;
            case State.HIT:
                Hit();
                break;            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (state)
        {
            case State.IDLE:
                IdleTrigger(other);
                break;
            case State.WALK:
                WalkTrigger(other);
                break;
            case State.ATTACK1:
                Attack1Trigger(other);
                break;
            case State.ATTACK2:
                Attack2Trigger(other);
                break;
            case State.HIT:
                HitTrigger(other);
                break;            
        }
    }

    private void ChangeState(State state)
    {
        
        switch (this.state)
        {
            case State.IDLE:
                IdleExit();
                break;
            case State.WALK:
                WalkExit();
                break;
            case State.ATTACK1:
                Attack1Exit();
                break;
            case State.ATTACK2:
                Attack2Exit();
                break;
            case State.HIT:
                HitExit();
                break;            
        }

        this.state = state;

        
        switch (state)
        {
            case State.IDLE:
                IdleEnter();
                break;
            case State.WALK:
                WalkEnter();
                break;
            case State.ATTACK1:
                Attack1Enter();
                break;
            case State.ATTACK2:
                Attack2Enter();
                break;
            case State.HIT:
                HitEnter();
                break;            
        }
    }






    private void IdleEnter()
    {

    }
    private void Idle()
    {

    }
    private void IdleTrigger(Collider other)
    {

    }    
    private void IdleExit()
    {

    }




    private void WalkEnter()
    {
        throw new NotImplementedException();
    }
    private void Walk()
    {
        throw new NotImplementedException();
    }
    private void WalkTrigger(Collider other)
    {
        throw new NotImplementedException();
    }
    private void WalkExit()
    {
        throw new NotImplementedException();
    }




    private void Attack1Enter()
    {
        throw new NotImplementedException();
    }
    private void Attack1()
    {
        throw new NotImplementedException();
    }
    private void Attack1Trigger(Collider other)
    {
        throw new NotImplementedException();
    }
    private void Attack1Exit()
    {
        throw new NotImplementedException();
    }




    private void Attack2Enter()
    {
        throw new NotImplementedException();
    }
    private void Attack2()
    {
        throw new NotImplementedException();
    }
    private void Attack2Trigger(Collider other)
    {
        throw new NotImplementedException();
    }
    private void Attack2Exit()
    {
        throw new NotImplementedException();
    }




    private void HitEnter()
    {
        throw new NotImplementedException();
    }
    private void Hit()
    {
        throw new NotImplementedException();
    }
    private void HitTrigger(Collider other)
    {
        throw new NotImplementedException();
    }
    private void HitExit()
    {
        throw new NotImplementedException();
    }
}
