using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMessageDal : EfEntityRepositoryBase<Message, SqlContext>, IMessageDal
    {
        public List<MessageWithFileDto> GetAllMessagesAndList(string KarsiUserName, string KendiUserName)
        {
            using (var context = new SqlContext())
            {
                var file = from a in context.MessageFiles
                           select new MessageFile
                           {
                               Id = a.Id,
                               MessageId = a.MessageId,
                               FileName = a.FileName,
                               FileType = a.FileType,
                               Size = a.Size,
                               Url = a.Url
                           };

                var result = from a in context.Messages
                             where a.AlanUserName == KarsiUserName && a.GonderenUserName == KendiUserName && a.GonderenUserSildiMi==false
                             || a.AlanUserName == KendiUserName && a.GonderenUserName == KarsiUserName  && a.AlanUserSildiMi == false
                             select new MessageWithFileDto
                             {
                                 MessageId = a.Id,
                                 AlanUserName = a.AlanUserName,
                                 Date = a.Date,
                                 Text = a.Text,
                                 GonderenUserName = a.GonderenUserName,
                                 File = !(file.Any(p => p.MessageId == a.Id))
                                     ? null
                                     : file.Where(p => p.MessageId == a.Id).ToList()[0]
                             };
                

                return result.ToList();
            }
        }
    }
}
