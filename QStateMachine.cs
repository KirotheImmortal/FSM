using System.Collections;
using System.Collections.Generic;


// Programmer: Quinton "Kiro" Baudoin
// Purpose: Modular FSM
// Use summary:
//     QState: Create and manage each State.
//          Each state is given a name of the state and a state it can fallow.
//    QStateMachine:
//          Premade State Machine.
//          You may make your own variant as your program needs.
//          Uses a list to store all the states.
//          Using Getter and Setters to change and run current state based on sname and sprev strings in the QStates


// Prefixes:
// Q     :     Quinton
// d    :     Delegate
// dv_   :     Void
// die_  :     IEnumerator
// s_    :     String
// s     :     State
// ls_   :     List of States
// 
// 
// Suffixes:

/// <summary>
/// State Object
/// </summary>
public class QStates
{
    public QStates(string name, string prev)
    {
        sname = name;
        sprev = prev;
    }
    /// <summary>
    /// This State Name
    /// </summary>
    public string sname;
    /// <summary>
    /// State that this state can begin from
    /// </summary>
    public string sprev;

    public delegate void VoidFunctionList();
    /// <summary>
    /// Delegates of void Function()
    /// </summary>
    public VoidFunctionList dv_stateFunctions;

    public delegate IEnumerator IEnumeratorFunctionList();
    /// <summary>
    /// Delagates of IEnumerator Function()
    /// </summary>
    public IEnumeratorFunctionList die_stateFunctions;


}

/// <summary>
/// Premade State Manager
/// </summary>
public class QStateMachine
{
    /// <summary>
    /// List of all the QStates
    /// </summary>
    List<QStates> ls_States = new List<QStates>();
    private QStates cur;
    private QStates nex;

    /// <summary>
    /// State currently in.
    /// When Modified the state will play its delegates if delegates have functions stored
    /// NOTE: Void functions then IEnumerable functions
    /// </summary>
    QStates current
    {
        get
        { return cur; }
        set
        {
            cur = value;
            if (current.dv_stateFunctions != null)
                current.dv_stateFunctions();

            if (current.die_stateFunctions != null)
                current.die_stateFunctions();

        }
    }

    public QStates currentState
        {
        get { return cur; }
        }
    /// <summary>
    /// State intended to change to. If allowed the current state will be changed to the value the nextState was changed to.
    /// </summary>
    public QStates nextState
    {
        get
        { return nex; }
        set
        {
            nex = value;
            if (current == null)
                current = value;
            else if (current.sname == nex.sprev || nextState.sprev == null)
            {
                current = value;
            }

        }

    }

    /// <summary>
    /// Creates a QState based on the params passed in.
    /// </summary>
    /// <param name="name"> Name of QState</param>
    /// <param name="prevname">Name of QState to fallow</param>
    public void addState(string name, string prevname)
    {
        ls_States.Add(new QStates(name, prevname));
    }
    /// <summary>
    /// Removes a state from the list based on name variable
    /// </summary>
    /// <param name="name"> Name assigned to QState</param>
    public void removeState(string name)
    {
        foreach (QStates s in ls_States)
        {
            if (s.sname == name)
                ls_States.Remove(s);
        }
    }
    /// <summary>
    /// Changes the nextState variable.
    /// To add further detail..
    /// If the state that is passed in to fallow the current state it is then added ass current state.
    /// </summary>
    /// <param name="name"></param>
    public void changeState(string name)
    {
        foreach (QStates s in ls_States)
            if (s.sname == name)
            {
                nextState = s;
                return;
            }
    }
    /// <summary>
    /// Clears the State list
    /// </summary>
    public void clearStateList()
    {
        ls_States.Clear();
    }
    /// <summary>
    /// Gtets the state using name variable.
    /// </summary>
    /// <param name="name">Would be the sname in QStates</param>
    /// <returns></returns>
    public QStates getState(string name)
    {
        foreach (QStates s in ls_States)
            if (s.sname == name)
                return s;

        return null;

    }
    //public addVoid()




}

