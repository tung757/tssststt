
using Manage_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Manage_Library
{
    /// <summary>
    /// Interaction logic for trangChuDocGia.xaml
    /// </summary>
    public partial class trangChuDocGia : Window
    {
        private String madocgia;
        public trangChuDocGia()
        {
            InitializeComponent();
        }
        public trangChuDocGia(String ma)
        {
            InitializeComponent();
            this.madocgia = ma;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DangNhap dn= new DangNhap();
            this.Close();
            dn.Show();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            if (e.OriginalSource is TabControl tb)
            {
                var sltb = tb.SelectedItem as TabItem;
                if (sltb != null)
                {
                    if (sltb.Header.ToString() == "Mượn sách")
                    {
                        var query = from sach in db.Saches select sach;
                        this.dsSach.ItemsSource = null;
                        this.dsSach.ItemsSource = query.ToList();
                    }
                    if (sltb.Header.ToString() == "Sách đang mượn")
                    {
                        var querysachdangmuon = from dsmt in db.Danhsachmuontras where dsmt.MaDg == this.madocgia && dsmt.GhiChu == "Chua xac nhan" select dsmt;
                        this.dgBorrowing.ItemsSource = null;
                        this.dgBorrowing.ItemsSource = querysachdangmuon.ToList();
                    }
                    if (sltb.Header.ToString() == "Sách đã mượn")
                    {
                        var queryls = from ls in db.Lichsus where ls.MaDg == this.madocgia select ls;
                        this.dgHistoriBorrow.ItemsSource = null;
                        this.dgHistoriBorrow.ItemsSource = queryls.ToList();
                    }
                }
            }
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            var query = from sach in db.Saches select sach;
            this.dsSach.ItemsSource = null;
            this.dsSach.ItemsSource = query.ToList();
        }

        private void dsSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dsSach.SelectedItem != null) {

                if (dsSach.SelectedItem is Sach) {
                    Sach hienthi = dsSach.SelectedItem as Sach;
                    this.bookId.Text = hienthi.MaSach;
                    this.bookNhXB.Text = hienthi.NhaXuatBan;
                    this.bookNXB.Text = Convert.ToString(hienthi.NamXuatBan);
                    this.bookLanguage.Text = hienthi.NgonNgu;
                    this.bookPrice.Text = Convert.ToString(hienthi.GiaTien);
                    this.bookAmounts.Text = Convert.ToString(hienthi.SoLuongConLai);
                }
                else
                {
                    this.bookId.Text = "";
                    this.bookNhXB.Text = "";
                    this.bookNXB.Text = "";
                    this.bookLanguage.Text = "";
                    this.bookPrice.Text = "";
                    this.bookAmounts.Text = "";
                }
            }
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            this.lbhienthids.Content = "Danh sách tìm kiếm";
            this.dsSach.ItemsSource = null;
            QlthuVienContext db = new QlthuVienContext();
            String loaitukhoa = this.fieldsCBBox.Text;
            String tukhoa = this.keyword.Text;
            if (loaitukhoa == "Thể loại")
            {
                var query = from sach in db.Saches where sach.TheLoai.Contains(tukhoa)==true select sach;
                this.dsSach.ItemsSource = query.ToList();
            }
            if (loaitukhoa == "Mã sách")
            {
                var query = from sach in db.Saches where sach.MaSach.Contains(tukhoa) == true select sach;
                this.dsSach.ItemsSource = query.ToList();
            }
            if (loaitukhoa == "Tên sách")
            {
                var query = from sach in db.Saches where sach.TenSach.Contains(tukhoa) == true select sach;
                this.dsSach.ItemsSource = query.ToList();
            }
            if (loaitukhoa == "Tên tác giả")
            {
                var query = from sach in db.Saches where sach.TacGia.Contains(tukhoa) == true select sach;
                this.dsSach.ItemsSource = query.ToList();
            }
            this.fieldsCBBox.Text = "Thể loại";
            this.keyword.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TabItem_Loaded(sender, e);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (this.dsSach.SelectedItem != null && this.bookId.Text != "")
            {
                QlthuVienContext db = new QlthuVienContext();
                var queryds = from dsmt in db.Danhsachmuontras select dsmt;
                Danhsachmuontra spmoi = new Danhsachmuontra();
                Sach sm = this.dsSach.SelectedItem as Sach;
                spmoi.MaDg = this.madocgia;
                spmoi.MaPhieu = Convert.ToString($"P{queryds.ToList().Count + 1}");
                spmoi.MaSach = sm.MaSach;
                spmoi.GhiChu = "Chua xac nhan";
                spmoi.NgayMuon = DateTime.Now;
                spmoi.NgayTra = DateTime.Now.AddDays(5);
                spmoi.SoLuong = 1;
                db.Danhsachmuontras.Add(spmoi);
                db.SaveChanges();
                //var suasoluong = db.Saches.SingleOrDefault(sach => sach.MaSach == spmoi.MaSach);
                //suasoluong.SoLuongConLai = suasoluong.SoLuongConLai - 1;
                //db.SaveChanges();
                TabItem_Loaded(sender, e);
            }
        }

        private void TabItem_Loaded_1(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            var querysachdangmuon = from dsmt in db.Danhsachmuontras where dsmt.MaDg == this.madocgia && dsmt.GhiChu== "Chua xac nhan" select dsmt;
            this.dgBorrowing.ItemsSource = null;
            this.dgBorrowing.ItemsSource = querysachdangmuon.ToList();
        }

        private void TabItem_Loaded_2(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            var queryls = from ls in db.Lichsus where ls.MaDg == this.madocgia select ls;
            this.dgHistoriBorrow.ItemsSource = null;
            this.dgHistoriBorrow.ItemsSource = queryls.ToList();
        }
    }
}
