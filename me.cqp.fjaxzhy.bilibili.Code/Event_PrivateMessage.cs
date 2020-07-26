using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using Native.Sdk.Cqp.Model;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Native.Sdk.Cqp.Enum;

namespace me.cqp.fjaxzhy.bilibili.Code
{
    public class Event_PrivateMessage : IPrivateMessage
    {
        string Json, av, datetime, tidstr, copyrightstr;
        string bvid, aid, title, pic, videos, tid, tname, copyright, pubdate, desc, duration;//data.
        string mid, name, face;//data.owner.
        string view, danmaku, reply, favorite, coin, share, like;//data.stat.
        int[] pages;//data.pages.
        string cid, page, part, duration_page;//if_data.pages=Int[],data.pages.[0/1/2]
        int[] staff;//data.staff.
        string mid_staff, title_staff, name_staff, face_staff, official, follower;//if_data.staff=Int[],data.staff.[0/1/2]
        /// <summary>
        /// 收到私聊消息
        /// </summary>
        /// <param name="sender">事件来源</param>
        /// <param name="e">事件参数</param>
        public void PrivateMessage(object sender, CQPrivateMessageEventArgs e)
        {
            string Msg = e.Message;
            if (Msg.Length >= 2)
            {
                if (Msg.Substring(0, 2) == "av")
                {
                    //HttpGet_Json
                    BiliBili_HttpGet_AV _HttpGet = new BiliBili_HttpGet_AV();
                    Json = _HttpGet.HttpGet(aid = Msg.Substring(2, Msg.Length - 2));
                    var _Jsonobj = JsonConvert.DeserializeObject<dynamic>(Json);
                    if (_Jsonobj.code == 0)
                    {
                        //History_Write
                        File.AppendAllText(e.CQApi.AppDirectory + "HistorySearch.txt", e.FromQQ + "的" + e.FromQQ + "获取了" + Msg + "\n", Encoding.UTF8);
                        //Image_Download
                        //Image_Download imagedl = new Image_Download();
                        //pic = _Jsonobj.data.pic;
                        //imagedl.Image_DL(pic,pic.Substring(32,pic.Length-32));
                        //CQFunction cqimage = CQFunction.Image;
                        //Voluation_Json->String/Int[]
                        //data.
                        bvid = _Jsonobj.data.bvid;  //bv号
                        av = "av" + _Jsonobj.data.aid; //av号
                        title = _Jsonobj.data.title;  //标题
                        videos = _Jsonobj.data.videos;  //分P数量
                        tid = _Jsonobj.data.tid;  //主分区
                        tname = _Jsonobj.data.tname;  //子分区
                        copyright = _Jsonobj.data.copyright;  //版权信息
                        pubdate = _Jsonobj.data.pubdate;  //投稿时间(时间戳
                        desc = _Jsonobj.data.desc;  //简介
                        duration = _Jsonobj.data.duration;  //视频持续时长(所有分P
                        //data.owner.
                        mid = _Jsonobj.data.owner.mid;  //up主UID
                        name = _Jsonobj.data.owner.name;  //up主昵称
                        face = _Jsonobj.data.owner.face;  //up主头像地址
                        //data.stat.
                        view = _Jsonobj.data.stat.view;  //观看数量
                        danmaku = _Jsonobj.data.stat.danmaku;  //弹幕数量
                        reply = _Jsonobj.data.stat.reply;  //评论数量
                        favorite = _Jsonobj.data.stat.favorite;  //收藏数量
                        coin = _Jsonobj.data.stat.coin;  //投币数量
                        share = _Jsonobj.data.stat.share;  //分享数量
                        like = _Jsonobj.data.stat.like;  //获赞数量
                        //data.pages[].
                        //pages = new int[] { _Jsonobj.data.pages };
                        //data.pages[0/1/2].
                        //if (videos != "0")
                        {
                            //目前不处理
                        }
                        //data.staff[].
                        //staff = new int[] { _Jsonobj.data.staff };
                        //data.staff[0/1/2].
                        //if( staff.Length != 1)
                        {
                            //目前不处理
                        }
                        //时间戳转换
                        Pubdate_Convert pubdate_Convert = new Pubdate_Convert();
                        datetime = pubdate_Convert.Pubdate(pubdate);
                        //主分区转换
                        Tid_Judge tid_judge = new Tid_Judge();
                        tidstr = tid_judge.Tid(Convert.ToInt32(tid));
                        //版权信息判断
                        Copyright_Judge copyright_judge = new Copyright_Judge();
                        copyrightstr = copyright_judge.Copyright(Convert.ToInt32(copyright));
                        //SendDiscussMessage
                        e.FromQQ.SendPrivateMessage(title + "[共" + videos + "P]" + "\n" + "bv号:" + bvid + "\n" + "av号:" + av + "\n" + "UP主:" + name + "\nUP主UID:" + mid + "\n" + "-----------------\n" + tidstr + ":" + tname + "\n" + "点赞:" + like + "  投币:" + coin + "\n收藏:" + favorite + "  观看:" + view + "\n弹幕:" + danmaku + "  评论:" + reply + "\n分享:" + share + "\n-----------------\n" + "简介:" + desc);

                    }
                    else
                    {
                        e.FromQQ.SendPrivateMessage("错误:\n" + "Code:" + _Jsonobj.code + "\n" + _Jsonobj.Message + "\n" + "错误码:\n400为请求错误\n404为找不到稿件\n62002为稿件不可见");
                    }

                }
                else if (Msg.Substring(0, 2) == "AV")
                {
                    BiliBili_HttpGet_AV _HttpGet = new BiliBili_HttpGet_AV();
                    Json = _HttpGet.HttpGet(aid = Msg.Substring(2, Msg.Length - 2));
                    var _Jsonobj = JsonConvert.DeserializeObject<dynamic>(Json);
                    if (_Jsonobj.code == 0)
                    {
                        //History_Write
                        File.AppendAllText(e.CQApi.AppDirectory + "HistorySearch.txt", e.FromQQ + "的" + e.FromQQ + "获取了" + Msg + "\n", Encoding.UTF8);
                        //Image_Download
                        //Image_Download imagedl = new Image_Download();
                        //pic = _Jsonobj.data.pic;
                        //imagedl.Image_DL(pic,pic.Substring(32,pic.Length-32));
                        //CQFunction cqimage = CQFunction.Image;
                        //Voluation_Json->String/Int[]
                        //data.
                        bvid = _Jsonobj.data.bvid;  //bv号
                        av = "av" + _Jsonobj.data.aid; //av号
                        title = _Jsonobj.data.title;  //标题
                        videos = _Jsonobj.data.videos;  //分P数量
                        tid = _Jsonobj.data.tid;  //主分区
                        tname = _Jsonobj.data.tname;  //子分区
                        copyright = _Jsonobj.data.copyright;  //版权信息
                        pubdate = _Jsonobj.data.pubdate;  //投稿时间(时间戳
                        desc = _Jsonobj.data.desc;  //简介
                        duration = _Jsonobj.data.duration;  //视频持续时长(所有分P
                        //data.owner.
                        mid = _Jsonobj.data.owner.mid;  //up主UID
                        name = _Jsonobj.data.owner.name;  //up主昵称
                        face = _Jsonobj.data.owner.face;  //up主头像地址
                        //data.stat.
                        view = _Jsonobj.data.stat.view;  //观看数量
                        danmaku = _Jsonobj.data.stat.danmaku;  //弹幕数量
                        reply = _Jsonobj.data.stat.reply;  //评论数量
                        favorite = _Jsonobj.data.stat.favorite;  //收藏数量
                        coin = _Jsonobj.data.stat.coin;  //投币数量
                        share = _Jsonobj.data.stat.share;  //分享数量
                        like = _Jsonobj.data.stat.like;  //获赞数量
                        //data.pages[].
                        //pages = new int[] { _Jsonobj.data.pages };
                        //data.pages[0/1/2].
                        //if (videos != "0")
                        {
                            //目前不处理
                        }
                        //data.staff[].
                        //staff = new int[] { _Jsonobj.data.staff };
                        //data.staff[0/1/2].
                        //if( staff.Length != 1)
                        {
                            //目前不处理
                        }
                        //时间戳转换
                        Pubdate_Convert pubdate_Convert = new Pubdate_Convert();
                        datetime = pubdate_Convert.Pubdate(pubdate);
                        //主分区转换
                        Tid_Judge tid_judge = new Tid_Judge();
                        tidstr = tid_judge.Tid(Convert.ToInt32(tid));
                        //版权信息判断
                        Copyright_Judge copyright_judge = new Copyright_Judge();
                        copyrightstr = copyright_judge.Copyright(Convert.ToInt32(copyright));
                        //SendDiscussMessage
                        e.FromQQ.SendPrivateMessage(title + "[共" + videos + "P]" + "\n" + "bv号:" + bvid + "\n" + "av号:" + av + "\n" + "UP主:" + name + "\nUP主UID:" + mid + "\n" + "-----------------\n" + tidstr + ":" + tname + "\n" + "点赞:" + like + "  投币:" + coin + "\n收藏:" + favorite + "  观看:" + view + "\n弹幕:" + danmaku + "  评论:" + reply + "\n分享:" + share + "\n-----------------\n" + "简介:" + desc);

                    }
                    else
                    {
                        e.FromQQ.SendPrivateMessage("错误:\n" + "Code:" + _Jsonobj.code + "\n" + _Jsonobj.Message + "\n" + "错误码:\n400为请求错误\n404为找不到稿件\n62002为稿件不可见");
                    }

                }
                else if (Msg.Substring(0, 2) == "BV")
                {
                    BiliBili_HttpGet_BV _HttpGet = new BiliBili_HttpGet_BV();
                    Json = _HttpGet.HttpGet(bvid = Msg.Substring(2, Msg.Length - 2));
                    var _Jsonobj = JsonConvert.DeserializeObject<dynamic>(Json);
                    if (_Jsonobj.code == 0)
                    {
                        //History_Write
                        File.AppendAllText(e.CQApi.AppDirectory + "HistorySearch.txt", e.FromQQ + "的" + e.FromQQ + "获取了" + Msg + "\n", Encoding.UTF8);
                        //Image_Download
                        //Image_Download imagedl = new Image_Download();
                        //pic = _Jsonobj.data.pic;
                        //imagedl.Image_DL(pic,pic.Substring(32,pic.Length-32));
                        //CQFunction cqimage = CQFunction.Image;
                        //Voluation_Json->String/Int[]
                        //data.
                        bvid = _Jsonobj.data.bvid;  //bv号
                        av = "av" + _Jsonobj.data.aid; //av号
                        title = _Jsonobj.data.title;  //标题
                        videos = _Jsonobj.data.videos;  //分P数量
                        tid = _Jsonobj.data.tid;  //主分区
                        tname = _Jsonobj.data.tname;  //子分区
                        copyright = _Jsonobj.data.copyright;  //版权信息
                        pubdate = _Jsonobj.data.pubdate;  //投稿时间(时间戳
                        desc = _Jsonobj.data.desc;  //简介
                        duration = _Jsonobj.data.duration;  //视频持续时长(所有分P
                        //data.owner.
                        mid = _Jsonobj.data.owner.mid;  //up主UID
                        name = _Jsonobj.data.owner.name;  //up主昵称
                        face = _Jsonobj.data.owner.face;  //up主头像地址
                        //data.stat.
                        view = _Jsonobj.data.stat.view;  //观看数量
                        danmaku = _Jsonobj.data.stat.danmaku;  //弹幕数量
                        reply = _Jsonobj.data.stat.reply;  //评论数量
                        favorite = _Jsonobj.data.stat.favorite;  //收藏数量
                        coin = _Jsonobj.data.stat.coin;  //投币数量
                        share = _Jsonobj.data.stat.share;  //分享数量
                        like = _Jsonobj.data.stat.like;  //获赞数量
                        //data.pages[].
                        //pages = new int[] { _Jsonobj.data.pages };
                        //data.pages[0/1/2].
                        //if (videos != "0")
                        {
                            //目前不处理
                        }
                        //data.staff[].
                        //staff = new int[] { _Jsonobj.data.staff };
                        //data.staff[0/1/2].
                        //if( staff.Length != 1)
                        {
                            //目前不处理
                        }
                        //时间戳转换
                        Pubdate_Convert pubdate_Convert = new Pubdate_Convert();
                        datetime = pubdate_Convert.Pubdate(pubdate);
                        //主分区转换
                        Tid_Judge tid_judge = new Tid_Judge();
                        tidstr = tid_judge.Tid(Convert.ToInt32(tid));
                        //版权信息判断
                        Copyright_Judge copyright_judge = new Copyright_Judge();
                        copyrightstr = copyright_judge.Copyright(Convert.ToInt32(copyright));
                        //SendDiscussMessage
                        e.FromQQ.SendPrivateMessage(title + "[共" + videos + "P]" + "\n" + "bv号:" + bvid + "\n" + "av号:" + av + "\n" + "UP主:" + name + "\nUP主UID:" + mid + "\n" + "-----------------\n" + tidstr + ":" + tname + "\n" + "点赞:" + like + "  投币:" + coin + "\n收藏:" + favorite + "  观看:" + view + "\n弹幕:" + danmaku + "  评论:" + reply + "\n分享:" + share + "\n-----------------\n" + "简介:" + desc);

                    }
                    else
                    {
                        e.FromQQ.SendPrivateMessage("错误:\n" + "Code:" + _Jsonobj.code + "\n" + _Jsonobj.Message + "\n" + "错误码:\n400为请求错误\n404为找不到稿件\n62002为稿件不可见");
                    }

                }
                else if (Msg.Substring(0, 2) == "bv")
                {
                    BiliBili_HttpGet_BV _HttpGet = new BiliBili_HttpGet_BV();
                    Json = _HttpGet.HttpGet(bvid = Msg.Substring(2, Msg.Length - 2));
                    var _Jsonobj = JsonConvert.DeserializeObject<dynamic>(Json);
                    if (_Jsonobj.code == 0)
                    {
                        //History_Write
                        File.AppendAllText(e.CQApi.AppDirectory + "HistorySearch.txt", e.FromQQ + "的" + e.FromQQ + "获取了" + Msg + "\n", Encoding.UTF8);
                        //Image_Download
                        //Image_Download imagedl = new Image_Download();
                        //pic = _Jsonobj.data.pic;
                        //imagedl.Image_DL(pic,pic.Substring(32,pic.Length-32));
                        //CQFunction cqimage = CQFunction.Image;
                        //Voluation_Json->String/Int[]
                        //data.
                        bvid = _Jsonobj.data.bvid;  //bv号
                        av = "av" + _Jsonobj.data.aid; //av号
                        title = _Jsonobj.data.title;  //标题
                        videos = _Jsonobj.data.videos;  //分P数量
                        tid = _Jsonobj.data.tid;  //主分区
                        tname = _Jsonobj.data.tname;  //子分区
                        copyright = _Jsonobj.data.copyright;  //版权信息
                        pubdate = _Jsonobj.data.pubdate;  //投稿时间(时间戳
                        desc = _Jsonobj.data.desc;  //简介
                        duration = _Jsonobj.data.duration;  //视频持续时长(所有分P
                        //data.owner.
                        mid = _Jsonobj.data.owner.mid;  //up主UID
                        name = _Jsonobj.data.owner.name;  //up主昵称
                        face = _Jsonobj.data.owner.face;  //up主头像地址
                        //data.stat.
                        view = _Jsonobj.data.stat.view;  //观看数量
                        danmaku = _Jsonobj.data.stat.danmaku;  //弹幕数量
                        reply = _Jsonobj.data.stat.reply;  //评论数量
                        favorite = _Jsonobj.data.stat.favorite;  //收藏数量
                        coin = _Jsonobj.data.stat.coin;  //投币数量
                        share = _Jsonobj.data.stat.share;  //分享数量
                        like = _Jsonobj.data.stat.like;  //获赞数量
                        //data.pages[].
                        //pages = new int[] { _Jsonobj.data.pages };
                        //data.pages[0/1/2].
                        //if (videos != "0")
                        {
                            //目前不处理
                        }
                        //data.staff[].
                        //staff = new int[] { _Jsonobj.data.staff };
                        //data.staff[0/1/2].
                        //if( staff.Length != 1)
                        {
                            //目前不处理
                        }
                        //时间戳转换
                        Pubdate_Convert pubdate_Convert = new Pubdate_Convert();
                        datetime = pubdate_Convert.Pubdate(pubdate);
                        //主分区转换
                        Tid_Judge tid_judge = new Tid_Judge();
                        tidstr = tid_judge.Tid(Convert.ToInt32(tid));
                        //版权信息判断
                        Copyright_Judge copyright_judge = new Copyright_Judge();
                        copyrightstr = copyright_judge.Copyright(Convert.ToInt32(copyright));
                        //SendDiscussMessage
                        e.FromQQ.SendPrivateMessage(title + "[共" + videos + "P]" + "\n" + "bv号:" + bvid + "\n" + "av号:" + av + "\n" + "UP主:" + name + "\nUP主UID:" + mid + "\n" + "-----------------\n" + tidstr + ":" + tname + "\n" + "点赞:" + like + "  投币:" + coin + "\n收藏:" + favorite + "  观看:" + view + "\n弹幕:" + danmaku + "  评论:" + reply + "\n分享:" + share + "\n-----------------\n" + "简介:" + desc);

                    }
                    else
                    {
                        e.FromQQ.SendPrivateMessage("错误:\n" + "Code:" + _Jsonobj.code + "\n" + _Jsonobj.Message + "\n" + "错误码:\n400为请求错误\n404为找不到稿件\n62002为稿件不可见");
                    }
                }
            }
            e.Handler = true;//MsgEnd
        }
    }
}
