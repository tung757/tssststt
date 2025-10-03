
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
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            QlthuVienContext db = new QlthuVienContext();
            if (thuThu.IsChecked == true)
            {
                var query = from tk in db.Taikhoans select tk;
                QuanLyThuVien qltv = new QuanLyThuVien();
                String tendn = this.accountName.Text;
                String passdn = this.password.Password;
                Boolean kttk = false;
                if(tendn=="admin" && passdn == "12345")
                {
                    qltv.txttenthuthu.Content = "Tên đăng nhập :" + tendn;
                    qltv.txtpassthuthu.Content = "Mật khẩu : " + passdn;
                    qltv.Show();
                    this.Close();
                    kttk = true;
                }
                else
                {
                    foreach (var tk in query)
                    {
                        if (tk.TaiKhoan1 == tendn && tk.MatKhau == passdn)
                        {
                            String[] listgio = tk.ThoiGianBatDau.Split('h');
                            int giodn = int.Parse(listgio[0]);
                            String[] listphut = listgio[1].Split('p');
                            int phutdn = int.Parse(listphut[0]);
                            String[] listgiokt = tk.ThoiGianKetThuc.Split('h');
                            int giokt = int.Parse(listgiokt[0]);
                            String[] listphutkt = listgiokt[1].Split('p');
                            int phutkt = int.Parse(listphutkt[0]);
                            if (giodn < DateTime.Now.Hour && DateTime.Now.Hour<giokt)
                            {
                                qltv.txttenthuthu.Content = "Tên đăng nhập :" + tk.TaiKhoan1;
                                qltv.txtpassthuthu.Content = "Mật khẩu : " + tk.MatKhau;
                                qltv.Show();
                                qltv.tabcuaadmin.Visibility = Visibility.Collapsed;
                                this.Close();
                                kttk = true;
                                break;
                            }
                            else if (giodn == DateTime.Now.Hour)
                            {
                                if (phutdn < DateTime.Now.Minute)
                                {
                                    qltv.txttenthuthu.Content = "Tên đăng nhập :" + tk.TaiKhoan1;
                                    qltv.txtpassthuthu.Content = "Mật khẩu : " + tk.MatKhau;
                                    qltv.Show();
                                    qltv.tabcuaadmin.Visibility = Visibility.Collapsed;
                                    this.Close();
                                    kttk = true;
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("Chưa đến giờ bạn đăng nhập","Lỗi thời gian",MessageBoxButton.OK, MessageBoxImage.Error);
                                    kttk = true;
                                }
                            }
                            else if(DateTime.Now.Hour==giokt)
                            {
                                if(phutdn > DateTime.Now.Minute)
                                {
                                    qltv.txttenthuthu.Content = "Tên đăng nhập :" + tk.TaiKhoan1;
                                    qltv.txtpassthuthu.Content = "Mật khẩu : " + tk.MatKhau;
                                    qltv.Show();
                                    qltv.tabcuaadmin.Visibility = Visibility.Collapsed;
                                    this.Close();
                                    kttk = true;
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("Chưa đến giờ bạn đăng nhập", "Lỗi thời gian", MessageBoxButton.OK, MessageBoxImage.Error);
                                    kttk = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Chưa đến giờ bạn đăng nhập", "Lỗi thời gian", MessageBoxButton.OK, MessageBoxImage.Error);
                                kttk = true;
                            }
                        }
                    }
                }
                if (kttk == false)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng .", "Lỗi nhập", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            if (docGia.IsChecked == true)
            {
                var sql = from nd in db.Nguoidungs select nd;
                String tendn = this.accountName.Text;
                String passdn = this.password.Password;
                Boolean kttk = false;
                foreach (var nd in sql)
                {
                    if (nd.Username == tendn && nd.Passw == passdn)
                    {
                        trangChuDocGia ttdg = new trangChuDocGia(nd.MaDg);
                        ttdg.txttendn.Content = "Tên đăng nhập :" + nd.Username;
                        ttdg.txttennguoidung.Content = "Tên người dùng : " + nd.TenNguoiDung;
                        ttdg.txtmatkhau.Content = "Mật khẩu : " + nd.Passw;
                        ttdg.Show();
                        this.Close();
                        kttk = true;
                        break;
                    }
                }
                if (kttk == false)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng .", "Lỗi nhập", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult tl = MessageBox.Show("Ban co muon thoat chuong trinh ? ", "EXIT", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (tl == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
