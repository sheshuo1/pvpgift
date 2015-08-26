using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pvpgift
{
    public enum msg_tag : int
    {
        /// <summary>
        /// 战斗信息
        /// </summary>
        sys_info,
        /// <summary>
        /// 
        /// </summary>
        sys_comm,
        /// <summary>
        ///  登录成功，消息体里放的是token
        /// </summary>
        sys_login,
        /// <summary>
        /// 登录失败，玩家需要检查用户名或密码是否正确
        /// </summary>
        //sys_login_fault, 
        /// <summary>
        /// token失效，客户端需要进行重新登录的尝试
        /// </summary>
        sys_token_invalid,
        //非法访问
        sys_illegal,
        /// <summary>
        ///注册成功
        /// </summary>
        sys_register,
        /// <summary>
        /// 所有卡
        /// </summary>
        sys_cards_all,
        /// <summary>
        /// 选择服务器成功
        /// </summary>
        sys_chooSer, 
        /// <summary>
        /// 选择服务器失败
        /// </summary>
        //sys_chooSer_fault, 
        /// <summary>
        /// 创建角色
        /// </summary>
        sys_createRole,
        /// <summary>
        /// 服务器
        /// </summary>
        sys_servers,
        /// <summary>
        /// 最后一次登录的服务器
        /// </summary>
        sys_servers_login,
        /// <summary>
        /// 服务器列表获取失败
        /// </summary>
        sys_servers_fault,
        /// <summary>
        /// 组卡器
        /// </summary>
        sys_userCards_group,
        /// <summary>
        /// 用户信息
        /// </summary>
        sys_user_info,
        /// <summary>
        /// 用户卡组
        /// </summary>
        sys_user_group,
        /// <summary>
        /// 玩家卡组内卡牌
        /// </summary>
        sys_group_cards,
        /// <summary>
        /// 更新玩家卡组
        /// </summary>
        sys_groupCard_update,
        /// <summary>
        /// 卡组保存错误
        /// </summary>
        sys_gc_update_error,
        /// <summary>
        /// 卡组保存
        /// </summary>
        sys_gc_update_ok,
        /// <summary>
        /// 决斗奖励
        /// </summary>
        sys_duel_award,
        /// <summary>
        /// 战斗引擎出错
        /// </summary>
        sys_duel_fault,
        /// <summary>
        /// 离线挂机奖励
        /// </summary>
        sys_offline_raward,
        /// <summary>
        /// 离线挂机超出奖励
        /// </summary>
        //sys_offline_raward2,
        /// <summary>
        /// 离线挂机战斗怪物
        /// </summary>
        //sys_offline_monster,
        /// <summary>
        /// 自己的上场卡
        /// </summary>
        sys_own_cards,
        /// <summary>
        /// 对手的上场卡
        /// </summary>
        sys_rival_cards,
        /// <summary>
        /// 离线挂机基本信息
        /// </summary>
        sys_offline_info,
        /// <summary>
        /// 下场比赛时间
        /// </summary>
        sys_nextduel_time,
        /// <summary>
        /// 下一场挂机还剩余的时间
        /// </summary>
        sys_surplus_time,
        /// <summary>
        /// 卡牌强化
        /// </summary>
        sys_card_intensify,
        /// <summary>
        /// 卡牌强化消耗对照表
        /// </summary>
        sys_card_intensifyExp,
        /// <summary>
        /// 卡牌培养
        /// </summary>
        sys_card_cultivate,
        /// <summary>
        /// 卡牌进阶
        /// </summary>
        sys_card_advance,
        /// <summary>
        /// 玩家道具
        /// </summary>
        sys_user_item,
        /// <summary>
        /// 地图列表
        /// </summary>
        sys_map_list,
        /// <summary>
        /// 挑战BOOS
        /// </summary>
        sys_challenge_boss,
        /// <summary>
        /// 出售道具
        /// </summary>
        sys_sell_item,
        /// <summary>
        /// 道具合成
        /// </summary>
        sys_item_compound,
        /// <summary>
        /// 扩充背包
        /// </summary>
        sys_enlarge_knapsac,
        /// <summary>
        /// 更换地图
        /// </summary>
        sys_update_map,
        /// <summary>
        /// 道具使用
        /// </summary>
        sys_item_use,
        /// <summary>
        /// 次元商店
        /// </summary>
        sys_element_shop,
        /// <summary>
        /// 购买次元商品
        /// </summary>
        sys_element_buy,
        /// <summary>
        /// 已购买体力数
        /// </summary>
        sys_buyMain_num,
        /// <summary>
        /// 体力钻石购买
        /// </summary>
        sys_gem_buyMain,
        /// <summary>
        /// 免费体力
        /// </summary>
        sys_free_main,
        /// <summary>
        /// 初始化PVP界面
        /// </summary>
        sys_pvp_init,
        /// <summary>
        /// PVP战斗消息
        /// </summary>
        sys_pvp_info,
        /// <summary>
        /// 玩家信息
        /// </summary>
        sys_pvp_user,
        /// <summary>
        /// PVP对手玩家列表
        /// </summary>
        sys_pvp_rival,
        /// <summary>
        /// PVP时间重置
        /// </summary>
        sys_pvp_reset,
        /// <summary>
        /// PVP卡组设置
        /// </summary>
        sys_pvp_cgsettings,
        /// <summary>
        /// 排行
        /// </summary>
        sys_ranking,
        /// <summary>
        /// PVP商店
        /// </summary>
        sys_pvp_shop,
        /// <summary>
        /// 刷新PVP商店
        /// </summary>
        sys_pvp_shopUpdate,
        /// <summary>
        /// PVP商店购买
        /// </summary>
        sys_pvp_shopping,
        /// <summary>
        /// PVP录像
        /// </summary>
        sys_pvp_video,
        /// <summary>
        /// PVP录像信息
        /// </summary>
        sys_pvp_videoinfo,
        /// <summary>
        /// 钻石购买金币
        /// </summary>
        sys_gem_buygold,
        /// <summary>
        /// 购买钻石
        /// </summary>
        sys_buy_gem,
        /// <summary>
        /// 卡牌升级
        /// </summary>
        sys_card_upgrade,
        /// <summary>
        /// 卡牌合成
        /// </summary>
        sys_card_compound,
        /// <summary>
        /// 管理员数据
        /// </summary>
        sys_admin,
        /// <summary>
        /// 系统邮件
        /// </summary>
        sys_system_pms,
        /// <summary>
        /// 邮件附件
        /// </summary>
        sys_pms_adjunct,
        /// <summary>
        /// 读邮件
        /// </summary>
        sys_pms_read,
        /// <summary>
        /// 删除邮件
        /// </summary>
        sys_pms_delete,
        /// <summary>
        /// 发送邮件
        /// </summary>
        sys_pms_send,
        /// <summary>
        /// 发送系统邮件
        /// </summary>
        sys_syspms_send,
        /// <summary>
        /// 更换玩家头像
        /// </summary>
        sys_update_headpic,
        /// <summary>
        /// 开始派遣事件
        /// </summary>
        sys_dispatch_event,
        /// <summary>
        /// 战斗事件
        /// </summary>
        sys_combat_event,
        /// <summary>
        /// 刷新事件系统
        /// </summary>
        sys_show_event,
        /// <summary>
        /// 获取战斗事件战斗对象信息
        /// </summary>
        sys_get_combatrival,
        /// <summary>
        /// 领取事件奖励
        /// </summary>
        sys_geteventaward,
        /// <summary>
        /// 召回派遣卡
        /// </summary>
        sys_event_recall,
        /// <summary>
        /// 放弃事件
        /// </summary>
        sys_event_abandon,
        /// <summary>
        /// 重置BOSS挑战次数
        /// </summary>
        sys_reset_Boss
    }


    public class Setting
    {
        static public string redis_server = "127.0.0.1";
    }
}
