using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hprose.Client;
using System.Security.Cryptography;
using pvpgift.DB;

namespace pvpgift
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            //HproseTcpClient client0 = new HproseTcpClient("tcp://gl.huwan.net.cn:8086/");
            //HproseTcpClient client = new HproseTcpClient("tcp://gl.huwan.net.cn:8083/");
            HproseTcpClient client0 = new HproseTcpClient("tcp://192.168.2.117:8082/");
            HproseTcpClient client = new HproseTcpClient("tcp://192.168.2.117:8083/");

            //使用管理员账号登录
            string sysName = "PlayerA";
            string sysPass = "111111";


            string uName = sysName;
            string pass = userMd5(sysPass);
           
            client0.Timeout = 2000;
            NetMessage user = null;
            int is_login = 0;
            string token = "";
            string user_id = "";
            try
            {
                user = client0.Invoke<NetMessage>("login", new object[] { uName, pass });

                
                if (user.tag == msg_tag.sys_login)
                {
                    string[] body = user.body.Split('|');

                    switch (body[0])
                    {
                        case "0":
                            //登录失败（账号或密码有误）
                           
                            is_login = 0;
                            break;
                        case "1":
                            //成功
                            token = body[1];
                            user_id = body[2];
                            is_login = 1;
                            break;
                          
                        case "2":
                            //网络错误
                            is_login = 2;
                            break;
                    }

                }
                
            }
            catch (Exception ex)
            {
               is_login = 3;
               Console.WriteLine("登录失败（未知错误）"+ex);
               Console.ReadKey();
            } 
      
            if(is_login == 0)
            {
                Console.WriteLine("登录失败（账号或密码有误）");
            }else if(is_login == 2)
            {
                Console.WriteLine("登录失败（网络错误）");
            }else if(is_login == 3)
            {
                Console.WriteLine("登录失败（未知错误）");
            }else if(is_login == 1)
            {

                pvpdbDataContext DB = new pvpdbDataContext();
                
                var pvprank = from r in DB.t_pvp_rankingList  orderby r.rangking select r;
                foreach(var i in pvprank)
                {
                    
                    sendgift(i.rangking,i.user_id,token,user_id);
                }
            }

            
           

        }

        private static void sendgift(int rangking, int uId, string token, string user_id)
        {
            int[] gem = new int[] {550,500,450,400,350,340,330,320,310,300,250,200,150,130,110,100,90,80,70,60,50};
            int[] gold = new int[]{100000,95000,90000,85000,80000,75000,70000,65000,60000,55000,50000,45000,40000,35000,30000,27500,25000,22500,20000,17500,15000};
            int[] piece = new int[]{12,10,10,8,8,8,8,8,8,8,6,6,6,6,6,6,4,4,4,4,4};
            int[] hpbox = new int[]{4,4,4,3,3,3,3,3,3,3,2,2,2,2,2,2,1,1,1,1,1};
            int[] pvpcorn = new int[]{800,775,750,725,700,680,660,640,620,600,590,580,570,560,550,540,530,520,510,500,490};
            string token1 = token;
            string userid = user_id;
            string body1 = "";
            
           if(rangking == 1)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[0] + "|A,A3," + gem[0] + "|A,A6," + pvpcorn[0] + "|D,400001," + piece[0] + "|D,500001," + hpbox[0] + "|||||";
               
           }
            else if(rangking == 2)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[1] + "|A,A3," + gem[1] + "|A,A6," + pvpcorn[1] + "|D,400001," + piece[1] + "|D,500001," + hpbox[1] + "|||||";
           
            }
            else if(rangking == 3)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[2] + "|A,A3," + gem[2] + "|A,A6," + pvpcorn[2] + "|D,400001," + piece[2] + "|D,500001," + hpbox[2] + "|||||";
           
            }
            else if(rangking == 4)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[3] + "|A,A3," + gem[3] + "|A,A6," + pvpcorn[3] + "|D,400001," + piece[3] + "|D,500001," + hpbox[3] + "|||||";
            
            }
             else if(rangking == 5)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[4] + "|A,A3," + gem[4] + "|A,A6," + pvpcorn[4] + "|D,400001," + piece[4] + "|D,500001," + hpbox[4] + "|||||";
            
            }
             else if(rangking == 6)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[5] + "|A,A3," + gem[5] + "|A,A6," + pvpcorn[5] + "|D,400001," + piece[5] + "|D,500001," + hpbox[5] + "|||||";
            
            }
             else if(rangking == 7)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[6] + "|A,A3," + gem[6] + "|A,A6," + pvpcorn[6] + "|D,400001," + piece[6] + "|D,500001," + hpbox[6] + "|||||";
            
            }
             else if(rangking == 8)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[7] + "|A,A3," + gem[7] + "|A,A6," + pvpcorn[7] + "|D,400001," + piece[7] + "|D,500001," + hpbox[7] + "|||||";
            
            }
             else if(rangking == 9)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[8] + "|A,A3," + gem[8] + "|A,A6," + pvpcorn[8] + "|D,400001," + piece[8] + "|D,500001," + hpbox[8] + "|||||";
            
            }
             else if(rangking == 10)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[9] + "|A,A3," + gem[9] + "|A,A6," + pvpcorn[9] + "|D,400001," + piece[9] + "|D,500001," + hpbox[9] + "|||||";
            
            }
             else if(rangking >= 11 && rangking <= 20)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[10] + "|A,A3," + gem[10] + "|A,A6," + pvpcorn[10] + "|D,400001," + piece[10] + "|D,500001," + hpbox[10] + "|||||";
            
            }
             else if(rangking >= 21 && rangking <= 30)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[11] + "|A,A3," + gem[11] + "|A,A6," + pvpcorn[11] + "|D,400001," + piece[11] + "|D,500001," + hpbox[11] + "|||||";
            
            }
             else if(rangking >= 31 && rangking <= 40)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[12] + "|A,A3," + gem[12] + "|A,A6," + pvpcorn[12] + "|D,400001," + piece[12] + "|D,500001," + hpbox[12] + "|||||";
            
            }
             else if(rangking >= 41 && rangking <= 50)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[13] + "|A,A3," + gem[13] + "|A,A6," + pvpcorn[13] + "|D,400001," + piece[13] + "|D,500001," + hpbox[13] + "|||||";
            
            }
             else if(rangking >= 51 && rangking <= 70)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[14] + "|A,A3," + gem[14] + "|A,A6," + pvpcorn[14] + "|D,400001," + piece[14] + "|D,500001," + hpbox[14] + "|||||";
            
            }
             else if(rangking >= 71 && rangking <= 100)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[15] + "|A,A3," + gem[15] + "|A,A6," + pvpcorn[15] + "|D,400001," + piece[15] + "|D,500001," + hpbox[15] + "|||||";
            
            }
             else if(rangking >= 101 && rangking <= 200)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[16] + "|A,A3," + gem[16] + "|A,A6," + pvpcorn[16] + "|D,400001," + piece[16] + "|D,500001," + hpbox[16] + "|||||";
            
            }
             else if(rangking >= 201 && rangking <= 300)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[17] + "|A,A3," + gem[17] + "|A,A6," + pvpcorn[17] + "|D,400001," + piece[17] + "|D,500001," + hpbox[17] + "|||||";
            
            }
             else if(rangking >= 301 && rangking <= 400)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[18] + "|A,A3," + gem[18] + "|A,A6," + pvpcorn[18] + "|D,400001," + piece[18] + "|D,500001," + hpbox[18] + "|||||";
            
            }
            else if(rangking >= 401 && rangking <= 500)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[19] + "|A,A3," + gem[19] + "|A,A6," + pvpcorn[19] + "|D,400001," + piece[19] + "|D,500001," + hpbox[19] + "|||||";
            
            }
            else if(rangking >= 501)
           {
                body1 = uId + "|竞技场排名奖励|截至今日21:00.你的竞技场排名为" + rangking + ",你将获得以下竞技场排名奖励。|A,A2," + gold[20] + "|A,A3," + gem[20] + "|A,A6," + pvpcorn[20] + "|D,400001," + piece[20] + "|D,500001," + hpbox[20] + "|||||";
            
            }

           if (body1 != "")
           {
               pvpdbDataContext DB = new pvpdbDataContext();
               sendmail sm = new sendmail();
               string flag = sm.systemSendMail(token1, userid, body1);
               t_pvp_giftlog gl = new t_pvp_giftlog();
               gl.userID = uId;
               gl.rank = rangking;
               gl.flag = flag;
               gl.date = DateTime.Now;
               DB.t_pvp_giftlog.InsertOnSubmit(gl);
               DB.SubmitChanges();
           }

          
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

        
        }
    
}
