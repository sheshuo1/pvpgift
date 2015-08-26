using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using Hprose.Client;

namespace HproseTestClient
{
    public partial class getshuju : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //HproseTcpClient client0 = new HproseTcpClient("tcp://219.139.190.194:8086/");
        //HproseTcpClient client = new HproseTcpClient("tcp://219.139.190.194:8083/");
        //HproseTcpClient client0 = new HproseTcpClient("tcp://192.168.2.120:8082/");
        //HproseTcpClient client = new HproseTcpClient("tcp://192.168.2.120:8083/");

        HproseTcpClient client0 = new HproseTcpClient("tcp://gl.huwan.net.cn:8086/");
        HproseTcpClient client = new HproseTcpClient("tcp://gl.huwan.net.cn:8083/");     

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string uName = txtName.Text.Trim();
            string pass = userMd5(txtPasss.Text.Trim());

            //client0.SendTimeout = 2000;
            client0.Timeout = 2000;
            net_message user = null;
            try
            {
                user = client0.Invoke<net_message>("login", new object[] { uName, pass });

                string token = "";
                if (user.tag == msg_tag.sys_login)
                {
                    string[] body = user.body.Split('|');

                    switch (body[0])
                    {
                        case "0":
                            //登录失败（账号或密码有误）
                            lbllogin.Text = "账号或密码有误";
                            break;
                        case "1":
                            //成功
                            token = body[1];
                            string user_id = body[2];
                            lbllogin.Text = "1";
                            ViewState["token"] = token;
                            ViewState["user_id"] = user_id;

                            break;
                        case "2":
                            //网络错误
                            lbllogin.Text = "网络错误";
                            break;

                    }

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                lbllogin.Text = "登录超时";
            }

        }

        protected void btnGold_Click(object sender, EventArgs e)
        {
            int gold = int.Parse(txtGold.Text);
            string type = "gold";
            string jiguo = "";
            jiguo = 提交数据(gold, type,0);
            lblGold.Text = jiguo;
        }



        protected void btnGem_Click(object sender, EventArgs e)
        {
            int gem = int.Parse(txtGem.Text);
            string type = "gem";
            string jiguo = "";
            jiguo = 提交数据(gem, type,0);
            lblGem.Text = jiguo;
        }

        protected void btnMain_Click(object sender, EventArgs e)
        {
            int main = int.Parse(txtMain.Text);
            string type = "main";
            string jiguo = "";
            jiguo = 提交数据(main, type,0);
            lblMain.Text = jiguo;
        }

        protected void btnCard_Click(object sender, EventArgs e)
        {
            int card = int.Parse(txtCardID.Text);
            string type = "card";
            string jiguo = "";
            jiguo = 提交数据(card, type,0);
            lblCard.Text = jiguo;
        }

        protected void btnItem_Click(object sender, EventArgs e)
        {
            int item = int.Parse(txtItem.Text);
            int num = int.Parse(txtNUm.Text);
            string type = "item";
            string jiguo = "";
            jiguo = 提交数据(item, type, num);
            lblItem.Text = jiguo;
        }
        protected void btnPVP_Click(object sender, EventArgs e)
        {
            int item = int.Parse(txtPVP.Text);
            string type = "pvp";
            string jiguo = "";
            jiguo = 提交数据(item, type, 0);
            lblPVP.Text = jiguo;
        }

        private string 提交数据(int gold, string type, int num)
        {
            string jiguo = "";
            string token = ViewState["token"].ToString();
            string user_id = ViewState["user_id"].ToString();
            if (token != "")
            {
                var m = new net_message();
                m.tag = msg_tag.sys_system_pms;
                m.body = type + "|" + gold + "|" + num;
                List<net_message> s_list = client.Invoke<List<net_message>>("post", new object[] { user_id, token, m });


                foreach (var i in s_list)
                {
                    //string tag = i.tag;
                    if (i.tag == msg_tag.sys_admin)
                    {
                        jiguo = i.body;
                    }

                }



            }
            return jiguo;
        }

        /// <summary>
        /// MD5　32位加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string userMd5(string str)
        {
            string cl = str;
            string pwd = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 

                pwd = pwd + s[i].ToString("X");

            }
            return pwd;
        }
        /// <summary>
        /// 发送系统邮件
        /// </summary>
        /// <param name="u_id"></param>
        /// <param name="content">发送对象|标题|内容|附件1|附件2|附件3|附件4|附件5|附件6|附件7|附件8|附件9|附件10</param>
        /// <returns>0：访问失败；1发送成功，2参数不能为空，3没有此玩家</returns>
        pu systemSendMail

    }
}