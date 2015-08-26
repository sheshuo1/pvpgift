using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hprose.Client;

namespace pvpgift
{
    class sendmail
    {

        //HproseTcpClient client0 = new HproseTcpClient("tcp://gl.huwan.net.cn:8086/");
        //HproseTcpClient client = new HproseTcpClient("tcp://gl.huwan.net.cn:8083/");
        HproseTcpClient client0 = new HproseTcpClient("tcp://192.168.2.117:8082/");
        HproseTcpClient client = new HproseTcpClient("tcp://192.168.2.117:8083/");


        /// <summary>
        /// 发送系统邮件
        /// </summary>
        /// <param name="u_id"></param>
        /// <param name="body">发送对象|标题|内容|附件1|附件2|附件3|附件4|附件5|附件6|附件7|附件8|附件9|附件10</param>
        /// <returns>0：访问失败；1发送成功，2参数不能为空，3没有此玩家</returns>
        public string systemSendMail(string token,string user_id,string body)
        {
            string fh = "";
            if (token != "")
            {
                var m = new NetMessage();
                m.tag = msg_tag.sys_system_pms;
                m.body = body;
                List<NetMessage> s_list = client.Invoke<List<NetMessage>>("post", new object[] { user_id, token, m });


                foreach (var i in s_list)
                {
                    //string tag = i.tag;
                    if (i.tag == msg_tag.sys_admin)
                    {
                        fh = i.body;
                    }

                }



            }
            return fh;
        }

    }
}
