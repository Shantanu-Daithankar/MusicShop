using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MusicShop.Interfaces;
using MusicShop.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop
{
    public class BootStrap
    {
        public static WindsorContainer Container;

        static BootStrap()
        {
            RegisterAll();
        }

        private static WindsorContainer RegisterAll()
        {
            Container = new WindsorContainer();

            Container.Register(Component.For<IAlbumService>().ImplementedBy<AlbumService>());

            Container.Register(Component.For<IRepositoryService>()
                                        .ImplementedBy<DatabaseService>()
                                        .DependsOn(Dependency.OnValue("dbfilePath", "D:\\shantanu\\apps\\MusicShop\\Database\\chinook.db")));

            return Container;
        }
    }
}
