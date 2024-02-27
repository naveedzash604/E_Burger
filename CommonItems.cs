using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;


namespace E_Burger
{
    public class CommonItems
    {
        /// <summary>
        /// This Method Hashes the Password using MD5
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns> Hashed Password as a String </returns>
        public string paswordHash(string pwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pwd));

            // password as hash
            byte[] result = md5.Hash;


            StringBuilder crreateString = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                crreateString.Append(result[i].ToString("x2"));
            }
            return crreateString.ToString();
        }
    }
}