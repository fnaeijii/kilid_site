using Kilidsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Kilidsite.Models;
using System.Diagnostics;
using System.Drawing;

namespace Kilidsite.Controllers
{
    public class HomeController : Controller
    {
        kilidEntities context = new kilidEntities();

        // GET: Home
        public ActionResult Index()
        {

            int homes = context.Homes.Count();

            int agency = context.Agancies.Count();

            int users = context.Users.Count();

            ViewBag.Homes = homes;
            ViewBag.Agency = agency;
            ViewBag.Users = users;


            return View();
        }



        public ActionResult login()
        {

            return View();
        }

        


        public ActionResult edit_acc()
        {

            return View();
        }

        public ActionResult Advertise()
        {

            return View();
        }

        public ActionResult AgencyforAdvertise()
        {

            return View();
        }



        public ActionResult agencies()
        {


            return View();
        }



        public ActionResult regAgancy()
        {

            return View();
         }

        public ActionResult checkagaPhone(string agencyPhone)
        {
        
            var statee = 1;
            var ag = context.Agancies.Where(x => x.AcancyPhone== agencyPhone).SingleOrDefault();
            
            if (ag == null)
            {
                statee = 0;
                
            }
            else
            {
                Advertise newadvertise = new Advertise();
                newadvertise.agID = ag.ID;
                
                context.Advertises.Add(newadvertise);
                context.SaveChanges();
            }

            return Json( statee , JsonRequestBehavior.AllowGet);
        }


        public ActionResult filterBuy(int AdType,string place,int minsize, int maxsize, int minage, int maxage, int minprice, int maxprice, int roomnum, int parking, int balcony, int elevator, int stor)
        {
            var homes = context.Homes.Where(x => (x.City == place || x.Neighborhood == place)&& parking == x.Parkinglot && balcony == x.Balcony && elevator == x.Elevator && stor == x.Store &&  x.Adtype == AdType).Select(x => new { x.City, x.Neighborhood, x.Title, x.Age, x.Roomnum, x.Size, x.Price, x.RentPrice, x.Adtype, x.Usage, x.Parkinglot, x.Balcony, x.Elevator, x.Store }).ToList();

            if(minsize != null)
            {
                homes= context.Homes.Where(x => (x.City == place || x.Neighborhood == place) && minsize <= x.Size && x.Size <= maxsize && parking == x.Parkinglot && balcony == x.Balcony && elevator == x.Elevator && stor == x.Store).Select(x => new { x.City, x.Neighborhood, x.Title, x.Age, x.Roomnum, x.Size, x.Price, x.RentPrice, x.Adtype, x.Usage, x.Parkinglot, x.Balcony, x.Elevator, x.Store }).ToList();
            }
            if(minage != null)
            {
                homes = context.Homes.Where(x => (x.City == place || x.Neighborhood == place) && minsize <= x.Size && x.Size <= maxsize && minage <= x.Age && x.Age <= maxage && parking == x.Parkinglot && balcony == x.Balcony && elevator == x.Elevator && stor == x.Store).Select(x => new { x.City, x.Neighborhood, x.Title, x.Age, x.Roomnum, x.Size, x.Price, x.RentPrice, x.Adtype, x.Usage, x.Parkinglot, x.Balcony, x.Elevator, x.Store }).ToList();

            }
            if (minprice != null)
            {
                homes = context.Homes.Where(x => (x.City == place || x.Neighborhood == place) && minsize <= x.Size && x.Size <= maxsize && minage <= x.Age && x.Age <= maxage && minprice <= x.Price && x.Price <= maxprice && parking == x.Parkinglot && balcony == x.Balcony && elevator == x.Elevator && stor == x.Store).Select(x => new { x.City, x.Neighborhood, x.Title, x.Age, x.Roomnum, x.Size, x.Price, x.RentPrice, x.Adtype, x.Usage, x.Parkinglot, x.Balcony, x.Elevator, x.Store }).ToList();

            }
            if (roomnum != null)
            {
                homes = context.Homes.Where(x => (x.City == place || x.Neighborhood == place) && minsize <= x.Size && x.Size <= maxsize && minage <= x.Age && x.Age <= maxage && minprice <= x.Price && x.Price <= maxprice && roomnum == x.Roomnum && parking == x.Parkinglot && balcony == x.Balcony && elevator == x.Elevator && stor == x.Store).Select(x => new { x.City, x.Neighborhood, x.Title, x.Age, x.Roomnum, x.Size, x.Price, x.RentPrice, x.Adtype, x.Usage, x.Parkinglot, x.Balcony, x.Elevator, x.Store }).ToList();

            }
            return Json(homes, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        public ActionResult filter2(string place)
        {

            var hs = context.Homes.Where(x => x.City == place).SingleOrDefault();
            //Select(x => new { x.City, x.Neighborhood, x.Title, x.Age, x.Roomnum, x.Size, x.Price, x.RentPrice, x.Adtype, x.Usage, x.Parkinglot, x.Balcony, x.Elevator, x.Store }).ToList();

            return Json(hs, JsonRequestBehavior.AllowGet);
        }


        public ActionResult setagency(string AgName,string Agphone,string AgPass,string Agn,string Agp,string Agcity,int AgW)
        {
            var statee = 0;
            var c = context.Agancies.Where(x => x.AcancyPhone == Agp ).SingleOrDefault();
            if (c == null)
            {
                statee = 1;
                Agancy newagancy = new Agancy();
                newagancy.ManagerName = AgName;
                newagancy.ManagerPhoneNumber = Agphone;
                newagancy.Password = AgPass;
                newagancy.AgancyName = Agn;
                newagancy.AcancyPhone = Agp;
                newagancy.City = Agcity;
                newagancy.NumberofEmployees= AgW;

                context.Agancies.Add(newagancy);
                context.SaveChanges();

            }

            return Json(statee, JsonRequestBehavior.AllowGet);
        }

        public ActionResult setuser(string UserPhone)
        {
            var statee = 0;

            var u = context.Users.Where(x => x.Phone == UserPhone).SingleOrDefault();

            if (u == null)
            {
                statee = 1;

                User newuser = new User();
                newuser.Phone = UserPhone;

                context.Users.Add(newuser);
                context.SaveChanges();

            }

            return Json(statee, JsonRequestBehavior.AllowGet);

        }

        public ActionResult edituser(string userP,string usname,string usemail,string uspassword)
        {
            var statee = 1;

            var us = context.Users.Where(x => x.Phone == userP).SingleOrDefault();
            us.Name = usname;
            us.Password = uspassword;
            us.Email = usemail;
            context.SaveChanges();

            if (us == null)
            {
                statee = 0;
            }

            return Json(statee, JsonRequestBehavior.AllowGet);
        }

       

        public ActionResult setAD(int Adtype,int rentPrice,string city,string nhood,int size,int age,int price,int use,int roomnum,int parking,int elevator,int stor,int balcony,string title,string explain)
        {
            var statee = 0;

            Home newhouse = new Home();
            newhouse.Adtype = Adtype;
            newhouse.RentPrice = rentPrice;
            newhouse.City = city;
            newhouse.Neighborhood = nhood;
            newhouse.Size = size;
            newhouse.Age = age;
            newhouse.Price = price;
            newhouse.Usage = use;
            newhouse.Roomnum= roomnum;
            newhouse.Parkinglot = parking;
            newhouse.Elevator= elevator;
            newhouse.Store = stor;
            newhouse.Balcony = balcony;
            newhouse.Title = title;
            newhouse.Explain = explain;

            context.Homes.Add(newhouse);
            context.SaveChanges();

            var newAD = context.Advertises.Where(x => x.hID == null).SingleOrDefault();
            newAD.hID = newhouse.ID;
      
            context.SaveChanges();

            statee = 1;

            return Json(statee, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult getAgencies()
        {
            var dep = context.Agancies.Select(x => new {x.ID, x.AgancyName,x.AcancyPhone, x.ManagerName }).ToList();

            return Json(dep, JsonRequestBehavior.AllowGet);
        }



    }
}