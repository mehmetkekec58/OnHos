using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TagManager : ITagService
    {
        ITagDal _tagDal;

        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }

        public IResult Add(string tagName)
        {
            _tagDal.Add(new Tag
            {
                TagName=tagName
            });
            return new SuccessResult();
        }

        public IResult Add(string[] tags)
        {
            foreach (string tagName in tags)
            {
                _tagDal.Add(new Tag
                {
                    TagName = tagName
                });
            }
            return new SuccessResult();
        }

        public IResult Detele(Tag tag)
        {
           _tagDal.Delete(tag);
            return new SuccessResult();
        }

        public IDataResult<Tag> Get(string tagName)
        {
           return new SuccessDataResult<Tag>(_tagDal.Get(p=>p.TagName==tagName));
        }

        public IDataResult<List<Tag>> GetAll()
        {
           return new SuccessDataResult<List<Tag>>(_tagDal.GetAll());
        }

        public IDataResult<List<Tag>> GetTagsNameByArticleId(int id)
        {
            return new SuccessDataResult<List<Tag>>(_tagDal.GetAllByArticleId(id));
        }

        public IDataResult<List<Tag>> GetTagsNameByVideoId(int id)
        {
            return new SuccessDataResult<List<Tag>>(_tagDal.GetAllByVideoId(id));
        }

        public IResult Update(Tag tag)
        {
           _tagDal.Update(tag);
            return new SuccessResult();
        }
    }
}
