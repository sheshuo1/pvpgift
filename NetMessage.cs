using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pvpgift
{
    public class NetMessage
    {
        public NetMessage()
        {
        }
        /// <summary>
        /// 消息头
        /// </summary>
        public msg_tag tag { get; set; }

        /// <summary>
        /// 消息体，把实体类通过Json进行序列化，根据功能需要，系统中定义有各种实体，包括数据库实体、逻辑功能实体
        /// </summary>
        public string body { get; set; }
    }
}
