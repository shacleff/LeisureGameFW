/**
 * 
 * Author:JoeyHuang
 * Time: 2019/10/23 17:10:44
 * 说明：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RedPointTest
{

    public RedPointTest()
    {
        RedPointSystem.GetInstance().Init();

        RedPointSystem.GetInstance().SetRedPointCallBack(RedPointConst.MAIL_ALLIANCE, MailAllianceCB);
        RedPointSystem.GetInstance().SetRedPointCallBack(RedPointConst.TASK, TaskCB);
        RedPointSystem.GetInstance().SetRedPointCallBack(RedPointConst.MAIL_SYSTEM, MailSystemCB);

        RedPointSystem.GetInstance().SetInvoke(RedPointConst.TASK, 1);
        RedPointSystem.GetInstance().SetInvoke(RedPointConst.MAIL_ALLIANCE, 2);
        

    }

    private void MailSystemCB(RedPointNode _node)
    {
        //UI层表现
    }

    private void TaskCB(RedPointNode _node)
    {
        //UI层表现
    }

    private void MailAllianceCB(RedPointNode _node)
    {
        //UI层表现
    }
}
