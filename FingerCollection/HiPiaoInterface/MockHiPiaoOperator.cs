using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    public class MockHiPiaoOperator:IHiPiaoOperator
    {
        #region IHiPiaoOperator 成员

        public TicketPrintObject GetTicket(string mobile, string valid)
        {
            if (mobile == "neterror")
            {
                throw new Exception("eee");
            }
             TicketPrintObject ticket=null;
            if (mobile == "12345678901")
            {
               ticket= this.MockTicketPrint();
                
            }
            if (ticket!=null&&valid == "000000")
            {
                ticket.IsPrinted = true;
            }
            return ticket;
        }

        public TicketPrintObject MockTicketPrint()
        {
            TicketPrintObject ticket = new HiPiaoInterface.TicketPrintObject();
            ticket.Seat = "9排5号";
            ticket.MovieName = "超人归来";
            ticket.Cinema = "模拟影院";
            ticket.TicketId = "0000FED001";
            ticket.RoomName = "2号厅";
            ticket.Price = 25;
            ticket.PrintTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ticket.PlayTime = "11:30";
            ticket.PlayDate = System.DateTime.Now.ToString("yyyy.MM.dd");
            return ticket;
        }

        public bool CheckUserName(string name)
        {
            return name != "admin";
        }
        public bool UpdatePwd(UserObject user, string newPwd)
        {
            if (user.Pwd == "123456")
                return false;
            return true;
        }

        public bool CheckMobile(string mobile)
        {
            return mobile != "12345678905";
        }

        public List<BuyRecordObject> MockBuyRecordObject(int row)
        {
            List<BuyRecordObject> result = new List<BuyRecordObject>();
            for (int i = 0; i < row; i++)
            {
                BuyRecordObject record = new BuyRecordObject();
                record.BuyTime = System.DateTime.Now;
                record.ConnectMobile = "13811110000";
                record.User = mockUser;
                record.ValidCode = "888888";
                record.Tickets.Add(this.MockTicket());
                record.Tickets.Add(this.MockTicket());
                result.Add(record);
            }
            return result;

        }

        public TicketObject MockTicket()
        {
            TicketObject ticket = new TicketObject();
            ticket.PlayTime = System.DateTime.Now;
            ticket.Price = 35;
            ticket.TicketId = "00000FEDD000";
            ticket.Movie = MockMovie();
            ticket.Seat = MockCinema().Rooms[0].Seats[5];
            return ticket;
        }

        public MovieObject MockMovie()
        {
            MovieObject movie = new MovieObject();
            movie.Name = "龙门飞甲";
            movie.PlayTime = Convert.ToDateTime("2011-5-10");
            movie.TotalMinutes = 50;
            movie.OtherName = "影片别名";
            movie.ScreenWriter = "张三、李四";
            movie.StarGrade = 1;
            movie.Type = "喜剧片";
            movie.Language = "中文（大陆）";
            movie.Introduction = "此段是简要介绍";
            movie.Id = "123";
            movie.MainActors = "老谋子";
            movie.ShowDate = Convert.ToDateTime("2011-7-10");
            return movie;
        }

        private static CinemaObject mockCinema;

        private static UserObject mockUser;

        private List<CouponObject> MockCoupon(int num)
        {
            List<CouponObject> lists=new List<CouponObject>();
            int type = 1;
            
            for (int i = 0; i < num; i++)
            {
                if (i%2 != 0)
                {
                    type = 2;
                }
                CouponObject coupon = new CouponObject();
                coupon.Name = "10元抵用券";
                //Random rd = new Random();
                //type = rd.Next(0, 3);
                coupon.Type = type;
               
                lists.Add(coupon);
            }
            return lists;
        }

        public UserObject MockUser()
        {
            if (mockUser == null)
            {
                UserObject user = new UserObject();
                mockUser = user;
                user.Pwd = "qqqqqq";
                user.Name = "测试用户";
                user.Mobile = "15814584511";
                user.Balance = 50;
                user.Email = "testuser@qq.com";
                user.RewardPoints = 10078;
                user.BuyRecords = this.MockBuyRecordObject(32);
                user.Coupons = this.MockCoupon(12);
                
            }
            return mockUser;
        }

        public CinemaObject MockCinema()
        {
            if (mockCinema == null)
            {
                CinemaObject cinema = new CinemaObject();
                cinema.Department = "深圳宝安广场店";
                cinema.Ip = "127.0.0.1";
                cinema.Name = "飞扬影城";
                for (int i = 0; i < 3; i++)
                {
                    RoomObject room = MockRoom(i);
                    room.Cinema = cinema;
                    cinema.Rooms.Add(room);
                }
                mockCinema = cinema;
            }
            return mockCinema;
        }

        public RoomObject MockRoom(int row)
        {
            RoomObject room = new RoomObject();
            room.Name = row.ToString() + "号厅";
            room.Cinema = mockCinema;
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j < 20; j++)
                {
                    SeatObject seat = MockSeat(i, j);
                    seat.Room = room;
                    room.Seats.Add(seat);
                }
            }
            return room;
        }

        public SeatObject MockSeat(int row, int no)
        {
            SeatObject seat = new SeatObject();
            seat.RowNum = row;
            seat.SeatNo = no;
            return seat;
        }

        public UserObject Login(string uid, string pwd)
        {
            if (uid == "admin" && pwd == "qqqqqq")
            {
                return this.MockUser();
            }
            return null;
        }

        public TicketObject BuyTicket(UserObject user, CinemaObject cinema, MovieObject movie, DateTime playTime)
        {
            throw new NotImplementedException();
        }

        public UserObject Register(string uid, string pwd, string mobile)
        {
            if (uid != "neterror")
                return this.MockUser();
            else
                return null;
        }

        public ReturnObject PrintTicket(UserObject user, TicketObject ticket)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
