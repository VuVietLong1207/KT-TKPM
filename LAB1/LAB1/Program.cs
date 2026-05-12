using System;
using System.Collections.Generic;
using LAB1.Models;
using LAB1.Logic;

namespace LAB1
{
    class Program
    {
        static StudentService service = new StudentService();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- CHUONG TRINH QUAN LY SINH VIEN (LAB1) ---");
                Console.WriteLine("1. Hien thi danh sach");
                Console.WriteLine("2. Them sinh vien");
                Console.WriteLine("3. Sua sinh vien");
                Console.WriteLine("4. Xoa sinh vien");
                Console.WriteLine("5. Tim kiem");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": ShowAll(); break;
                    case "2": AddStudent(); break;
                    case "3": UpdateStudent(); break;
                    case "4": DeleteStudent(); break;
                    case "5": SearchStudent(); break;
                    case "0": return;
                }
                Console.WriteLine("\nNhan phim bat ky de tiep tuc...");
                Console.ReadKey();
            }
        }

        static void ShowAll()
        {
            PrintList(service.GetAll());
        }

        static void AddStudent()
        {
            try
            {
                Student s = new Student();
                Console.Write("ID: "); s.Id = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Ten: "); s.Name = Console.ReadLine() ?? "";
                Console.Write("Email: "); s.Email = Console.ReadLine() ?? "";
                Console.Write("Dia chi: "); s.Address = Console.ReadLine() ?? "";
                Console.Write("Tuoi: "); s.Age = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Diem: "); s.Grade = double.Parse(Console.ReadLine() ?? "0");
                service.Add(s);
                Console.WriteLine("Them thanh cong!");
            }
            catch { Console.WriteLine("Loi nhap lieu!"); }
        }

        static void DeleteStudent()
        {
            Console.Write("Nhap ID can xoa: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (service.Delete(id)) Console.WriteLine("Xoa thanh cong!");
                else Console.WriteLine("Khong tim thay ID.");
            }
        }

        static void SearchStudent()
        {
            Console.Write("Nhap tu khoa (ID, Ten, Dia chi hoac Diem): ");
            string kw = Console.ReadLine() ?? "";
            PrintList(service.Search(kw));
        }

        static void PrintList(List<Student> list)
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"{"ID",-5} {"Ten",-20} {"Diem",-7} {"Dia chi",-15}");
            Console.WriteLine("------------------------------------------------------------");
            foreach (var s in list)
                Console.WriteLine($"{s.Id,-5} {s.Name,-20} {s.Grade,-7} {s.Address,-15}");
        }

        static void UpdateStudent()
        {
            Console.Write("Nhap ID can sua: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var existing = service.GetAll().Find(s => s.Id == id);
                if (existing != null)
                {
                    Console.Write("Ten moi: "); existing.Name = Console.ReadLine() ?? existing.Name;
                    Console.Write("Dia chi moi: "); existing.Address = Console.ReadLine() ?? existing.Address;
                    Console.Write("Diem moi: "); existing.Grade = double.Parse(Console.ReadLine() ?? "0");
                    service.Update(existing);
                    Console.WriteLine("Cap nhat thanh cong!");
                }
                else Console.WriteLine("Khong tim thay!");
            }
        }
    }
}