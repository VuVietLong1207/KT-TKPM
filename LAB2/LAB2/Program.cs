using System;
using System.Collections.Generic;
using LAB2.Models;
using LAB2.Logic;

namespace LAB2
{
    class Program
    {
        static StudentService service = new StudentService();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- QUAN LY SINH VIEN MONGODB (LAB2) ---");
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
            var list = service.GetAll();
            PrintList(list);
        }

        static void AddStudent()
        {
            try
            {
                Student s = new Student();
                Console.Write("ID (so): "); s.Id = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Ten: "); s.Name = Console.ReadLine() ?? "";
                Console.Write("Email: "); s.Email = Console.ReadLine() ?? "";
                Console.Write("Dia chi: "); s.Address = Console.ReadLine() ?? "";
                Console.Write("Tuoi: "); s.Age = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Diem: "); s.Grade = double.Parse(Console.ReadLine() ?? "0");
                service.Add(s);
                Console.WriteLine("Them vao MongoDB thanh cong!");
            }
            catch (Exception ex) { Console.WriteLine("Loi: " + ex.Message); }
        }

        static void DeleteStudent()
        {
            Console.Write("Nhap ID can xoa: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                service.Delete(id);
                Console.WriteLine("Da thuc hien lenh xoa.");
            }
        }

        static void SearchStudent()
        {
            Console.Write("Nhap tu khoa tim kiem: ");
            string kw = Console.ReadLine() ?? "";
            PrintList(service.Search(kw));
        }

        static void PrintList(List<Student> list)
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"{"ID",-5} {"Ten",-20} {"Diem",-7} {"Dia chi",-15}");
            Console.WriteLine("------------------------------------------------------------");
            if (list.Count == 0) Console.WriteLine("Danh sach trong.");
            foreach (var s in list)
                Console.WriteLine($"{s.Id,-5} {s.Name,-20} {s.Grade,-7} {s.Address,-15}");
        }

        static void UpdateStudent()
        {
            Console.Write("Nhap ID can sua: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Student s = new Student { Id = id };
                Console.Write("Ten moi: "); s.Name = Console.ReadLine() ?? "";
                Console.Write("Dia chi moi: "); s.Address = Console.ReadLine() ?? "";
                Console.Write("Diem moi: "); s.Grade = double.Parse(Console.ReadLine() ?? "0");
                service.Update(s);
                Console.WriteLine("Cap nhat thanh cong!");
            }
        }
    }
}