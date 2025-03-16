﻿using Blog.Models;
using Blog.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog1
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=Kesley1010; TrustServerCertificate=True";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            ReadUsersWithRoles(connection);
            //ReadUsers(connection);
            //CreateUsers(connection);
            //ReadRoles(connection);
            //ReadTags(connection);


            connection.Close();
        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();
 
            foreach(var item in items)
            {
                Console.WriteLine(item.Name);
                foreach(var role in item.Roles)
                    Console.WriteLine($" - {role.Name}");
            }
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();
 
            foreach(var item in items)
            {
                Console.WriteLine(item.Name);
                foreach(var role in item.Roles)
                    Console.WriteLine($" - {role.Name}");
            }
        }

        public static void CreateUsers(SqlConnection connection)
        {
            var user = new User()
            {
                Email = "email@balta.io",
                Bio = "Bio",
                Image = "imagem",
                Name = "Name",
                PasswordHash = "hash",
                Slug = "slug"
            };
            var repository = new Repository<User>(connection);
            connection.Insert<User>(user);
            
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();
 
            foreach(var item in items)
                Console.WriteLine(item.Name);
        }

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();
 
            foreach(var item in items)
                Console.WriteLine(item.Name);
        }
    }
}