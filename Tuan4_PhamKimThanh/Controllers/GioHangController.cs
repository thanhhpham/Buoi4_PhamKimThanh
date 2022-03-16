using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan4_PhamKimThanh.Models;

namespace Tuan4_PhamKimThanh.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        MyDataDataContext data = new MyDataDataContext();
        public List<GioHang> Laygiohang()
        {
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang == null)
            {
                listGioHang = new List<GioHang>();
                Session["GioHang"] = listGioHang;
            }
            return listGioHang;
        }

        public ActionResult ThemGioHang(int id, string strURl)
        {
            List<GioHang> listGioHang = Laygiohang();

            GioHang sanpham = listGioHang.Find(n => n.masach == id);

            if (sanpham == null)
            {
                sanpham = new GioHang(id);
                listGioHang.Add(sanpham);
                return Redirect(strURl);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURl);
            }

        }

        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;

            if (listGioHang != null)
            {
                tsl = listGioHang.Sum(n => n.iSoluong);
            }
            return tsl;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}