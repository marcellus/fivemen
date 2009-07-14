using System;
using System.Collections.Generic;
using System.Text;

namespace FT.NotePad
{
    /// <summary>
    /// 事件的节点类型,
    /// 1、计划书
    /// 2、代办事项
    /// 3、记事本
    /// </summary>
    public enum ThingType
    {
        Schedule=1,
        Task=2,
        JustThing=4,
        Folder=8
    }


}
