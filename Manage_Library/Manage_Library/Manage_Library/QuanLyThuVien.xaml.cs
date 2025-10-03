
using Manage_Library.Models;
using Microsoft.EntityFrameworkCore;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Manage_Library
{
    /// <summary>
    /// Interaction logic for QuanLyThuVien.xaml
    /// </summary>
    public partial class QuanLyThuVien : Window
    {
        public QuanLyThuVien()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DangNhap dn = new DangNhap();
            this.Close();
            dn.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            var query = from sach in db.Saches select sach;
            this.dgdsSach.ItemsSource = null;
            this.dgdsSach.ItemsSource = query.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            this.txtheadertimkiem.Content = "Danh sach";
            try
            {
                Sach a = new Sach();
                a.MaSach = this.bookId.Text;
                a.TenSach = this.bookName.Text;
                a.NhaXuatBan = this.bookNXB.Text;
                a.TacGia = this.bookTacGia.Text;
                a.NamXuatBan = int.Parse(this.bookNXB.Text);
                a.NgonNgu = this.bookLanguage.Text;
                a.GiaTien = int.Parse(this.bookPrice.Text);
                a.TheLoai = this.bookTheLoai.Text;
                a.SoLuongConLai = int.Parse(this.bookAmounts.Text);
                a.AnhBia = "";
                db.Saches.Add(a);
                db.SaveChanges();
                this.bookId.Text = "";
                this.bookNhXB.Text = "";
                this.bookName.Text = "";
                this.bookTheLoai.Text = "";
                this.bookTacGia.Text = "";
                this.bookNXB.Text = "";
                this.bookLanguage.Text = "";
                this.bookPrice.Text = "";
                this.bookAmounts.Text = "";
                var query = from sach in db.Saches select sach;
                this.dgdsSach.ItemsSource = null;
                this.dgdsSach.ItemsSource = query.ToList();
            }
            catch(Exception ex)
            {
                
            }
        }

        private void btTimKiem_Click(object sender, RoutedEventArgs e)
        {
            this.txtheadertimkiem.Content = "Danh sách tìm kiếm";
            this.dgdsSach.ItemsSource = null;
            QlthuVienContext db = new QlthuVienContext();
            String loaitukhoa = this.fieldsCBBox.Text;
            String tukhoa = this.keyword.Text;
            if (loaitukhoa == "Thể loại")
            {
                var query = from sach in db.Saches where sach.TheLoai.Contains(tukhoa) == true select sach;
                this.dgdsSach.ItemsSource = query.ToList();
            }
            if (loaitukhoa == "Mã sách")
            {
                var query = from sach in db.Saches where sach.MaSach.Contains(tukhoa) == true select sach;
                this.dgdsSach.ItemsSource = query.ToList();
            }
            if (loaitukhoa == "Tên sách")
            {
                var query = from sach in db.Saches where sach.TenSach.Contains(tukhoa) == true select sach;
                this.dgdsSach.ItemsSource = query.ToList();
            }
            if (loaitukhoa == "Tên tác giả")
            {
                var query = from sach in db.Saches where sach.TacGia.Contains(tukhoa) == true select sach;
                this.dgdsSach.ItemsSource = query.ToList();
            }

        }

        private void bttrangchu_Click(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            var query = from sach in db.Saches select sach;
            this.keyword.Text = "";
            this.dgdsSach.ItemsSource = null;
            this.dgdsSach.ItemsSource = query.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (this.dgdsSach.SelectedItem != null)
            {
                Sach dt = this.dgdsSach.SelectedItem as Sach;
                this.bookId.Text = dt.MaSach;
                this.bookName.Text = dt.TenSach;
                this.bookNhXB.Text = dt.NhaXuatBan;
                this.bookTheLoai.Text = dt.TheLoai;
                this.bookTacGia.Text = dt.TacGia;
                this.bookNXB.Text = dt.NamXuatBan.ToString();
                this.bookLanguage.Text = dt.NgonNgu;
                this.bookPrice.Text = dt.GiaTien.ToString();
                this.bookAmounts.Text = dt.SoLuongConLai.ToString();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            if(this.bookId.Text!="")
            {
                var sua = db.Saches.SingleOrDefault(sach => sach.MaSach == this.bookId.Text);
                sua.TenSach = this.bookName.Text;
                sua.NhaXuatBan = this.bookNhXB.Text;
                sua.TheLoai = this.bookTheLoai.Text;
                sua.TacGia = this.bookTacGia.Text;
                sua.NamXuatBan = int.Parse(this.bookNXB.Text);
                sua.NgonNgu = this.bookLanguage.Text;
                sua.GiaTien = int.Parse(this.bookPrice.Text);
                sua.SoLuongConLai = int.Parse(this.bookAmounts.Text);
                this.bookId.Text = "";
                this.bookNhXB.Text = "";
                this.bookName.Text = "";
                this.bookTheLoai.Text = "";
                this.bookTacGia.Text = "";
                this.bookNXB.Text = "";
                this.bookLanguage.Text = "";
                this.bookPrice.Text = "";
                this.bookAmounts.Text = "";
                var query = from sach in db.Saches select sach;
                this.dgdsSach.ItemsSource = null;
                this.dgdsSach.ItemsSource = query.ToList();
                db.SaveChanges();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            if (this.dgdsSach.SelectedItem != null)
            {
                Sach sa = this.dgdsSach.SelectedItem as Sach;
                //var xoa = db.Saches.SingleOrDefault(sach => sach.MaSach == sa.MaSach);
                
                ////xoa.TenSach = this.bookName.Text;
                ////xoa.NhaXuatBan = this.bookNhXB.Text;
                ////xoa.TheLoai = this.bookTheLoai.Text;
                ////xoa.TacGia = this.bookTacGia.Text;
                ////xoa.NamXuatBan = int.Parse(this.bookNXB.Text);
                ////xoa.NgonNgu = this.bookLanguage.Text;
                ////xoa.GiaTien = int.Parse(this.bookPrice.Text);
                ////xoa.SoLuongConLai = int.Parse(this.bookAmounts.Text);
                //xoa.TenSach = sa.TenSach;
                //xoa.NhaXuatBan = sa.MaSach;
                //xoa.TheLoai = sa.TheLoai;
                //xoa.TacGia = sa.TacGia;
                //xoa.NamXuatBan = sa.NamXuatBan;
                //xoa.NgonNgu = sa.NgonNgu;
                //xoa.GiaTien = sa.GiaTien;
                //xoa = sa;
                db.Saches.Remove(sa);
               
                db.SaveChanges();
            }
            this.bookId.Text = "";
            this.bookNhXB.Text = "";
            this.bookName.Text = "";
            this.bookTheLoai.Text = "";
            this.bookTacGia.Text = "";
            this.bookNXB.Text = "";
            this.bookLanguage.Text = "";
            this.bookPrice.Text = "";
            this.bookAmounts.Text = "";
            var query = from sach in db.Saches select sach;
            this.dgdsSach.ItemsSource = null;
            this.dgdsSach.ItemsSource = query.ToList();
            db.SaveChanges();
        }

        private void Load_dsBanDoc(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            var query = from nd in db.Nguoidungs select nd;
            dgDG.ItemsSource = query.ToList();
        }

        private void bthTKNguoidung_Click(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db= new QlthuVienContext();
            
            String loai = "";
            String tukhoa = this.searchBar.Text;
            if(rdtkmadocgia.IsChecked == true)
            {
                var query = from nd in db.Nguoidungs where nd.MaDg.Contains(tukhoa) == true select nd;
                dgDG.ItemsSource = null;
                dgDG.ItemsSource= query.ToList();
            }
            if (rdtktendocgia.IsChecked == true) { 
                var query = from nd in db.Nguoidungs where nd.TenNguoiDung.Contains(tukhoa) == true select nd;
                dgDG.ItemsSource = null;
                dgDG.ItemsSource= query.ToList();
            }
        }

        private void addDG_Click(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            try
            {
                Nguoidung a = new Nguoidung();
                a.MaDg = userID.Text;
                a.TenNguoiDung = userName.Text;
                a.NgaySinh = Convert.ToDateTime(this.birthDate.SelectedDate);
                a.Username = this.AccountName.Text;
                a.Passw = this.Password.Text;
                a.GioiTinh = this.sex.Text;
                a.DiaChi = this.address.Text;
                a.SoDienThoai = this.phone.Text;
                a.VaiTro = this.dgType.Text;
                db.Nguoidungs.Add(a);
                db.SaveChanges();
                this.userID.Text = "";
                this.userName.Text = "";
                this.birthDate.SelectedDate = null;
                this.AccountName.Text = "";
                this.Password.Text = "";
                this.sex.Text = "";
                this.address.Text = "";
                this.phone.Text = "";
                this.dgType.Text = "";
                var query = from nd in db.Nguoidungs select nd;
                dgDG.ItemsSource = query.ToList();
            }
            catch(Exception ex)
            {

            }
        }

        private void editDG_Click(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            if(this.dgDG.SelectedItem != null)
            {
                Nguoidung a = this.dgDG.SelectedItem as Nguoidung;
                this.userID.Text = a.MaDg;
                this.userName.Text = a.TenNguoiDung;
                this.birthDate.SelectedDate = a.NgaySinh;
                this.AccountName.Text = a.Username;
                this.Password.Text = a.Passw;
                this.sex.Text = a.GioiTinh;
                this.address.Text = a.DiaChi;
                this.phone.Text = a.SoDienThoai;
                this.dgType.Text = a.VaiTro;
            }
        }

        private void saveDG_Click(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            if (this.userID.Text != "")
            {
                var sua = db.Nguoidungs.SingleOrDefault(nd => nd.MaDg == this.userID.Text);
                sua.Username = this.userName.Text;
                sua.MaDg = this.userID.Text;
                sua.NgaySinh = this.birthDate.SelectedDate;
                sua.Username = this.AccountName.Text;
                sua.Passw = this.Password.Text;
                sua.GioiTinh = this.sex.Text;
                sua.DiaChi = this.address.Text;
                sua.SoDienThoai = this.phone.Text;
                sua.VaiTro = this.dgType.Text;
                db.SaveChanges();
                var query = from nd in db.Nguoidungs select nd;
                dgDG.ItemsSource = null;
                dgDG.ItemsSource = query.ToList();
                this.userID.Text = "";
                this.userName.Text = "";
                this.birthDate.SelectedDate = null;
                this.AccountName.Text = "";
                this.Password.Text = "";
                this.sex.Text = "";
                this.address.Text = "";
                this.phone.Text = "";
                this.dgType.Text = "";
            }
        }

        private void deleteDG_Click(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            if (dgDG.SelectedItem != null)
            {
                Nguoidung xoa= this.dgDG.SelectedItem as Nguoidung;
                db.Nguoidungs.Remove(xoa);
                db.SaveChanges();
            }
            var query = from nd in db.Nguoidungs select nd;
            dgDG.ItemsSource = null;
            dgDG.ItemsSource = query.ToList();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            var query = from nd in db.Nguoidungs select nd;
            dgDG.ItemsSource = null;
            dgDG.ItemsSource = query.ToList();
        }
        private void adQuanLyMuonSach(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            var query = from dsmt in db.Danhsachmuontras select dsmt;
            dgMuon.ItemsSource = null;
            dgMuon.ItemsSource=query.ToList();
        }

        private void dgMuon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            if (dgMuon.SelectedItem != null) { 
                Danhsachmuontra dsmt = dgMuon.SelectedItem as Danhsachmuontra;
                if (dsmt != null) {
                    var ds = db.Saches.SingleOrDefault(ds => ds.MaSach == dsmt.MaSach);
                    this.ticketMuonId.Text = dsmt.MaPhieu;
                    this.docGiaMuonId.Text = dsmt.MaDg;
                    this.sachIdMuon.Text = dsmt.MaSach;
                    this.soLuongMuon.Text = Convert.ToString(dsmt.SoLuong);
                    this.ngayMuon.SelectedDate = dsmt.NgayMuon;
                    this.ngayTra.SelectedDate = dsmt.NgayTra;
                    this.bookPriceMuon.Text = Convert.ToString(ds.GiaTien);
                    this.noteMuon.Text = dsmt.GhiChu;
                    this.bookIdMuon.Text = dsmt.MaSach;
                    this.bookNameMuon.Text = ds.TenSach;
                    this.bookAmountMuon.Text = Convert.ToString(ds.SoLuongConLai);
                    this.authorMuon.Text = ds.TacGia;
                }
            }
        }

        private void exitMuon_Click(object sender, RoutedEventArgs e)
        {
            dgMuon.SelectedItem = null;
            this.ticketMuonId.Text = "";
            this.docGiaMuonId.Text = "";
            this.sachIdMuon.Text = "";
            this.soLuongMuon.Text = "";
            this.ngayMuon.Text = "";
            this.ngayTra.Text = "";
            this.bookPriceMuon.Text = "";
            this.noteMuon.Text = "";
            this.bookIdMuon.Text = "";
            this.bookNameMuon.Text = "";
            this.bookAmountMuon.Text = "";
            this.authorMuon.Text = "";
            QlthuVienContext db = new QlthuVienContext();
            var query = from dsmt in db.Danhsachmuontras select dsmt;
            dgMuon.ItemsSource = null;
            dgMuon.ItemsSource = query.ToList();
        }

        private void newMuon_Click(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            if(this.bookIdMuon.Text != "")
            {
                this.ngayMuon.SelectedDate = DateTime.Now;
                this.ngayTra.SelectedDate = Convert.ToDateTime($"{DateTime.Now.Month}-{DateTime.Now.Day + 1}-{DateTime.Now.Year}");
                String masach = this.bookIdMuon.Text;
                var tk = db.Saches.SingleOrDefault(sach => sach.MaSach == masach);
                this.bookNameMuon.Text = tk.TenSach;
                this.bookAmountMuon.Text = Convert.ToString(tk.SoLuongConLai);
                this.authorMuon.Text = tk.TacGia;
                this.sachIdMuon.Text = tk.MaSach;
                this.bookPriceMuon.Text = Convert.ToString(tk.GiaTien);
                this.noteMuon.Text = "Da xac nhan";
            }


        }

        private void choMuon_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if(this.noteMuon.Text != "Da xac nhan")
                {
                    QlthuVienContext db = new QlthuVienContext();
                    Danhsachmuontra mt = dgMuon.SelectedItem as Danhsachmuontra;
                    var xacnhan = db.Danhsachmuontras.SingleOrDefault(dsmt => dsmt.MaPhieu == mt.MaPhieu);
                    this.noteMuon.Text = "Da xac nhan";
                    xacnhan.GhiChu = this.noteMuon.Text;
                    db.SaveChanges();
                    var sua = db.Saches.SingleOrDefault(sach => sach.MaSach == mt.MaSach);
                    sua.SoLuongConLai = sua.SoLuongConLai - mt.SoLuong;
                    db.SaveChanges();
                    if (this.noteMuon.Text == "Da xac nhan")
                    {
                        Lichsu ls = new Lichsu();
                        var lichsu = from l in db.Lichsus select l;
                        int a = lichsu.ToList().Count;
                        ls.MaTh = Convert.ToString(a + 1);
                        ls.TenSach = this.bookNameMuon.Text;
                        ls.NgayMuon = this.ngayMuon.SelectedDate;
                        ls.MaDg = this.docGiaMuonId.Text;
                        db.Lichsus.Add(ls);
                        db.SaveChanges();
                    }
                    var query = from dsmt in db.Danhsachmuontras select dsmt;
                    dgMuon.ItemsSource = null;
                    dgMuon.ItemsSource = query.ToList();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            this.bookId.Text = "";
            this.bookNhXB.Text = "";
            this.bookName.Text = "";
            this.bookTheLoai.Text = "";
            this.bookTacGia.Text = "";
            this.bookNXB.Text = "";
            this.bookLanguage.Text = "";
            this.bookPrice.Text = "";
            this.bookAmounts.Text = "";
        }

        private void exitDG_Click(object sender, RoutedEventArgs e)
        {
            this.userID.Text = "";
            this.userName.Text = "";
            this.birthDate.SelectedDate = null;
            this.AccountName.Text = "";
            this.Password.Text = "";
            this.sex.Text = "";
            this.address.Text = "";
            this.phone.Text = "";
            this.dgType.Text = "";
        }

        private void saveMuon_Click(object sender, RoutedEventArgs e)
        {
            Danhsachmuontra moi = new Danhsachmuontra();
            QlthuVienContext db = new QlthuVienContext();
            
            try
            {
                moi.MaPhieu = this.ticketMuonId.Text;
                moi.MaDg = this.docGiaMuonId.Text;
                moi.MaSach = this.sachIdMuon.Text;
                moi.NgayMuon = this.ngayMuon.SelectedDate;
                moi.NgayTra = this.ngayTra.SelectedDate;
                moi.SoLuong = int.Parse(this.soLuongMuon.Text);
                moi.GhiChu = this.noteMuon.Text;
                db.Danhsachmuontras.Add(moi);
                db.SaveChanges();
                var sua = db.Saches.SingleOrDefault(sach => sach.MaSach == moi.MaSach);
                sua.SoLuongConLai = sua.SoLuongConLai - moi.SoLuong;
                db.SaveChanges();
                this.ticketMuonId.Text = "";
                this.docGiaMuonId.Text = "";
                this.sachIdMuon.Text = "";
                this.soLuongMuon.Text = "";
                this.ngayMuon.Text = "";
                this.ngayTra.Text = "";
                this.bookPriceMuon.Text = "";
                this.noteMuon.Text = "";
                this.bookIdMuon.Text = "";
                this.bookNameMuon.Text = "";
                this.bookAmountMuon.Text = "";
                this.authorMuon.Text = "";

                var query = from dsmt in db.Danhsachmuontras select dsmt;
                dgMuon.ItemsSource = null;
                dgMuon.ItemsSource = query.ToList();
                htdstrasach(sender, e);
                bttrangchu_Click(sender, e);
            }
            catch(Exception ex)
            {

            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            var query = from dsmt in db.Danhsachmuontras select dsmt;
            dgMuon.ItemsSource = null;
            dgMuon.ItemsSource = query.ToList();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            this.grm.Header = "Danh sach tim kiem";
            String tukhoa = this.searchBarMuon.Text;
            String kieutk = "";
            if(searchMaDGMuon.IsChecked == true)
            {
                kieutk = "MaDg";
                var query = from dsmt in db.Danhsachmuontras where dsmt.MaDg.Contains(tukhoa) == true select dsmt;
                dgMuon.ItemsSource = null;
                dgMuon.ItemsSource = query.ToList();
            }
            if (searchSachMuon.IsChecked == true) {
                kieutk = "MaSach";
                
                var query = from dsmt in db.Danhsachmuontras where dsmt.MaSach.Contains(tukhoa) == true select dsmt;
                dgMuon.ItemsSource = null;
                dgMuon.ItemsSource = query.ToList();
            }
            this.searchBarMuon.Text = "";
        }

        private void traSach_Click(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            if (this.dgMuonTabTraSach.SelectedItem!=null)
            {
                Danhsachmuontra xoa = this.dgMuonTabTraSach.SelectedItem as Danhsachmuontra;
                String matk = xoa.MaSach;
                int? sl = xoa.SoLuong;
                db.Danhsachmuontras.Remove(xoa);
                db.SaveChanges();
                Button_Click_9(sender,e);
                var sua = db.Saches.SingleOrDefault(sach => sach.MaSach == matk);
                sua.SoLuongConLai = sua.SoLuongConLai + sl;
                db.SaveChanges();
            }
            bttrangchu_Click(sender, e);
            Button_Click_7(sender, e);

        }
        
        private void htdstrasach(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            var query = from dsmt in db.Danhsachmuontras where dsmt.GhiChu=="Da xac nhan" select dsmt;
            this.dgMuonTabTraSach.ItemsSource = null;
            this.dgMuonTabTraSach.ItemsSource = query.ToList();
        }

        private void dgMuonTabTraSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.dgMuonTabTraSach.SelectedItem != null) {
                Danhsachmuontra a = this.dgMuonTabTraSach.SelectedItem as Danhsachmuontra;
                if (a != null) {
                    QlthuVienContext db = new QlthuVienContext();
                    var qur = db.Saches.SingleOrDefault(sach => sach.MaSach == a.MaSach);
                    var ites = db.Danhsachmuontras.SingleOrDefault(dsmt => dsmt.MaPhieu == a.MaPhieu);
                    this.ticketTraId.Text = ites.MaPhieu;
                    this.docGiaTraId.Text = ites.MaDg;
                    this.sachIdTra.Text = ites.MaSach;
                    this.soLuongTra.Text = Convert.ToString(ites.SoLuong);
                    this.ngayMuonTabTra.SelectedDate = ites.NgayMuon;
                    this.ngayTraTabTra.SelectedDate = ites.NgayTra;
                    this.bookPriceTra.Text = Convert.ToString(qur.GiaTien);
                    this.noteTra.Text = ites.GhiChu;
                }
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            var query = from dsmt in db.Danhsachmuontras where dsmt.GhiChu == "Da xac nhan" select dsmt;
            this.dgMuonTabTraSach.ItemsSource = null;
            this.dgMuonTabTraSach.ItemsSource = query.ToList();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            String tukhoa = this.searchBarTra.Text;
            String kieutk = "";
            if (searchMaDGTra.IsChecked == true)
            {
                kieutk = "MaDg";
                var query = from dsmt in db.Danhsachmuontras where dsmt.MaDg.Contains(tukhoa) == true select dsmt;
                dgMuonTabTraSach.ItemsSource = null;
                dgMuonTabTraSach.ItemsSource = query.ToList();
            }
            if (searchSachTra.IsChecked == true)
            {
                kieutk = "MaSach";

                var query = from dsmt in db.Danhsachmuontras where dsmt.MaSach.Contains(tukhoa) == true select dsmt;
                dgMuonTabTraSach.ItemsSource = null;
                dgMuonTabTraSach.ItemsSource = query.ToList();
            }
            this.searchBarTra.Text = "";
        }

        private void hthongke(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            var query = from sach in db.Saches select sach;
            this.slDauSach.Text = Convert.ToString(query.ToList().Count);
            var qer = from dsmt in db.Danhsachmuontras select dsmt;
            int? tongsl = 0, slmuonn = 0;
            foreach (var sach in query.ToList()) {
                tongsl = tongsl + sach.SoLuongConLai;
            }
            foreach (var dsmt in qer.ToList())
            {
                slmuonn = slmuonn + dsmt.SoLuong;
            }
            this.slCuonSach.Text = Convert.ToString(tongsl+ slmuonn);
            this.slMuon.Text=Convert.ToString(slmuonn);
            this.slCon.Text=Convert.ToString(tongsl);
            long? gia = 0;
            foreach (var sach in query.ToList()) {
                gia = gia + sach.SoLuongConLai * sach.GiaTien;
            }
            this.tongGiaTri.Text=Convert.ToString(gia);
            var quahan = from dsquahan in db.Danhsachmuontras select dsquahan;
            List<Danhsachmuontra> dsmtqh = new List<Danhsachmuontra>();
            int? slqh = 0;
            foreach(var dsqh in quahan.ToList())
            {
                DateTime nt = Convert.ToDateTime(dsqh.NgayTra);
                TimeSpan ts = DateTime.Now - nt;
                if (ts.TotalDays>0)
                {
                    dsmtqh.Add(dsqh);
                    slqh = slqh + dsqh.SoLuong;
                }
            }
            var docgia = from nd in db.Nguoidungs select nd;
            this.slQuaHan.Text = Convert.ToString(slqh);
            this.slDG.Text = Convert.ToString(docgia.ToList().Count);
            this.dgQuaHanTraSach.ItemsSource = null;
            this.dgQuaHanTraSach.ItemsSource= dsmtqh;
            var sodocgia = db.Danhsachmuontras.GroupBy(o => o.MaDg);
            this.slDGDaMuon.Text=Convert.ToString(sodocgia.ToList().Count);

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.OriginalSource is TabControl tb)
            {
                var sltb = tb.SelectedItem as TabItem;
                if(sltb!=null)
                {
                    if(sltb.Header.ToString()== "Báo cáo - thống kê")
                    {
                        hthongke(sender, e);
                    }
                    if (sltb.Header.ToString() == "Quản lý sách")
                    {
                        bttrangchu_Click(sender, e);
                    }
                }
            }
        }

        private void giaHan_Click(object sender, RoutedEventArgs e)
        {
            if(this.dgMuon.SelectedItem != null && this.ticketMuonId.Text!="")
            {
                QlthuVienContext db = new QlthuVienContext();
                var giahan = db.Danhsachmuontras.SingleOrDefault(dsmt => dsmt.MaPhieu == this.ticketMuonId.Text);

                DateTime ngaygiahan = Convert.ToDateTime(this.ngayTra.Text);
                giahan.NgayTra = ngaygiahan.AddDays(7);
                db.SaveChanges();
                this.Button_Click_7(sender, e);
                this.exitMuon_Click(sender, e);
            }
        }

        private void tabcuaadmin_Loaded(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            var querythuthu = from thuthu in db.Taikhoans select thuthu;
            this.dgDanhSachThuThu.ItemsSource = null;
            this.dgDanhSachThuThu.ItemsSource = querythuthu.ToList();
        }
        
        private void thuThuAddBtn_Click(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            try
            {
                if (this.thuThuID.Text != "")
                {
                    var lay = from tk in db.Taikhoans where tk.Id == this.thuThuID.Text select tk;
                    if (lay.ToList().Count == 0)
                    {
                        Taikhoan moi = new Taikhoan();
                        moi.Id = this.thuThuID.Text;
                        moi.TaiKhoan1 = this.ThuThuAccountName.Text;
                        moi.MatKhau = this.thuThuPassword.Text;
                        moi.TenNhanVien = this.thuThuName.Text;
                        moi.ThoiGianBatDau = $"{this.batDauGio.Text}h{this.batDauPhut.Text}p";
                        moi.ThoiGianKetThuc = $"{this.ketThucGio.Text}h{this.ketThucPhut.Text}p";
                        db.Taikhoans.Add(moi);
                        db.SaveChanges();
                        tabcuaadmin_Loaded(sender, e);
                        this.thuThuHuy_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Mã nhân viên đã có trong thư viện","Lỗi nhập",MessageBoxButton.OK, MessageBoxImage.Error);
                        this.thuThuID.Focus();
                    }
                    
                }
            }
            catch (Exception ex) { }
        }

        private void thuThuHuy_Click(object sender, RoutedEventArgs e)
        {
            this.thuThuID.Text = "";
            this.ThuThuAccountName.Text = "";
            this.thuThuPassword.Text = "";
            this.thuThuName.Text = "";
            this.batDauGio.Text = "";
            this.batDauPhut.Text = "";
            this.ketThucGio.Text = "";
            this.ketThucPhut.Text = "";
        }

        private void dgDanhSachThuThu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void thuThuXoaBtn_Click(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            if (dgDanhSachThuThu.SelectedItem != null)
            {
                Taikhoan xoa = this.dgDanhSachThuThu.SelectedItem as Taikhoan;
                if (xoa.Id != "")
                {
                    db.Taikhoans.Remove(xoa);
                    db.SaveChanges();
                    tabcuaadmin_Loaded(sender, e);
                }
               
            }
        }

        private void thuThuEditBtn_Click(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            if (dgDanhSachThuThu.SelectedItem != null)
            {
                Taikhoan ht = this.dgDanhSachThuThu.SelectedItem as Taikhoan;
                this.thuThuID.Text = ht.Id;
                this.ThuThuAccountName.Text = ht.TaiKhoan1;
                this.thuThuPassword.Text = ht.MatKhau;
                this.thuThuName.Text = ht.TenNhanVien;
                String[] timecgio = ht.ThoiGianBatDau.Split('h');
                this.batDauGio.Text= timecgio[0];
                String[] timecphut = timecgio[1].Split('p');
                this.batDauPhut.Text= timecphut[0];
                String[] timektgio = ht.ThoiGianKetThuc.Split('h');
                this.ketThucGio.Text= timektgio[0];
                String[] timektphut = timektgio[1].Split('p');
                this.ketThucPhut.Text=timektphut[0];
            }
        }

        private void thuThuLuu_Click(object sender, RoutedEventArgs e)
        {
            if (this.thuThuID.Text != "")
            {
                QlthuVienContext db = new QlthuVienContext();
                var sua = db.Taikhoans.SingleOrDefault(tk => tk.Id == this.thuThuID.Text);
                sua.TenNhanVien = this.thuThuName.Text;
                sua.TaiKhoan1 = this.ThuThuAccountName.Text;
                sua.Id = this.thuThuID.Text;
                sua.MatKhau = this.thuThuPassword.Text;
                sua.ThoiGianBatDau=$"{this.batDauGio.Text}h{this.batDauPhut.Text}p";
                sua.ThoiGianKetThuc = $"{this.ketThucGio.Text}h{this.ketThucPhut.Text}p";
                db.SaveChanges();
                tabcuaadmin_Loaded(sender, e);
                thuThuHuy_Click(sender,e);
            }
        }

        private void tkthuthu_Click(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            String tukhoa = this.thuThuSearchBar.Text;
            if(this.tktheomatt.IsChecked == true)
            {
                var ds = from tk in db.Taikhoans where tk.Id.Contains(tukhoa) == true select tk;
                this.dgDanhSachThuThu.ItemsSource = null;
                this.dgDanhSachThuThu.ItemsSource = ds.ToList();
            }
            if (this.tktheotentt.IsChecked == true)
            {
                var ds = from tk in db.Taikhoans where tk.TenNhanVien.Contains(tukhoa) == true select tk;
                this.dgDanhSachThuThu.ItemsSource = null;
                this.dgDanhSachThuThu.ItemsSource = ds.ToList();
            }
        }

        private void htdsthuthu_Click(object sender, RoutedEventArgs e)
        {
            tabcuaadmin_Loaded(sender, e);
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            if (this.dgdsSach.SelectedItem != null)
            {
                try
                {
                    Sach a = this.dgdsSach.SelectedItem as Sach;
                    var query = db.Saches.SingleOrDefault(sach => sach.MaSach == a.MaSach);
                    string relativePath = @"D:\abc\ttcsn\Demosualaicode\Manage_Library\Manage_Library\Manage_Library\img\" + query.AnhBia;
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(relativePath);
                    bitmap.EndInit();
                    this.anhbiasach.Source = bitmap;
                }
                catch (Exception ex) { 
                    MessageBox.Show("Ảnh không tồn tại","Lỗi lấy ảnh",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            
        }
    }
}
