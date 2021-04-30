using Autofac;
using AutoMapper;
using Audiobooks.Data.Models;
using Audiobooks.Domain.Models;
using Audiobooks.Models;

namespace Audiobooks.App_Start
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthorModel, AuthorViewModel>(MemberList.Destination);
                cfg.CreateMap<Author, AuthorModel>(MemberList.Destination);
                cfg.CreateMap<AuthorPostModel, AuthorModel>(MemberList.Source);
                cfg.CreateMap<AuthorModel, Author>(MemberList.Source);

                cfg.CreateMap<Domain.Models.BookModel, BookViewModel>(MemberList.Destination);
                cfg.CreateMap<Data.Models.Book, Domain.Models.BookModel>(MemberList.Destination);
                cfg.CreateMap<BookPostModel, Domain.Models.BookModel>(MemberList.Source);
                cfg.CreateMap<Domain.Models.BookModel, Data.Models.Book>(MemberList.Source);

                cfg.CreateMap<GenreModel, GenreViewModel>(MemberList.Destination);
                cfg.CreateMap<Genre, GenreModel>(MemberList.Destination);
                cfg.CreateMap<GenrePostModel, GenreModel>(MemberList.Source);
                cfg.CreateMap<GenreModel, Genre>(MemberList.Source);

                cfg.CreateMap<ReaderModel, ReaderViewModel>(MemberList.Destination);
                cfg.CreateMap<Reader, ReaderModel>(MemberList.Destination);
                cfg.CreateMap<ReaderPostModel, ReaderModel>(MemberList.Source);
                cfg.CreateMap<ReaderModel, Reader>(MemberList.Source);

                cfg.CreateMap<PurchaseModel, PurchaseViewModel>(MemberList.Destination);
                cfg.CreateMap<Purchase, PurchaseModel>(MemberList.Destination);
                cfg.CreateMap<PurchasePostModel, PurchaseModel>(MemberList.Source);
                cfg.CreateMap<PurchaseModel, Purchase>(MemberList.Source);

                cfg.CreateMap<CoverModel, CoverViewModel>(MemberList.Destination);
                cfg.CreateMap<CoverViewModel, CoverModel>(MemberList.Destination);
                cfg.CreateMap<Cover, CoverModel>(MemberList.Destination);
                cfg.CreateMap<CoverModel, Cover>(MemberList.Source);

                cfg.CreateMap<ArchiveModel, ArchiveViewModel>(MemberList.Destination);
                cfg.CreateMap<ArchiveViewModel, ArchiveModel>(MemberList.Destination);
                cfg.CreateMap<Archive, ArchiveModel>(MemberList.Destination);
                cfg.CreateMap<ArchiveModel, Archive>(MemberList.Source);
            }));

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }
    }
}