using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KiemTra
{
    internal class Program
    {
        public static void Bai_1()
        {
            bool checkDiem = false;
            bool checkNhapLai = false;
            double diem = 0;
            string chonNhapLai;
            do
            {
                do
                {
                    Console.Write("Nhap diem so cua sinh vien (tu 0 den 10): ");
                    checkDiem = double.TryParse(Console.ReadLine(), out diem);
                    if ((checkDiem == false) || (diem < 0) || (diem > 10))
                    {
                        Console.WriteLine("Diem so nhap sai");
                        checkNhapLai = true;
                    }
                    else
                    {
                        checkNhapLai = false;
                    }
                }
                while (checkNhapLai);

                if (diem < 5) { Console.WriteLine("Truot"); }
                else
                {
                    if (diem <= 6.9) { Console.WriteLine("Trung binh"); }
                    else
                    {
                        if (diem <= 8.4) { Console.WriteLine("Kha"); }
                        else { Console.WriteLine("Gioi"); }

                    }
                }
                chonNhapLai = "A";
                while (chonNhapLai != "Y")
                {
                    Console.Write("Ban co muon nhap tiep khong, neu co nhap Y, neu khong nhap N: ");
                    chonNhapLai = Console.ReadLine();
                    if (chonNhapLai == "N") { break; }

                }
            }
            while (chonNhapLai == "Y");
        }

        public static async Task Bai_2()
        {
            int n;
            bool check = false;
            do
            {
                Console.Write("Nhap vao so sinh vien: ");
                check = int.TryParse(Console.ReadLine(), out n);
            }
            while (!check);
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                bool checkDiemSo = false;
                do
                {
                    Console.Write("Nhap vao diem so cua sinh vien thu " + (i + 1) + ": ");
                    checkDiemSo = int.TryParse(Console.ReadLine(), out a[i]);
                }
                while ((!checkDiemSo) || (a[i] < 0) || (a[i] > 10));
            }
            int min = a[0];
            int max = a[0];
            int tong = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] < min) { min = a[i]; }
                if (a[i] > max) { max = a[i]; }
                tong = tong + a[i];
            }
            double diemTrungBinh = (double)tong / n;
            Console.WriteLine("Diem trung binh: " + Math.Round(diemTrungBinh, 1));
            Console.WriteLine("Diem cao nhat: " + max);
            Console.WriteLine("Diem thap nhat: " + min);
        }
        public static void Bai_3()
        {
            List<string> danhSachSinhVien = new List<string>();
            string inPut;
            do
            {
                Console.Write("Nhap vao ho ten sinh vien, neu ket thuc danh sach nhap \"end\":");
                inPut = Console.ReadLine();
                danhSachSinhVien.Add(inPut);
            }
            while (inPut != "end");
            List<string> tenSinhVienDaiNhat = new List<string>();
            Console.WriteLine("Danh sach sinh vien: ");
            int index = 0;
            tenSinhVienDaiNhat.Add(danhSachSinhVien[0]);
            for (int i = 1; i < danhSachSinhVien.Count; i++)
            {
                Console.WriteLine(danhSachSinhVien[i]);
                if (danhSachSinhVien[i].Length > tenSinhVienDaiNhat[index].Length)
                {
                    tenSinhVienDaiNhat[index] = danhSachSinhVien[i];
                }
                if (danhSachSinhVien[i].Length == tenSinhVienDaiNhat[index].Length)
                {
                    tenSinhVienDaiNhat.Add(danhSachSinhVien[i]);
                    index++;
                }
            }
            Console.WriteLine("Ten sinh vien dai nhat: ");
            foreach (var ten in tenSinhVienDaiNhat)
            {
                Console.WriteLine(ten);
            }

        }

        public static void Bai_4()
        {
            //            Viết chương trình lưu trữ mã sinh viên và tên sinh viên bằng Dictionary<string, string>.
            //Cho phép thêm sinh viên mới.
            //Cho phép tìm tên sinh viên theo mã.
            //Nếu không có → in "Không tìm thấy".
            Dictionary<string, string> danhSachSinhVien = new Dictionary<string, string>();
            string check;
            string key;
            string ten;

            do
            {
                Console.Write("Nhap vao ma so sinh vien: ");
                key = Console.ReadLine();
                Console.Write("Nhap ten sinh vien: ");
                ten = Console.ReadLine();
                danhSachSinhVien.Add(key, ten);
                Console.Write("Ban co muon nhap tiep khong?(Y/N): ");
                check = Console.ReadLine();
            }
            while (check == "Y");
            Console.Write("Nhap ma sinh vien can tim: ");
            string maSinhVien = Console.ReadLine();
            string tenSinhVienCanTim;
            if (danhSachSinhVien.TryGetValue(maSinhVien, out tenSinhVienCanTim))
            {
                Console.WriteLine("Sinh vien co ma sinh vien {0} co ten la: {1}", maSinhVien, tenSinhVienCanTim);
            }
            else
            {
                Console.WriteLine("Không tìm thấy sinh vien co ma sinh vien " + maSinhVien);
            }
        }
        public class Student
        {
            public string id { get; set; }
            public string name { get; set; }
            public int score { get; set; }
            public Student() { }
            public Student(string id, string name, int score)
            {
                this.id = id;
                this.name = name;
                this.score = score;
            }
            public void Display()
            {
                Console.WriteLine("ID cua sinh vien: " + id);
                Console.WriteLine("Ten cua sinh vien: " + name);
                Console.WriteLine("Diem cua sinh vien: " + score);
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Bai_1();
            Bai_2();
            Bai_3();
            Bai_4();

            List<Student> danhSachSinhVien = new List<Student>();

            string check;
            string id;
            string name;
            int score;
            do
            {
                Console.Write("Nhap vao ID sinh vien: ");
                id = Console.ReadLine();
                Console.Write("Nhap vao ten sinh vien: ");
                name = Console.ReadLine();
                Console.Write("Nhap vao diem sinh vien: ");
                score = int.Parse(Console.ReadLine());
                Student sinhVien = new Student(id, name, score);
                danhSachSinhVien.Add(sinhVien);
                Console.Write("Ban co muon nhap tiep?(Y/N): ");
                check = Console.ReadLine();
            }
            while (check == "Y");
            Console.WriteLine("Danh sach sinh vien: ");
            for (int i = 0; i < danhSachSinhVien.Count; i++)
            {
                danhSachSinhVien[i].Display();
            }
            Console.Write("Nhap ten sinh vien can tim (khong phan biet chu hoa va chu thuong: ");
            string tenCanTim = Console.ReadLine();
            int diemMax = int.MinValue;
            bool checkTim = false;
            List<Student> danhSachSinhVienDiemCaoNhat = new List<Student>();
            List<Student> danhSachSinhVienDiem8 = new List<Student>();
            List<Student> danhsachSinhVienCanTim = new List<Student>();
            foreach (var item in danhSachSinhVien)
            {
                if (diemMax < item.score)
                {
                    diemMax = item.score;
                    danhSachSinhVienDiemCaoNhat.Clear();
                    danhSachSinhVienDiemCaoNhat.Add(item);
                }
                if (diemMax == item.score) { danhSachSinhVienDiemCaoNhat.Add(item); }

                if (item.score >= 8) { danhSachSinhVienDiem8.Add(item); }

                if (tenCanTim.Equals(item.name, StringComparison.OrdinalIgnoreCase))
                {
                    danhsachSinhVienCanTim.Add(item);
                    checkTim = true;
                }

            }
            Console.WriteLine("Sinh vien co diem cao nhat: ");
            foreach (var item in danhSachSinhVienDiemCaoNhat)
            {
                item.Display();
            }
            Console.WriteLine("Sinh vien co diem >=8: ");
            foreach (var item in danhSachSinhVienDiem8)
            {
                item.Display();
            }
            if (checkTim)
            {
                Console.WriteLine("Thong tin sinh vien can tim: ");
                foreach (var item in danhsachSinhVienCanTim)
                {
                    item.Display();
                }
            }
            else { Console.WriteLine("Khong tim thay sinh vien co ten " + tenCanTim); }
        }
    }
}
