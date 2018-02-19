using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    PlayerControlScheme m_PlayerControl1 = new PlayerControlScheme();

    List<KeyCode> m_InputStackList1 = new List<KeyCode>();

    enum ButtonState
    {
        newPress,
        held,
        released
    }

    void InitControls()
    {
        //  m_PlayerControl1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), jsButton);
    }

    private void Update() // pkoi cetait fixedupdate?
    {
        // player 1 specific
        var inputDirection = Direction.Idle;

        if (Input.GetKeyDown(m_PlayerControl1.Up))
        {
            m_InputStackList1.Add(m_PlayerControl1.Up);
        }
        if (Input.GetKeyDown(m_PlayerControl1.Down))
        {
            m_InputStackList1.Add(m_PlayerControl1.Down);
        }
        if (Input.GetKeyDown(m_PlayerControl1.Left))
        {
            m_InputStackList1.Add(m_PlayerControl1.Left);
        }
        if (Input.GetKeyDown(m_PlayerControl1.Right))
        {
            m_InputStackList1.Add(m_PlayerControl1.Right);
        }

        if (Input.GetKeyUp(m_PlayerControl1.Up))
        {
            m_InputStackList1.Remove(m_PlayerControl1.Up);
        }
        if (Input.GetKeyUp(m_PlayerControl1.Down))
        {
            m_InputStackList1.Remove(m_PlayerControl1.Down);
        }
        if (Input.GetKeyUp(m_PlayerControl1.Left))
        {
            m_InputStackList1.Remove(m_PlayerControl1.Left);
        }
        if (Input.GetKeyUp(m_PlayerControl1.Right))
        {
            m_InputStackList1.Remove(m_PlayerControl1.Right);
        }

    //    if (m_InputStackList1.Count >= 1)
        {
            inputDirection = GetDirectionFromLastInput();
            GameManager.Instance.MovePlayer(inputDirection, 1);
        }
    }

    Direction GetDirectionFromLastInput()
    {
        KeyCode? lastInput = null;

        if(m_InputStackList1.Count > 0)
        {
            lastInput = m_InputStackList1[m_InputStackList1.Count - 1];
        }

        Direction direction = Direction.Idle;

        if(lastInput.HasValue)
        {
            if (lastInput == m_PlayerControl1.Up)
            {
                direction = Direction.Up;
            }
            else if (lastInput == m_PlayerControl1.Down)
            {
                direction = Direction.Down;
            }
            else if (lastInput == m_PlayerControl1.Left)
            {
                direction = Direction.Left;
            }
            else if (lastInput == m_PlayerControl1.Right)
            {
                direction = Direction.Right;
            }
        }

        return direction;
    }
}

[System.Serializable]
public class PlayerControlScheme
{
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;
    public KeyCode Shoot = KeyCode.Space;
}
