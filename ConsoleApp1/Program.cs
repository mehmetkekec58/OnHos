using Business.Abstract;
using Business.Concrete;
using Business.Helper.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
          /*  MessageManager messageManager = new MessageManager(new EfMessageDal(),new MessageFileManager(new EfMessageFileDal(),new FileUploadHelper()));
            List<Message> messages =  messageManager.AllMessageDelete("string","mehmetkekec");
            foreach (Message message in messages)
            {
                Console.WriteLine(message.Text);*/
            //}
         //   Console.WriteLine(DateTime.Now);







            /* UserManager dd = new UserManager(new EfUserDal());

             User a=new User();
             a.UserName = "mehmetkekec";
             a.Email = "iletisim@mehmetkekec.com";

            var result = dd.GetClaims(a);*/
            /*      EfUserDal aa = new EfUserDal();
                 List<OperationClaim> bb = aa.ww("mehmetkekec");
                   foreach (var r in bb)
                   {
                       Console.WriteLine(r.Name);
                   }
                */
            //    deneme aa = new deneme();
     /*      UserManager ff = new UserManager(new EfUserDal());
          bool r =  ff.GetUsersByUserName(new string[] {"mehmetkekec", "string"});
            Console.WriteLine(r); */

        
        }

      /*  public class deneme
        {
            public bool dd()
            {
                UserManager aa = new UserManager(new EfUserDal());
                List<string> vv = aa.GetClaimsNameByUserName("mehmetkekec");
                foreach (string item in vv)
                {
                    if (item != "")
                    {
                        return true;
                    }
                }
                return false;
            }
    }*/
    }
}
