using Autofac;
using Autofac.Integration.Mvc;
using Audiobooks.Data.Contracts;
using Audiobooks.Data.Repositories;
using Audiobooks.Domain.Contracts;
using Audiobooks.Domain.Services;
using System.Web.Mvc;
using Audiobooks.Data;

namespace Audiobooks.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<AuthorService>().As<IAuthorService>();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();

            builder.RegisterType<BookService>().As<IBookService>();
            builder.RegisterType<BookRepository>().As<IBookRepository>();

            builder.RegisterType<GenreService>().As<IGenreService>();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>();

            builder.RegisterType<ReaderService>().As<IReaderService>();
            builder.RegisterType<ReaderRepository>().As<IReaderRepository>();

            builder.RegisterType<PurchaseRepository>().As<IPurchaseRepository>();

            builder.RegisterType<FileStorage>().As<IFileStorage>();

            builder.RegisterType<CoverRepository>().As<ICoverRepository>();

            builder.RegisterType<ArchiveRepository>().As<IArchiveRepository>();

            builder.Register(x => new BooksContext()).As<BooksContext>().InstancePerLifetimeScope();

            builder.RegisterModule<AutoMapperModule>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}