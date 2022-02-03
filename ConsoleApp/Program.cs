using Business.Concrete;
using Business.Helper.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EfUserDal hey = new EfUserDal();
            //  hey.GetProfileDetail("string");

            // Console.WriteLine(hey.GetProfilesDetails(new string[] { "string" }));
          /*  ProfilePhotoManager aa = new ProfilePhotoManager(new EfProfilePhotoDal(), new PhotoUploadHelper() );
            aa.Update();
          */
            hey.GetProfileDetail("rr");
        }
    }
}
