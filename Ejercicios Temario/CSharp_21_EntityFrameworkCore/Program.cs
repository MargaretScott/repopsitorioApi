using System;
using System.Collections.Generic;
using System.Linq;
using CSharp_21_EntityFrameworkCore.Entities;

namespace CSharp_21_EntityFrameworkCore
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                //CRUD -> Create, Read, Update and Delete
                // 1. Create        
                AddData(context);

                // 2. Read
                ShowDatabase(context);

                // 3. Update
                ModifySchoolAdress(context);

                // 4. Delete
                ResetDatabase(context);

                ShowDatabase(context);

                Console.ReadLine();
            }
        }

        /// <summary>
        /// Modificar la direccion del colegio
        /// </summary>
        /// <param name="context"></param>
        private static void ModifySchoolAdress(DatabaseContext context)
        {
            var _schoolToUpdate = context.Schools.FirstOrDefault();

            _schoolToUpdate.Adress = "C/ Henan Cortes, 39";
            context.Schools.Update(_schoolToUpdate);

            context.SaveChanges();
            Console.WriteLine("  ...Direccion {0} modificada...", _schoolToUpdate.Adress);
            Console.WriteLine(context.Schools.FirstOrDefault().Adress);
        }

        /// <summary>
        /// Borra todos los datos de la base de datos
        /// </summary>
        /// <param name="context"></param>
        private static void ResetDatabase(DatabaseContext context)
        {
            context.Classes.RemoveRange(context.Classes.ToList());
            context.Students.RemoveRange(context.Students.ToList());
            context.Schools.RemoveRange(context.Schools.ToList());

            context.SaveChanges();
            Console.WriteLine("  ...Datos borrados...");
        }

        /// <summary>
        /// Añadir datos a la base de datos
        /// </summary>
        /// <param name="context"></param>
        private static void AddData(DatabaseContext context)
        {
            var clase1 = new Class() { Name = "Tortugas" };
            var clase2 = new Class() { Name = "Hormiga" };
            context.Classes.AddRange(clase1, clase2);

            var escuela = new School()
            {
                Adress = "Constitución, 4",
                Students = new List<Student>
                     {
                         new Student{ FullName="Elisa", Class= clase1 },
                         new Student{ FullName="Antonio", Class=clase1 },
                         new Student{ FullName="Isabel", Class=clase2 },
                         new Student{ FullName="Rafael", Class=clase2 },
                     }
            };

            context.Schools.Add(escuela);
            context.SaveChanges();
            Console.WriteLine("  ...Datos creados...");
        }

        /// <summary>
        /// 4. Muestra todas las entidades de nuestra base de datos
        /// </summary>
        /// <param name="context"></param>
        private static void ShowDatabase(DatabaseContext context)
        {

            var query =
                from school in context.Schools
                orderby school.Adress
                select school;

            List<School> _schools = query.ToList();

            List<Student> _students = context.Students.ToList();
            List<Class> _classes = context.Classes.ToList();


            foreach (var school in _schools)
            {
                Console.WriteLine("Colegio - id: {0}, Direccion: {1}", school.Id, school.Adress);
                Console.WriteLine("  Alumnos: ");
                foreach (var student in school.Students)
                {
                    Console.WriteLine("  id: {0}, Nombre: {1}", student.Id, student.FullName);
                    Console.WriteLine("    Clase - id: {0}, Nombre: {1}", student.ClassId, student.Class.Name);
                }
            }

            foreach (var item in _classes)
            {
                Console.WriteLine("Clase - id: {0}, Nombre:{1}", item.Id, item.Name);
                if (item.Students?.Any() == true)
                {
                    Console.WriteLine("  Alumnos: ");
                    foreach (var s in item.Students)
                    {
                        Console.WriteLine("    id: {0}, Nombre: {1}", s.Id, s.FullName);
                    }
                }

            }

        }
    }
}