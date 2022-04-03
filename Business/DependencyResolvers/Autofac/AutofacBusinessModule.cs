using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Core.Others.Abstract;
using Core.Others.Concrete;
using Business.Helper.Abstract;
using Business.Helper.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<ShipperManager>().As<IShipperService>();
            builder.RegisterType<EfShipperDal>().As<IShipperDal>();

            builder.RegisterType<ArticleManager>().As<IArticleService>();
            builder.RegisterType<EfArticleDal>().As<IArticleDal>();

            builder.RegisterType<ProfilePhotoManager>().As<IProfilePhotoService>();
            builder.RegisterType<EfProfilePhotoDal>().As<IProfilePhotoDal>();

            builder.RegisterType<AboutManager>().As<IAboutService>();
            builder.RegisterType<EfAboutDal>().As<IAboutDal>();

            builder.RegisterType<FollowManager>().As<IFollowService>();
            builder.RegisterType<EfFollowDal>().As<IFollowDal>();

            builder.RegisterType<MessageManager>().As<IMessageService>();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>();

            builder.RegisterType<MessageFileManager>().As<IMessageFileService>();
            builder.RegisterType<EfMessageFileDal>().As<IMessageFileDal>();


            builder.RegisterType<HistoryArticleManager>().As<IHistoryArticleService>();
            builder.RegisterType<EfHistoryArticleDal>().As<IHistoryArticleDal>();

            builder.RegisterType<BranchManager>().As<IBranchService>();
            builder.RegisterType<EfBranchDal>().As<IBranchDal>();

            builder.RegisterType<VideoManager>().As<IVideoService>();
            builder.RegisterType<EfVideoDal>().As<IVideoDal>();


            builder.RegisterType<PostManager>().As<IPostService>();
            builder.RegisterType<EfPostDal>().As<IPostDal>();


            builder.RegisterType<Header>().As<IHeader>();
            builder.RegisterType<PhotoUploadHelper>().As<IPhotoUploadHelper>();
            builder.RegisterType<PayHelper>().As<IPayHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
