using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new BloggingContext())
            {
                int.TryParse(Age.Text, out int age);

                var person = new Person 
                {
                    Name = NamePerson.Text,
                    LastName = LastName.Text,
                    Age = age,
                    PhoneNumber = button1.Text,
                };

                db.Persons.Add(person);
                db.SaveChanges();
                this.Close();

                //search in DB with the help LINQ
                //var query = from b in db.Persons
                //            orderby b.Id
                //            select b;

                //foreach (var item in query)
                //{
                //    Console.WriteLine($"Id: {item.Id}\tName: {item.Name}\tLast Name: {item.LastName}\tAge: {item.Age}\tPhone Number{item.PhoneNumber}");
                //}
            }
        }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}
