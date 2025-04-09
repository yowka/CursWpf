using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace CursWpf
{
    internal class DBManager
    {
        public static skirnevskiy_courseEntities db = new skirnevskiy_courseEntities();

        public static ImageSource CurrentProfileImage { get; set; }
        public static int id_buyer { get; set; }
        public static int id_employee { get; set; }
        public static string login { get; set; }
        public static string password { get; set; }
        public static int roles { get; set; }
        public static string File { get; set; }

        public static bool Auth(string login, string password)
        {
            bool Auth = false;
            int id = 0;
            id = db.Buyer.AsNoTracking().Where(o => o.login == login && o.password == password).Select(o => o.id).FirstOrDefault();
            if (id != 0)
            {
                id_buyer = id;
                Auth = true;
                roles = db.Buyer.AsNoTracking().Where(o => o.id == id).Select(o => o.role_id).FirstOrDefault();
                return true;
            }
            id = db.Employee.AsNoTracking().Where(o => o.login == login && o.password == password).Select(o => o.id).FirstOrDefault();
            if (id != 0)
            {
                id_employee = id;
                Auth = true;
                roles = db.Employee.AsNoTracking().Where(o => o.id == id).Select(o => o.role_id).FirstOrDefault();
            }
            return Auth;
        }

        public static bool Reg(string name, string surname, string login, string password, string iFile)
        {
            bool Reg = false;
            if (db.Buyer.Where(o => o.login == login).Select(o => o).FirstOrDefault() == null)
            {
                byte[] images = LoadingImage(iFile);
                Buyer user = new Buyer
                {
                    name = name,
                    surname = surname,
                    login = login,
                    password = password,
                    role_id = 3,
                    photo = images
                };

                db.Buyer.Add(user);
                db.SaveChanges();
                Reg = true;
            }
            return Reg;
        }

        public static byte[] LoadingImage(string iFile)
        {
            if (string.IsNullOrEmpty(iFile)) return null;

            try
            {
                return System.IO.File.ReadAllBytes(iFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");
                return null;
            }
        }

    }
}