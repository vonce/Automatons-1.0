”# Automatons-1.0”

I had always loved RTS games like Starcraft and Age of Empires, and really wanted to satisfy that itch with a mobile game. However, the way people play mobile games, the “real time” aspect of RTS wasn’t really feasible. I decided to make an asynchronous strategy game with two players. In this game you can build buildings, just like any RTS, but you cannot directly control units to attack. During a player’s turn they can only build buildings and adjust the logic of the units coming out of the building ( more on that later). The first player to destroy the enemy command center wins.

The main mechanic of this game is adjusting the logic of the units. Each unit has a bunch of Logic Gates. These are structs that contain an Object Condition, the object a conditional statement is based on; a Condition, the conditional statement to be tested on the Object Condition; an Action, the action to be performed if the conditional statement is evaluated to be true; and an Object Action, the object the action is performed on. These Logic Gates are organized into a Logic Matrix, which are evaluated by the unit top to bottom.

For example, if a unit had a logic matrix of: (self)(less than 30% health)>(move)(ally command) (self)(always)>(attack)(nearest enemy) This unit would attack the nearest enemy at higher than 30% health, but once it drops below 30%, it would move back to its ally command where it can heal up and go back to battle at over 30% health.

![](https://i.imgur.com/lX0AWVl.png)
Example logic gate. Two rows per logic gate, for a total of 3 logic gates per unit.

The game is played on a moon and both players start at either pole. Every unit has a 4th uneditable logic gate that automatically makes it attack the enemy base, so even if all logic gates resolve as false, the unit will automatically head towards the enemy base. The goal is to make smart units that work together to push the enemy back through superior logic (or sheer numbers).

![](https://i.imgur.com/qtiaB8I.png)
Blue team destroying Red team’s base
