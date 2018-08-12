using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTDELETE : MonoBehaviour
{
    Status status;

    private void Start()
    {
        status = GetComponent<Status>();

        IObject[] objCond0 = new IObject[2];
        objCond0[0] = GetComponent<Enemy>() as IObject;
        objCond0[1] = GetComponent<Nearest>() as IObject;
        status.logicMatrix[0].objectCondition = objCond0;
        status.logicMatrix[0].condition = GetComponent<Always>() as ICondition;
        status.logicMatrix[0].action = GetComponent<Primary>() as IAction;
        status.logicMatrix[0].objectAction = objCond0;

        status.logicMatrix[1] = status.logicMatrix[0];
        status.logicMatrix[2] = status.logicMatrix[0];
        status.logicMatrix[3] = status.logicMatrix[0];
        status.logicMatrix[4] = status.logicMatrix[0];

        IObject[] objCond5 = new IObject[2];
        objCond5[0] = GetComponent<EnemyBase>() as IObject;
        objCond5[1] = GetComponent<None>() as IObject;
        status.logicMatrix[5].objectCondition = objCond5;
        status.logicMatrix[5].condition = GetComponent<Always>() as ICondition;
        status.logicMatrix[5].action = GetComponent<Primary>() as IAction;
        status.logicMatrix[5].objectAction = objCond5;

    }
}
