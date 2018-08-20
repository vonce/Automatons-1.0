# Automatons-1.0

I had always loved RTS games like Starcraft and Age of Empires, and really wanted to satisfy that itch with a mobile game. However, the way people play mobile games, the “real time” aspect of RTS wasn’t really feasible. When someone usually plays a mobile game, they want to play on their own time on the bus, train or toilet. I decided to make an strategy game with two players competing, but asynchronously. In this game you can build buildings, just like any RTS, but you cannot directly control units to attack. During a player’s turn they can only build buildings and adjust the logic of the units coming out of the building ( more on that later). The first player to destroy the enemy command center wins.

The main mechanic of this game is adjusting the logic of the units. Each unit has a bunch of Logic Gates. These are structs that contain an Object Condition, the object a conditional statement is based on; a Condition, the conditional statement to be tested on the Object Condition; an Action, the action to be performed if the conditional statement is evaluated to be true; and an Object Action, the object the action is performed on. These Logic Gates are organized into a Logic Matrix, which are evaluated by the unit top to bottom.

For example, if a unit had a logic matrix of: (self)(less than 30% health)>(move)(ally command) (self)(always)>(attack)(nearest enemy) This unit would attack the nearest enemy at higher than 30% health, but once it drops below 30%, it would move back to its ally command where it can heal up and go back to battle at over 30% health.

![](https://i.imgur.com/lX0AWVl.png)
Example logic gate. Two rows per logic gate, for a total of 3 logic gates per unit.

The game is played on a moon and both players start at either pole. Every unit has a 4th uneditable logic gate that automatically makes it attack the enemy base, so even if all logic gates resolve as false, the unit will automatically head towards the enemy base. The goal is to make smart units that work together to push the enemy back through superior logic (or sheer numbers).

![](https://i.imgur.com/qtiaB8I.png)
Blue team destroying Red team’s base

### Unit Logic

A unit "brain" is pretty simple. For each gate, the condition is checked against the object condition, and if true, the action is checked against the object action. If that is true, then the unit's target is set to the object action, and the unit's action is set to the action in the gate. if any of the checks resolve as false, we move on to the next gate.

```C#
//interfaces for logicgates.
public interface IObject
{
    ObjectE enumID();
    GameObject Object(HashSet<GameObject> set, int option);
}

public interface ICondition
{
    ConditionE enumID();
    bool Condition(GameObject target, int option);
}

public interface IAction
{
    ActionE enumID();
    bool ActionCheck(GameObject target, int option);
    void Action(GameObject target, int option);
}
```
Interface for Object, Condition, and Action

```C#
public struct LogicGate
{
    public IObject objectCondition;//the object the conditional statement is based
    public int objectConditionOption;
    public ICondition condition;//the condition
    public int conditionOption;
    public IAction action;//the action
    public int actionOption;
    public IObject objectAction;//the object the action is performed on
    public int objectActionOption;
}
```
Logic Gate Structure

```C#
public void CheckLogicMatrix()//iterates through all logic matrices 
    {
        foreach (LogicGate logicGate in status.logicMatrix)
        {
            if (CheckCondition(logicGate.objectCondition, logicGate.objectConditionOption, logicGate.condition, logicGate.conditionOption) == true)
            {
                if (CheckAction(logicGate.objectAction, logicGate.objectActionOption, logicGate.action, logicGate.actionOption) == true)
                {
                    status.action = logicGate.action;
                    status.target = logicGate.objectAction.Object(status.inSightRange, logicGate.objectActionOption);
                    break;
                }
            }
        }
    }
```
Check logic matrix method.

This method is called once per second per unit, staggered, so it isn't called at the exact same time for potentially hundreds of units. When adding a new object condition or action, it must implement the respective interface, added to the list of enums, and assigned the proper enumID so it can be chosen from the dropdown lists.

### Physics

The game is played on a spherical coordinate system, but it suprisingly does not need much converting to and from cartesian coordinates. The only entity that is in a spherical coordinate system is the player camera. Adjusting the camera moves the camera in radians on the phi and theta axes which are then converted to cartesian coordinates for Unity. Zooming in and out is as simple as changing the radius in the spherical coordinate system.

The units do not need to actively have spherical coordinates constantly being calculated. They use their own gravity system that attracts them to the center of the moon. Conveniently, because the center of the moon is (0,0,0), the position of the unit is also its "up" vector, so rotations are just adjusted based on where the unit is around the Moon. All movement is done by taking the vector between the unit and the target, projecting it onto the plane where the normal vector is "up" and normalizing the new projected vector. this vector will be tangent to the Moon, and with the gravity pulling the unit back down, and the unit being rotated in the correct up direction, the unit stays on the Moon correctly without calling a spherical coordinate method.
