using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DatabaseConnection
{
    class UserInfo
    {
        static void Userinfo()
        {
        string filePath = @"C:\Users\cream\source\repos\ViaFlix\RentalShopPoC\DatabaseConnection\UserInfo\userinfo.txt";



        File.ReadAllLines(filePath);
        
        }
    }
}